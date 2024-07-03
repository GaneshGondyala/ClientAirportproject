//using ClientAirportproject.Models.BAO;
//using ClientAirportproject.Models.DAO;
using CaptchaMvc.HtmlHelpers;
using ClientAirportproject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace ClientAirportproject.Controllers
{
    public class FliteManagerController : Controller
    {
        // GET: FliteManager

        public ActionResult Login()
        {

            Admin_mgrclass d = new Admin_mgrclass
            {
                AdminClass = new AdminClass(),
                Mgrclass = new mgrclass(),
            };
            //Metadata m = new Metadata();
            return View(d);
        }
        public ActionResult ValidateAdmin( Admin_mgrclass d)
        {
            if (ModelState.IsValid && this.IsCaptchaValid("Captcha is not verified!"))
            {
                using (var client = new HttpClient())
                {
                   
                    UriBuilder urlbdr = new UriBuilder("https://ganeshgondyalaserver.azurewebsites.net/api/Login/ValidateAdmin/{UsernameAdmin}/{PasswordAdmin}");
                    urlbdr.Query = "UsernameAdmin=" + d.AdminClass.username + "&PasswordAdmin=" + d.AdminClass.password;

                    //HTTP POST
                    var getTask = client.GetAsync(urlbdr.Uri);
                    getTask.Wait();
                    var result = getTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var display = result.Content.ReadAsStringAsync();
                        display.Wait();
                        var r = display.Result;
                        if (r == "true")
                        {
                            Session["user"] = d.AdminClass.username;
                            return RedirectToAction("Adminn", "Plane", new { id = d.AdminClass.username });
                        }



                    }
                    TempData["msg"] = "Invalid Credentials";
                    return RedirectToAction("Login", "FliteManager");
                }
            }
            else
            {
                TempData["msg"] = "Captcha is not verified! or Password username not entered";
                return RedirectToAction("Login", "FliteManager");
            }


        }
        public ActionResult ValidateManager(Admin_mgrclass d)
        {
            if (ModelState.IsValid && this.IsCaptchaValid("Captcha is not verified!"))
            {
                using (var client = new HttpClient())
                {
                    UriBuilder urlbdr = new UriBuilder("https://ganeshgondyalaserver.azurewebsites.net/api/Login/ValidateManager/{Usernamemgr}/{Passwordmgr}");
                    urlbdr.Query = "Usernamemgr=" + d.Mgrclass.username + "&Passwordmgr=" + d.Mgrclass.password;

                    //HTTP POST
                    var getTask = client.GetAsync(urlbdr.Uri);
                    getTask.Wait();
                    var result = getTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var display = result.Content.ReadAsStringAsync();
                        display.Wait();
                        var r = display.Result;
                        if (r == "true")
                        {
                            Session["user"] = d.Mgrclass.username;
                            return RedirectToAction("mgr", "Plane", new { id = d.Mgrclass.username });
                        }



                    }
                    TempData["msg"] = "Invalid Credentials";
                    return RedirectToAction("Login", "FliteManager");
                }
            }
            else
            {
                TempData["msg"] = "Captcha is not verified! or Password username not entered";
                return RedirectToAction("Login", "FliteManager");
            }

        }
        public ActionResult Logout()
        {

            return RedirectToAction("Logout1");
        }
        public ActionResult Logout1()
        {
            return View();
        }
        public ActionResult Logout2()
        {
            Session.Abandon();
            Session.RemoveAll();
            Session["user"] = null;
            return RedirectToAction("Logout1");


        }
        public ActionResult About()
        {
            return View();
        }
        public ActionResult Services()
        {
            return View();
        }
        public ActionResult Contact()
        {
            return View();
        }
    }
}

    
