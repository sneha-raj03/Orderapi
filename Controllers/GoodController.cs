using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GoodController : ControllerBase
    {




        [HttpGet]
        [Route("GetGoods")]
        public async Task <ActionResult> GetCustomer()
        {
            List<Good> custInfo = new List<Good>();



            using (var client = new HttpClient())
            {
                //Passing service base url  
                //       client.BaseAddress = new Uri(Baseurl);



                client.DefaultRequestHeaders.Clear();
                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));



                //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                HttpResponseMessage Res = await client.GetAsync("https://localhost:7149/api/Good");



                //Checking the response is successful or not which is sent using HttpClient  
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    var CustResponse = Res.Content.ReadAsStringAsync().Result;



                    //Deserializing the response recieved from web api and storing into the Employee list  
                    custInfo = JsonConvert.DeserializeObject<List<Good>>(CustResponse);



                }
                //returning the employee list to view  
                return Ok(custInfo);
            }
        }
        [HttpPost]
        public async Task<ActionResult> AddEmployee(Good e)
        {
            Good Emplobj = new Good();
            using (var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(e),
              Encoding.UTF8, "application/json");

                using (var response = await httpClient.PostAsync("https://localhost:7149/api/Good", content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    Emplobj = JsonConvert.DeserializeObject<Good>(apiResponse);
                }
            }
            return Ok(Emplobj);
        }
        [HttpGet]
        [Route("GetGoodbyId")]
        public async Task<ActionResult> UpdateEmployee(int id)
        {
            Good emp = new Good();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:7149/api/Good/GetProductById?id=" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    emp = JsonConvert.DeserializeObject<Good>(apiResponse);
                }
            }
            return Ok(emp);
        }

        [HttpPut]
        
        public async Task<ActionResult> UpdateEmployee(Good e)
        {
            Good receivedemp = new Good();

            using (var httpClient = new HttpClient())
            {
                
                int id = e.ProductId;
                StringContent content1 = new StringContent(JsonConvert.SerializeObject(e)
         , Encoding.UTF8, "application/json");
                using (var response = await httpClient.PutAsync("https://localhost:7149/api/Good?id=" + id, content1))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    //ViewBag.Result = "Success";
                    receivedemp = JsonConvert.DeserializeObject<Good>(apiResponse);
                }
            }
            return Ok(receivedemp);
        }



        [HttpDelete]



        public async Task<ActionResult> DeleteEmployee(int id)
        {
            Good cust = new Good();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.DeleteAsync("https://localhost:7149/api/Good?id=" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    cust = JsonConvert.DeserializeObject<Good>(apiResponse);
                }
            }



            return Ok(cust);
        }

    }

}

