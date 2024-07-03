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
    public class PilotController : Controller
    {
        // GET: Pilot
        public ActionResult Addpilot()
        {
            Pilot_addresclass pa = new Pilot_addresclass();
            return View(pa);
        }
        [HttpPost]
        public ActionResult Addpilot(Pilot_addresclass p,string adrid)
        {
            if(ModelState.IsValid)
            {
                if (adrid != "")
                {
                    string apiUrl = "https://ganeshgondyalaserver.azurewebsites.net/api/pilot";


                    // Create an instance of HttpClient
                    using (HttpClient client = new HttpClient())
                    {




                        var id = p.plt.SSN[7].ToString()+ p.plt.SSN[8].ToString()+ p.plt.SSN[9].ToString()+ p.plt.SSN[10].ToString()+"PLT"+PilotID.GetNextPilotID();
                        string pilotneid = id.ToString();


                        // Prepare data to be sent
                        var data = new
                        { License_no=p.plt.License_no,
                            SSN=p.plt.SSN,
                            DOB=p.plt.DOB,
                            Gender=p.plt.Gender,
                            Mobile=p.plt.Mobile,
                            Email=p.plt.Email,
                            AddressId=adrid,
                            Pilot_Id=pilotneid
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



                                ViewBag.msg = specificErrorMessage;
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
                else
                    
                {
                    string apiUrl = "https://ganeshgondyalaserver.azurewebsites.net/api/Address";

                    // Create an instance of HttpClient
                    using (HttpClient client = new HttpClient())
                    {
                        var id = "ADR" + AddressID.GetNextAdresID().ToString() + p.adrcla.City[0] + p.adrcla.City[1] + p.adrcla.City[2];
                        string Addid = id.ToString();
                       

                        // Prepare data to be sent
                        var data = new
                        {

                            Hno = p.adrcla.Hno,
                            Address_line1 = p.adrcla.Address_line1,
                            City = p.adrcla.City,
                            state = p.adrcla.state,  // 'state' property should match the case of your 'Addressclass'
                            Country = p.adrcla.Country,
                            pincode = p.adrcla.pincode,  // 'Pincode' property should match the case of your 'Addressclass'
                            AddressId = Addid
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
                                string specificErrorMessage = errorObject.Message;



                                ViewBag.admsg = specificErrorMessage;
                               
                            }
                            else
                            {


                                status = "no";
                                ViewBag.status = status;
                                string errorMessage = response.Content.ReadAsStringAsync().Result;

                                // Parse the JSON to extract the specific error message
                                dynamic errorObject = JsonConvert.DeserializeObject(errorMessage);
                                string specificErrorMessage = errorObject.Message;



                                ViewBag.ademsg = specificErrorMessage;
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Error: {ex.Message}");
                        }





                        string apiUrl1 = "https://ganeshgondyalaserver.azurewebsites.net/api/pilot";


                        var id1 = p.plt.SSN[7].ToString() + p.plt.SSN[8].ToString() + p.plt.SSN[9].ToString() + p.plt.SSN[10].ToString() + "PLT" + PilotID.GetNextPilotID();
                        string pilotneid = id1.ToString();


                        // Prepare data to be sent
                        var data1 = new
                        {
                            License_no = p.plt.License_no,
                            SSN = p.plt.SSN,
                            DOB = p.plt.DOB,
                            Gender = p.plt.Gender,
                            Mobile = p.plt.Mobile,
                            Email = p.plt.Email,
                            AddressId = Addid,
                            Pilot_Id = pilotneid
                        };

                        // Convert the data to JSON format
                        var content1 = new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(data1), Encoding.UTF8, "application/json");
                        string status1 = "";
                        try
                        {
                            // Make a POST request to the API
                            HttpResponseMessage response = client.PostAsync(apiUrl1, content1).Result; // Use .Result to wait synchronously

                            // Check if the request was successful
                            if (response.IsSuccessStatusCode)
                            {
                                status1 = "done";
                                ViewBag.status = status1;
                                string errorMessage = response.Content.ReadAsStringAsync().Result;

                                // Parse the JSON to extract the specific error message
                                dynamic errorObject = JsonConvert.DeserializeObject(errorMessage);
                                string specificErrorMessage = errorObject.ToString();



                                ViewBag.msg = specificErrorMessage;
                                ModelState.Clear();
                            }
                            else
                            {


                             
                                ViewBag.status ="no";
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
        public ActionResult addplane_pilot() 
        { 
            return View();
        } 
        public ActionResult addpilote_plane1(string pnid,string plid)
        {
            string apiUrl = "https://ganeshgondyalaserver.azurewebsites.net/api/plane_pilot";


            // Create an instance of HttpClient
            using (HttpClient client = new HttpClient())
            {


              


                // Prepare data to be sent
                var data = new
                {
                    Plane_id = pnid,
                    Pilot_id=plid,  
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

                        string error = errorObject.ToString();

                        ViewBag.msg = error;
                    }
                    else
                    {


                        status = "no";
                        ViewBag.status = status;
                        string errorMessage = response.Content.ReadAsStringAsync().Result;


                        dynamic errorObject = JsonConvert.DeserializeObject(errorMessage);
                        string specificErrorMessage = errorObject.Message;



                        ViewBag.msg = specificErrorMessage;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }

            }

            return View("addplane_pilot");
        }     
    }
}