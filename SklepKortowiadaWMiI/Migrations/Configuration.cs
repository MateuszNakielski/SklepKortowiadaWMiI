namespace SklepKortowiadaWMiI.Migrations
{
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<SklepKortowiadaWMiI.Models.SklepKortowiadaWMiIContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(SklepKortowiadaWMiI.Models.SklepKortowiadaWMiIContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            var products = new List<Product>()
            {
                new Product() { Name = "Tomato Soup", Price = 1.39M},
                new Product() { Name = "Hammer", Price = 16.99M},
                new Product() { Name = "Yo yo", Price = 6.99M}
            };
            var order = new Order() { Name = "Bob" };
            var od = new List<OrderDetail>()
            {
                new OrderDetail() { Product = products[0], Quantity = 2, Order = order},
                new OrderDetail() { Product = products[1], Quantity = 4, Order = order }
            };
            context.Orders.Add(order);
            od.ForEach(o => context.OrderDetails.Add(o));
        }
    }
}
