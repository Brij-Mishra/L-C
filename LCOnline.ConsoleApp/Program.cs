using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LCOnline.DataLayer;

namespace LCOnline.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            GetOrders();

            Console.ReadKey();
        }

        public static void GetOrders()
        {
            using (var context = new LCModelDBContext())
            {
                var orders = context.UserAccounts.ToList();
                Console.WriteLine(orders[0].FirstName);
                Console.WriteLine("Done");
            }
        }
    }
}
