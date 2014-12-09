using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LCOnline.DataLayer.Migrations;
using LCOnline.Model;

namespace LCOnline.DataLayer
{
    public class LCModelDBContext : DbContext
    {
        public DbSet<Address> Addresses { get; set; }

        public DbSet<CartItem> CartItems { get; set; }

        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<MenuItem> MenuItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Picture> Pictures { get; set; }
        public DbSet<QnA> QnAs { get; set; }
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }

        public DbSet<UserAccount> UserAccounts { get; set; }

        public DbSet<Offer> Offers { get; set; }

        public LCModelDBContext()
        {
            //this.
            //AutomaticMigrationDataLossAllowed = true;
            //Database.SetInitializer<LCModelDBContext>(new DropCreateDatabaseAlways<LCModelDBContext>());
            //Database.SetInitializer<LCModelDBContext>(new DropCreateDatabaseIfModelChanges<LCModelDBContext>());
            Database.SetInitializer<LCModelDBContext>(new MigrateDatabaseToLatestVersion<LCModelDBContext,Configuration>());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.a
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Entity<ShoppingCart>().HasRequired(p => p.UserAccount).WithOptional();

        }
    }
}
