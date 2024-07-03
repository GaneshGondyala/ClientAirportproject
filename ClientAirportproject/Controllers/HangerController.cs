using ClientAirportproject.Models;
using ClientAirportproject.Models.IDS;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace ClientAirportproject.Controllers
{
    public class HangerController : Controller
    {
        // GET: Hanger
        public ActionResult addhanger()
        {
            hangerclass h=new hangerclass();
            return View(h);
        }
        [HttpPost]
        public ActionResult addhanger(hangerclass h)
        {
            if(ModelState.IsValid)
            {
                string apiUrl = "https://ganeshgondyalaserver.azurewebsites.net//api/Hanger";
                using (HttpClient client = new HttpClient())
                {




                    var id ="HG"+hanger.GetNextHangerID().ToString()+ h.Location[0].ToString().ToUpper()+ h.Location[1].ToString().ToUpper() ;
                    string hgid = id.ToString();
                    

                     
                    // Prepare data to be sent
                    var data = new
                    { Location=h.Location,
                        Capacity=h.Capacity,
                        Manager_Id=h.Manager_Id,
                        HangerId=hgid
                    };

                    // Convert the data to JSON format
                    var content = new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");
                    string status = "";
                    try
                    {
                        // Make a POST request to the API
                        HttpResponseMessage response = client.PostAsync(apiUrl, content).Result; // Use .Result to wait synchronously

                        // Check if the request was successful
                        if (response.IsSuccessStatusCode)
                        {
                            status = "done";
                            ViewBag.status = status;
                            string errorMessage = response.Content.ReadAsStringAsync().Result;

                            // Parse the JSON to extract the specific error message
                            dynamic errorObject = JsonConvert.DeserializeObject(errorMessage);
                            string specificErrorMessage = errorObject.ToString();
                            ViewBag.msg = specificErrorMessage ;
                            ModelState.Clear();
                        }
                        else
                        {


                            status = "no";
                            ViewBag.status = status;
                            string errorMessage = response.Content.ReadAsStringAsync().Result;

                            // Parse the JSON to extract the specific error message
                            dynamic errorObject = JsonConvert.DeserializeObject(errorMessage);
                            string specificErrorMessage = errorObject.Message;



                            ViewBag.msg1 = specificErrorMessage;
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error: {ex.Message}");
                    }

                }

            }

            return View();
        }


        public ActionResult addplane_hanger()
        {
            Plane_hanger p=new Plane_hanger();  
            return View(p);
        }
        [HttpPost]
        public ActionResult addplane_hanger(Plane_hanger p)
        {
            if (ModelState.IsValid)
            {
                string apiUrl = "https://ganeshgondyalaserver.azurewebsites.net/api/Planehanger";
                using (HttpClient client = new HttpClient())
                {




                 



                    // Prepare data to be sent
                    var data = new
                    {
                        Plane_Id= p.Plane_Id,
                  Hanger_Id= p.Hanger_Id,
                 fromdate= p.fromdate,
                  todate= p.todate,
                         
                       };

                    // Convert the data to JSON format
                    var content = new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");
                    string status = "";
                    try
                    {
                        // Make a POST request to the API
                        HttpResponseMessage response = client.PostAsync(apiUrl, content).Result; // Use .Result to wait synchronously

                        // Check if the request was successful
                        if (response.IsSuccessStatusCode)
                        {
                            status = "done";
                            ViewBag.status = status;
                            string errorMessage = response.Content.ReadAsStringAsync().Result;
                            dynamic errorObject = JsonConvert.DeserializeObject(errorMessage);
                            string specificErrorMessage = errorObject.ToString();
                            ModelState.Clear(); 
                            ViewBag.msg = specificErrorMessage ;
                        }
                        else
                        {


                            status = "no";
                            ViewBag.status = status;
                            string errorMessage = response.Content.ReadAsStringAsync().Result;

                            // Parse the JSON to extract the specific error message
                            dynamic errorObject = JsonConvert.DeserializeObject(errorMessage);
                            string specificErrorMessage = errorObject.Message;



                            ViewBag.msg1 = specificErrorMessage;
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error: {ex.Message}");
                    }

                }

            }




            return View();

        }
        public ActionResult hangerstatus()
        {
            return View();  
        }

    }
}