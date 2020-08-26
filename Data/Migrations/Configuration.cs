namespace Data.Migrations
{
    using Data.Models;
    using Data.Seed;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Data.Context.AppDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Data.Context.AppDbContext context)
        {
            new ClassesSeed(context);
            new StudentsSeed(context);
            new SubjectsSeed(context);
        }
    }
}
