using Microsoft.AspNetCore.Mvc;
using mvc.Models;
using Newtonsoft.Json;
using mvc.Models;
using System.Net.Http;
using System.Text;
using System.Xml.Linq;

namespace mvc.Controllers
{
    public class CustomersController : Controller
    {
        private readonly ILogger _logger;   
        private readonly HttpClient _httpClient;

        public CustomersController(ILogger<CustomersController> logger)
        {
            _logger = logger;
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("http://api");
        }

        [HttpGet]
        public IActionResult Index()
        {
            try
            {
                HttpResponseMessage response = _httpClient.GetAsync("/customers").Result;
                if(response.IsSuccessStatusCode)
                {
                    string content = response.Content.ReadAsStringAsync().Result;
                    ViewBag.customerList = JsonConvert.DeserializeObject<List<CustomersViewModel>>(content);
                    return View();
                } else
                {
                    return View("Error");
                }
            }
            catch (HttpRequestException ex)
            {
                return View("Error");
            }
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                CustomersViewModel customer = new CustomersViewModel()
                {
                    Name = collection["Name"],
                    LastName = collection["LastName"]
                };
                string json = JsonConvert.SerializeObject(customer);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage response = _httpClient.PostAsync("customers/create", content).Result;
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return RedirectToAction(nameof(Create));
                }
            }
            catch
            {
                return View();
            }
        }
    }
}
