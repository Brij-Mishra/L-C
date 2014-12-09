using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using LCOnline.Model;
using LCOnline.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace LCOnline.Controllers
{
    public class OrderAdminController : Controller
    {
        // GET: OrderAdmin
        public ActionResult Index()
        {
            return View();
        }

        // GET: OrderAdmin/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: OrderAdmin/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OrderAdmin/Create
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

        // GET: OrderAdmin/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: OrderAdmin/Edit/5
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

        // GET: OrderAdmin/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: OrderAdmin/Delete/5
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

        [HttpPost]
        public ActionResult UpdateOrder(OrderVM orderVm)
        {
            UpdateOrderStatus(orderVm);
            return new HttpStatusCodeResult(HttpStatusCode.OK, "Item Updated");
        }
        public ActionResult GetOrders()
        {
            
            IList<Order> orders;
            IList<OrderVM> orderVms = new List<OrderVM>();
            using (var client = new HttpClient())
            {
                try
                {
                    var response =
                        client.GetAsync(string.Format("http://localhost:29779/api/Orders")).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        orders = JsonConvert.DeserializeObject<IList<Order>>(response.Content.ReadAsStringAsync().Result);

                        foreach (var order in orders)
                        {
                            OrderVM orderVm = new OrderVM();
                            orderVm.OrderNo = order.OrderId;
                            foreach (var lineItem in order.LineItems)
                            {
                                orderVm.OrderDetails = orderVm.OrderDetails +
                                                       string.Format("{0} x {1} , ", lineItem.MenuItem.DisplayName,
                                                           lineItem.Count);
                            }

                            orderVm.OrderDetails = orderVm.OrderDetails.TrimEnd(new[] {' ', ','});
                            orderVm.Status = order.DeliveryStatus.ToString();
                            orderVm.OrderTime = order.OrderTime;
                            orderVms.Add(orderVm);
                        }
                    }
                }
                catch (Exception exception)
                {

                    throw;
                }
            }
            var settings = new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() };
            //return JsonConvert.SerializeObject(orderVms, Formatting.None, settings);
            var jsonResult = new ContentResult
            {
                Content = JsonConvert.SerializeObject(orderVms, settings),
                ContentType = "application/json"
            };

            return jsonResult;
           // return orderVms;
        }

        public bool UpdateOrderStatus(OrderVM orderVm)
        {
            bool isUpdated = false;
            using (var client = new HttpClient())
            {
                try
                {
                    Order order = GetOrderbyId(orderVm.OrderNo);
                    order.DeliveryStatus = (Enums.DeliveryStatus) Enum.Parse(typeof(Enums.DeliveryStatus), orderVm.Status);
                    order.CurrentStatusTime = DateTime.Now;
                    // TODO : Why it is needed
                    order.UserAccount = null;
                    order.Address = null;
                    order.LineItems.ToList();
                    var response =
                        client.PutAsJsonAsync(string.Format("http://localhost:29779/api/Orders/{0}", order.OrderId), order).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        isUpdated = true;
                    }
                }
                catch (Exception exception)
                {

                    throw;
                }
            }
            return isUpdated;
        }

        public Order GetOrderbyId(int orderId)
        {

            Order order = null;
            using (var client = new HttpClient())
            {
                try
                {
                    var response =
                        client.GetAsync(string.Format("http://localhost:29779/api/Orders/{0}", orderId)).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        order = JsonConvert.DeserializeObject<Order>(response.Content.ReadAsStringAsync().Result);

                    }
                }
                catch (Exception exception)
                {

                    throw;
                }
            }
            return order;
            // return orderVms;
        }
    }
}
