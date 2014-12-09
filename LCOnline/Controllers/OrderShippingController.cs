using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using LCOnline.Model;
using Newtonsoft.Json;

namespace LCOnline.Controllers
{
    public class OrderShippingController : Controller
    {
        // GET: OrderShipping
        public ActionResult Index()
        {
            // Load address
            int? userId = ((ShoppingCart)(TempData["ShoppingCart"])).UserAccountId;;
            Address userAddress = GetUserAddress(userId.Value).Addresses.ToList()[0];
            ViewBag.AL1 = userAddress.Address1;
            ViewBag.AL2 = userAddress.Address2;
            ViewBag.NearBy = userAddress.NearbyLandmark;
            ViewBag.City = userAddress.City;
            ViewBag.Pin = userAddress.ZipCode;
            ViewBag.ContactNo = userAddress.MobileNumber;
            ViewBag.AL1 = userAddress.Address1;
            return View();
        }

        // GET: OrderShipping/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: OrderShipping/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OrderShipping/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: OrderShipping/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: OrderShipping/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: OrderShipping/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: OrderShipping/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        private UserAccount GetUserAddress(int userId)
        {
            UserAccount userAccount = null;
             using (var client = new HttpClient())
            {
                try
                {
                    var response = client.GetAsync(string.Format("http://localhost:29779/api/UserAccounts/{0}", userId)).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        userAccount = JsonConvert.DeserializeObject<UserAccount>(response.Content.ReadAsStringAsync().Result);
                    }
                }
                catch (Exception exception)
                {

                    throw;
                }

                return userAccount;
            }
            
        }
        
    }
}
