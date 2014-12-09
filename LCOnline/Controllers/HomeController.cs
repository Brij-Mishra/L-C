using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using LCOnline.Model;
using Newtonsoft.Json;

namespace LCOnline.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            return View("Index");
        }

        // GET: Test/Edit/5
        public ActionResult Edit(int id)
        {
            using (var client = new HttpClient())
            {
                try
                {

                    var response = client.GetAsync("http://localhost:29779/api/ShoppingCarts").Result;
                }
                catch (Exception exception)
                {

                    throw;
                }
            }
            return View();
        }

        private void CreateShoppingCart(ShoppingCart cart)
        {
            using (var client = new HttpClient())
            {
                try
                {
                    var response = client.PostAsJsonAsync("http://localhost:29779/api/ShoppingCarts", cart).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        // Get the URI of the created resource.
                        Uri gizmoUrl = response.Headers.Location;
                        TempData["ShoppingCartId"] = response.Headers.Location.Segments[response.Headers.Location.Segments.Length-1];
                    }
                }
                catch (Exception exception)
                {

                    throw;
                }
            }
        }

        private int GetShoppingCartId()
        {
            int shoppingCartId = 0;
            using (var client = new HttpClient())
            {
                try
                {
                    var response = client.GetAsync("http://localhost:29779/api/ShoppingCarts").Result;
                    if (response.IsSuccessStatusCode)
                    {
                        IList<ShoppingCart> shoppingCarts = JsonConvert.DeserializeObject<IList<ShoppingCart>>(response.Content.ReadAsStringAsync().Result);
                        shoppingCartId = shoppingCarts.Count == 0 ? 0 : shoppingCarts.Max(s => s.ShoppingCartId);
                    }
                }
                catch (Exception exception)
                {

                    throw;
                }

                return ++shoppingCartId;
            }
            
        }


    }
}
