using System.Collections.Generic;
using LCOnline.Model;

namespace LCOnline.DataLayer.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<LCModelDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
            
            ContextKey = "LCOnline.DataLayer.LCModelDBContext";
        }

        protected override void Seed(LCModelDBContext context)
        {
            //  This method will be called after migrating to the latest version.
            var addresses = new List<Address>
            {
                new Address()
            {
                AddressId = 1,
                Address1 = "C-1926 Second Floor",
                Address2 = "Sushant Lok -1",
                City = "Gurgaon",
                NearbyLandmark = "Near Peach Tree",
                IsDefault = true,
                MobileNumber = "111111",
                UserAccountId = 1

            }};
            var userAccounts = new List<UserAccount>()
            {
                new UserAccount()
                {
                    FirstName = "Brij",
                    LastName = "Mishra",
                    MiddleName = "Bhushan",
                    MobileNumber = "11111",
                    UserAccountName = "Brij",
                    UserPassword = "abcd"
                },
                new UserAccount()
                {
                    FirstName = "Dhananjay",
                    LastName = "Kumar",
                    MobileNumber = "22222",
                    UserAccountName = "DJ",
                    UserPassword = "abcd"
                }
            };

            var menuItems = new List<MenuItem>()
            {
                new MenuItem()
                {
                    MenuItemId = 1,
                    Name = "Litti",
                    DisplayName = "Litti",
                    DiscountPercent = 0,
                    Price = 100,
                    IsAvailable = true
                },
                new MenuItem()
                {
                    MenuItemId = 2,
                    Name = "Chokha",
                    DisplayName = "Chokha",
                    DiscountPercent = 0,
                    Price = 150,
                    IsAvailable = true
                }
            };

            var restaurant = new Restaurant()
            {
                RestaurantId = 1,
                RName = "Gazab",
                RRating = 3,
                RStar = 3,
                DiscountPrcentage = 0,

            };

            restaurant.MenuItems.Add(menuItems[0]);
            restaurant.MenuItems.Add(menuItems[1]);

            var restaurants = new List<Restaurant>()
            {
                restaurant
            };

            context.UserAccounts.AddOrUpdate(u => u.UserAccountName, userAccounts.ToArray());
            context.Restaurants.AddOrUpdate(r => r.RestaurantId, restaurants.ToArray());
            // context.Addresses.AddOrUpdate(r => r.AddressId, addresses.ToArray());
            //context.MenuItems.AddOrUpdate(m => m.MenuItemId, menuItems.ToArray());

           // //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
           // //  to avoid creating duplicate seed data. E.g.
           // //
           // //    context.People.AddOrUpdate(
           // //      p => p.FullName,
           // //      new Person { FullName = "Andrew Peters" },
           // //      new Person { FullName = "Brice Lambson" },
           // //      new Person { FullName = "Rowan Miller" }
           // //    );
           // //
        }
    }
}
