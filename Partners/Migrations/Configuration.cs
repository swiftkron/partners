namespace Partners.Migrations
{
    using Partners.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Partners.DAL.PartnerContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

    }
}