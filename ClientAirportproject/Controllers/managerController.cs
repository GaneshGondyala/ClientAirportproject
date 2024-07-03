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
    public class managerController : Controller
    {
        // GET: manager
        public ActionResult addmanager()
        {
            manager_addressclass ma=new manager_addressclass();
            return View(ma);
        }
        [HttpPost]
        public ActionResult addmanager( manager_addressclass m,string adrid)
        {




            if (ModelState.IsValid)
            {
                if (adrid != "")
                {
                    string apiUrl = "https://ganeshgondyalaserver.azurewebsites.net/api/managerr";


                    // Create an instance of HttpClient
                    using (HttpClient client = new HttpClient())
                    {




                        var id = m.mng.SSN[0] + m.mng.SSN[1] + m.mng.SSN[2] + m.mng.SSN[3]+"MGR"+ManagerIDs.GetNextmanagerID().ToString();
                        string mngid = id.ToString();
                        var pwd = m.mng.email[1].ToString()+ m.mng.email[2].ToString()+ m.mng.mobile[2].ToString()+ adrid[1].ToString()+m.mng.SSN[1];

                        string pwdd=pwd.ToString();
                    

                        // Prepare data to be sent
                        var data = new
                        { Name=m.mng.Name,
                            SSN=m.mng.SSN,
                            DOB=m.mng.DOB,
                            Gender=m.mng.Gender,
                            mobile=m.mng.mobile,
                            email=m.mng.email,
                            AddressId=adrid,
                            ManagerId=mngid,
                            password=pwdd
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
                               
                                string errorMessage = response.Content.ReadAsStringAsync().Result;

                                // Parse the JSON to extract the specific error message
                                dynamic errorObject = JsonConvert.DeserializeObject(errorMessage);
                                string specificErrorMessage = errorObject.ToString();


                                ViewBag.mstatus=status;
                                ViewBag.msg = specificErrorMessage + " password is " + pwdd;
                                ModelState.Clear();
                            }
                            else
                            {


                                status = "no";
                                ViewBag.mnstatus = status;
                                string errorMessage = response.Content.ReadAsStringAsync().Result;

                                // Parse the JSON to extract the specific error message
                                dynamic errorObject = JsonConvert.DeserializeObject(errorMessage);
                                string specificErrorMessage = errorObject.Message;



                                ViewBag.msg1 = specificErrorMessage ;
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Error: {ex.Message}");
                        }

                    }


                }
                else

                {
                    string apiUrl = "https://ganeshgondyalaserver.azurewebsites.net/api/Address";

                    // Create an instance of HttpClient
                    using (HttpClient client = new HttpClient())
                    {
                        var id ="ADR"+AddressID.GetNextAdresID().ToString()+m.adrcl.City[0]+ m.adrcl.City[1]+ m.adrcl.City[2];
                        string Addid = id.ToString();


                        // Prepare data to be sent
                        var data = new
                        {
                            Hno = m.adrcl.Hno,
                            Address_line1 = m.adrcl.Address_line1,
                            City = m.adrcl.City,
                            state = m.adrcl.state,  
                            Country = m.adrcl.Country,
                            pincode = m.adrcl.pincode, 
                            AddressId = Addid
                        };

                      
                        var content = new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");
                        
                        try
                        {
                            HttpResponseMessage response = client.PostAsync(apiUrl, content).Result; 

                            // Check if the request was successful
                            if (response.IsSuccessStatusCode)
                            {
                               
                                string errorMessage = response.Content.ReadAsStringAsync().Result;

                                // Parse the JSON to extract the specific error message
                                dynamic errorObject = JsonConvert.DeserializeObject(errorMessage);
                                string specificErrorMessage = errorObject.ToString();



                                ViewBag.dmsg = specificErrorMessage;
                            }
                            else
                            {


                               
                                string errorMessage = response.Content.ReadAsStringAsync().Result;

                           
                                dynamic errorObject = JsonConvert.DeserializeObject(errorMessage);
                                string specificErrorMessage = errorObject.Message;



                                ViewBag.dmsg = specificErrorMessage ;
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Error: {ex.Message}");
                        }





                        string apiUrl1 = "https://ganeshgondyalaserver.azurewebsites.net/api/managerr";


                        var id1 = m.mng.SSN[0] + m.mng.SSN[1] + m.mng.SSN[2] + m.mng.SSN[3] + "MGR" + ManagerIDs.GetNextmanagerID().ToString();
                        string mngid = id1.ToString();
                        var pwd = m.mng.email[1].ToString() + m.mng.email[2].ToString() + m.mng.mobile[1].ToString() + m.mng.mobile[2].ToString() + Addid[1].ToString() ;

                        string pwdd = pwd.ToString();
                 


                        // Prepare data to be sent
                        var data1 = new
                        {
                            Name = m.mng.Name,
                            SSN = m.mng.SSN,
                            DOB = m.mng.DOB,
                            Gender = m.mng.Gender,
                            mobile = m.mng.mobile,
                            email = m.mng.email,
                            AddressId = Addid,
                            ManagerId = mngid,
                            password = pwdd
                        };

                        // Convert the data to JSON format
                        var content1 = new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(data1), Encoding.UTF8, "application/json");
                        string status = "";
                        try
                        {
                            // Make a POST request to the API
                            HttpResponseMessage response = client.PostAsync(apiUrl1, content1).Result; // Use .Result to wait synchronously

                            // Check if the request was successful
                            if (response.IsSuccessStatusCode)
                            {
                                status = "done";
                                ViewBag.status = status;
                                string errorMessage = response.Content.ReadAsStringAsync().Result;

                                // Parse the JSON to extract the specific error message
                                dynamic errorObject = JsonConvert.DeserializeObject(errorMessage);
                                string specificErrorMessage = errorObject.ToString();



                                ViewBag.msg = specificErrorMessage + " password is " + pwdd; 
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

            }


            return View();
        }
        public ActionResult ManagerDetails()
        {
            return View();
        }

    }
}