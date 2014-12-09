using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using LCOnline.Model;
using LCOnline.Models;
using Newtonsoft.Json;

namespace LCOnline.Controllers
{
    public class OrderController : Controller
    {
        // GET: Order
        public ActionResult Index()
        {
            return View();
        }

        // GET: Order/Details/5
        public ActionResult Details(int? id)
        {
            if (!id.HasValue)
            {
                id = Convert.ToInt32(TempData["ShoppingCartId"]);
            }
            ShoppingCart crt = GetShoppingCart(id.Value);

            IList<CartVM> items = crt.CartItems.Select(item => new CartVM()
            {
                CartId = item.CartItemId,
                Count = item.Count, 
                ItemName = item.MenuItem.DisplayName, 
                ItemDescription = item.MenuItem.DisplayName, 
                ShoppingCartId = crt.ShoppingCartId, 
                UnitPrice = item.MenuItem.Price, 
                CartItemPrice = item.MenuItem.Price*item.Count
            }).ToList();

            ViewBag.Item1 = crt.CartItems.ToArray()[0].MenuItem.Name;
            ViewBag.Item1Qty = crt.CartItems.ToArray()[0].Count;
            ViewBag.Item2 = crt.CartItems.ToArray()[1].MenuItem.Name;
            ViewBag.Item2Qty = crt.CartItems.ToArray()[1].Count;
            ViewBag.TotalPrice = crt.TotalPrice;
            TempData["ShoppingCart"] = crt;
            return View("Details", items);
        }

        // GET: Order/Create
        public ActionResult Create()
        {
            var cart = ((ShoppingCart)(Session["ShoppingCart"]));
            //cart.DateModified = DateTime.Now;
            //cart.ShoppingCartStatus = Enums.ShoppingCartStatus.ConvertedasOrder;
            //cart.CartItems.ToArray()[0].MenuItem = null;
            //cart.CartItems.ToArray()[1].MenuItem = null;
            //UpdateShoppingCart(cart.ShoppingCartId, cart);

            Order order = new Order();
            order.CurrentStatusTime = DateTime.Now;
            order.DeliveryStatus = Enums.DeliveryStatus.PaymentDone;
           // order.OrderId = 1;
            order.OrderTime = DateTime.Now;
            order.TotalPrice = cart.TotalPrice;
            order.UserAccountId = cart.UserAccountId.Value;
            order.AddressId = 1;
            order.OrderComment = "Order Initiated";
            cart = GetShoppingCart(cart.ShoppingCartId);
            foreach (var cartitem in cart.CartItems)
            {
                LineItem lineItem = new LineItem();
                lineItem.MenuItemId = cartitem.MenuItemId;
                lineItem.Count = cartitem.Count;
                lineItem.DateCreated = DateTime.Now;
                // TODO : Change the pricing
                lineItem.FinalPrice = cartitem.MenuItem.Price;

                order.LineItems.Add(lineItem);
            }

            PostOrder(order);

            DeleteShoppingCart(cart.ShoppingCartId);
            RedirectToAction("Index", "Test");
            return View();
        }

        // POST: Order/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                //var cart = ((ShoppingCart) (TempData["ShoppingCart"]));
                //cart.DateModified = DateTime.Now;
                //cart.ShoppingCartStatus = Enums.ShoppingCartStatus.ConvertedasOrder;
                //cart.CartItems.ToArray()[0].MenuItem = null;
                //cart.CartItems.ToArray()[1].MenuItem = null;
                //UpdateShoppingCart(cart.ShoppingCartId, cart);
                //Order order = new Order();
                //order.CurrentStatusTime = DateTime.Now;
                //order.DeliveryStatus = Enums.DeliveryStatus.PaymentDone;
                //order.OrderId = 1;
                //order.OrderTime = DateTime.Now;
                //order.ShoppingCartId = ((ShoppingCart)(TempData["ShoppingCart"])).ShoppingCartId;
                //order.TotalPrice = ((ShoppingCart)(TempData["ShoppingCart"])).TotalPrice;
                //order.UserAccountId = ((ShoppingCart)(TempData["ShoppingCart"])).UserAccountId;
                //order.AddressId = 4;

                //PostOrder(order);
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Order/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Order/Edit/5
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

        // GET: Order/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Order/Delete/5
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

        private Order GetOrder(int id)
        {
            using (var client = new HttpClient())
            {
                Order order;
                try
                {
                    //var response =
                    //    (Order)
                    //        client.GetAsync(string.Format("http://localhost:29779/api/Orders/{0}", id)).Result.Content.;
                    //if (response.IsSuccessStatusCode)
                    //{
                    //    // Get the URI of the created resource.
                    //    Uri gizmoUrl = response.Headers.Location;
                    //}
                }
                catch (Exception exception)
                {

                    throw;
                }
            }
            return new Order();
        }

        private ShoppingCart GetShoppingCart(int id)
        {
            ShoppingCart cart = null;
            using (var client = new HttpClient())
            {
                try
                {
                    var response =
                        client.GetAsync(string.Format("http://localhost:29779/api/ShoppingCarts/{0}", id)).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        cart = JsonConvert.DeserializeObject<ShoppingCart>(response.Content.ReadAsStringAsync().Result);
                    }
                }
                catch (Exception exception)
                {

                    throw;
                }
            }
            return cart;
        }

        private void PostOrder(Order order)
        {
            using (var client = new HttpClient())
            {
                try
                {


                    var response = client.PostAsJsonAsync("http://localhost:29779/api/Orders", order).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        // Get the URI of the created resource.
                        Uri gizmoUrl = response.Headers.Location;
                        TempData["OrderId"] = response.Headers.Location.Segments[response.Headers.Location.Segments.Length - 1];
                    }
                }
                catch (Exception exception)
                {

                    throw;
                }
            }
        }


        public void UpdateShoppingCart(int id, ShoppingCart updatedCart)
        {
            using (var client = new HttpClient())
            {
                try
                {
                    var response = client.PutAsJsonAsync(string.Format("http://localhost:29779/api/ShoppingCarts/{0}", id), updatedCart).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        
                    }
                }
                catch (Exception exception)
                {

                    throw;
                }
            }
        }

        private bool DeleteShoppingCart(int shoppingCartId)
        {
            bool isDeleted = false;
            using (var client = new HttpClient())
            {
                try
                {
                    var response = client.DeleteAsync(string.Format("http://localhost:29779/api/ShoppingCarts/{0}", shoppingCartId)).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        isDeleted = true;
                    }
                }
                catch (Exception exception)
                {

                    throw;
                }
            }
            return isDeleted;
        }
    }
}
