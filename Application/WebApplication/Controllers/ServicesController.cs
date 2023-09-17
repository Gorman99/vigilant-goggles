using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using WebApplication.Storage.Entities;

namespace WebApplication.Controllers
{
    public class ServicesController : Controller
    {


        private readonly HttpClient _httpClient;

        public ServicesController()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(ConfigurationManager.AppSettings["ApiBaseUrl"]);
        }

        // GET: Services
        public async Task<ActionResult> Index()
        {
            HttpResponseMessage response = await _httpClient.GetAsync("students");
            
            if (response.IsSuccessStatusCode)
            {
                var responseStr = await response.Content.ReadFromJsonAsync<List<Student>>();              
               return View(responseStr);
            }
            else
            {
                // Handle the error here, e.g., return a view with an error message.
                return View("Error");
            }
        }

        // GET: Students/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            HttpResponseMessage response = await _httpClient.GetAsync($"students/{id}");

            if (response.IsSuccessStatusCode)
            {
                var responseStr = await response.Content.ReadFromJsonAsync<Student>();
                            
                return View(responseStr);
            }
            else
            {               
                return HttpNotFound();
            }
        }

        // GET: Students/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Students/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Name,SurName,Age")] Student student)
        {
            if (ModelState.IsValid)
            {
                var json = JsonConvert.SerializeObject(student);
                var stringContent = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await _httpClient.PostAsync($"students", stringContent);

                if (response.IsSuccessStatusCode)
                {
                    //var responseStr = await response.Content.ReadAsStringAsync();

                    return RedirectToAction("Index");
                }
                else
                {
                    return View(student);
                }
            }

            return View(student);

        }

        // GET: Students/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HttpResponseMessage response = await _httpClient.GetAsync($"students/{id}");

            if (response.IsSuccessStatusCode)
            {
                var responseStr = await response.Content.ReadFromJsonAsync<Student>();

                return View(responseStr);
            }
            else
            {
                return HttpNotFound();
            }
        }

        // POST: Students/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Student student)
        {
            if (ModelState.IsValid)
            {

                var json = JsonConvert.SerializeObject(student);
                var stringContent = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await _httpClient.PutAsync($"students/{student.Id }", stringContent);

                if (response.IsSuccessStatusCode)
                {
                    //var responseStr = await response.Content.ReadAsStringAsync();

                    return RedirectToAction("Index");
                }
                else
                {
                    return View(student);
                }
            }
            return View(student);
        }

        // GET: Students/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HttpResponseMessage response = await _httpClient.GetAsync($"students/{id}");

            if (response.IsSuccessStatusCode)
            {
                var responseStr = await response.Content.ReadFromJsonAsync<Student>();

                return View(responseStr);
            }
            else
            {
                return HttpNotFound();
            }
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            HttpResponseMessage response = await _httpClient.DeleteAsync($"students/{id}");

            if (response.IsSuccessStatusCode)
            {
                           
                return RedirectToAction("Index");
            }
            else
            {
                return HttpNotFound();
            }
            
        }
    }
}