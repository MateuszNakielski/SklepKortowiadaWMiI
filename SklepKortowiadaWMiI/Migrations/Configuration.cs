namespace SklepKortowiadaWMiI.Migrations
{
    using System;
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
        }
    }
}
