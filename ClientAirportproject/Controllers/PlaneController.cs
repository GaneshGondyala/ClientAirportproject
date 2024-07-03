using ClientAirportproject.Models;
using ClientAirportproject.Models.IDS;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Web.Mvc;

namespace ClientAirportproject.Controllers
{
    public class PlaneController : Controller
    {
        // GET: Plane
        public ActionResult GetownAddresByEmail()
        {

           
            return View();
        }

        public ActionResult AddPlaneOwnerAddress()
        {
           planeowndetailsAd e= new planeowndetailsAd();
            return View(e);
        }

        [HttpPost]
        public ActionResult AddPlaneOwnerAddress(planeowndetailsAd a)
        {
            if(ModelState.IsValid)
            {

                string apiUrl = "https://ganeshgondyalaserver.azurewebsites.net/api/Address";
                string apiUrl2 = "https://ganeshgondyalaserver.azurewebsites.net/api/Planeowner";

                // Create an instance of HttpClient
                using (HttpClient client = new HttpClient())
                {
                    var id = "ADR" + AddressID.GetNextAdresID().ToString() + a.City[0].ToString().ToUpper() + a.City[1].ToString().ToUpper() + a.City[2].ToString().ToUpper();
                    string Addid = id.ToString();
                    Session["addrID"] = Addid;

                    // Prepare data to be sent
                    var data = new
                    {
                        Hno = a.Hno,
                        Address_line1 = a.Address_line1,
                        City = a.City,
                        state = a.state,  
                        Country = a.Country,
                        pincode = a.pincode,  
                        AddressId = Addid
                    };

                    // Convert the data to JSON format
                    var content = new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");
                
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

                            string error = errorObject.ToString();

                    
                            ViewBag.admsg =error ;
                        }
                        else
                        {


                           
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
                    var oid = "OWNR" + Pownerid.GetNextPlaneOwnerID().ToString() + a.email[2].ToString().ToUpper()+ a.email[0].ToString().ToUpper() + a.email[1].ToString().ToUpper();
                    string owid = oid.ToString();
                    var data2 = new
                    {
                        Email = a.email,
                        Owner_name = a.name,
                        address_Id = Session["addrID"].ToString(),
                        OwnerId = owid

                    };


                    var content2 = new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(data2), Encoding.UTF8, "application/json");


                    try
                    {
                        HttpResponseMessage response2 = client.PostAsync(apiUrl2, content2).Result;

                        if (response2.IsSuccessStatusCode)
                        {
                            ViewBag.status = "done";
                            string errorMessage = response2.Content.ReadAsStringAsync().Result;

                            // Parse the JSON to extract the specific error message
                            dynamic errorObject = JsonConvert.DeserializeObject(errorMessage);
                            string specificErrorMessage = errorObject.ToString();


                            Session["email"] = a.email;
                            ViewBag.em = a.email;
                            ViewBag.msg = specificErrorMessage;
                            ModelState.Clear();

                        }
                        else
                        {
                            ViewBag.status = "no";
                            string errorMessage2 = response2.Content.ReadAsStringAsync().Result;

                            dynamic errorObject2 = JsonConvert.DeserializeObject(errorMessage2);
                            string specificErrorMessage2 = errorObject2.Message;

                            ViewBag.msg1 = specificErrorMessage2;
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error (API 2): {ex.Message}");
                    }

                }
            }
           

            return View();
        }
       

        public ActionResult Addonlyplane(string email)
        {
           if( Session["email1"]!=null)
            {
                Session.Remove("email1");
            }
            Session["email1"] = (string)email;
            PlaneOnly p= new PlaneOnly();
            return View(p);
        }
        [HttpPost]
        public ActionResult Addonlyplane(PlaneOnly p)
        {
            if (ModelState.IsValid)
            {
                string apiUrl = "https://ganeshgondyalaserver.azurewebsites.net/api/Plane";
              

                // Create an instance of HttpClient
                using (HttpClient client = new HttpClient())
                {


                    int PLaneId1 = PlaneID.GetNextPlaneID();
                    string d = PLaneId1.ToString();

                    var id = "PLN" + p.Capacity.ToString() + p.Plane_Name[0].ToString().ToUpper() +PlaneID.GetNextPlaneID().ToString() +p.Plane_Name[2].ToString().ToUpper();
                    string planeid = id.ToString();


                    // Prepare data to be sent
                    var data = new
                    {
                        RegistrationNo = p.RegistrationNo,
                        ModelNo = p.ModelNo,
                        Plane_Name = p.Plane_Name,
                        Capacity = p.Capacity,
                        Email = Session["email1"] as String,
                        Plane_Id = planeid
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
                            ViewBag.statuspl = status;
                            string errorMessage = response.Content.ReadAsStringAsync().Result;

                            // Parse the JSON to extract the specific error message
                            dynamic errorObject = JsonConvert.DeserializeObject(errorMessage);

                            string error = errorObject.ToString();
                            ModelState.Clear();
                            ViewBag.msg = error;
                        }
                        else
                        {


                            status = "no";
                            ViewBag.statusnopl = status;
                            string errorMessage = response.Content.ReadAsStringAsync().Result;

                       
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
        public ActionResult Adminn(string id) 
        
        {
         
            Session["job"] = "admin";
            return View();
        }
        public ActionResult mgr(string id)
        {
      

            Session["job"] = "manager";

            return View();
        }

    }
}
