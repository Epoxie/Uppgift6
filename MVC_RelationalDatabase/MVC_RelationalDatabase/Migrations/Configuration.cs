namespace MVC_RelationalDatabase.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using MVC_RelationalDatabase.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<MVC_RelationalDatabase.DataAccess.SchoolContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(MVC_RelationalDatabase.DataAccess.SchoolContext context)
        {
            context.Courses.AddOrUpdate(
                I => I.Subject,
                new Course { Subject = "English" },
                new Course { Subject = "Psychology" },
                new Course { Subject = "Maths" }
            );
            context.Teachers.AddOrUpdate(
                I => I.Name,
                new Teacher { Name = "Gustavo" },
                new Teacher { Name = "Stefan" },
                new Teacher { Name = "Ernst"}
            );
        }
    }
}
