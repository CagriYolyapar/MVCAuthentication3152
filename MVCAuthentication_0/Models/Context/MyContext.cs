using MVCAuthentication_0.DesignPatterns.StrategyPattern;
using MVCAuthentication_0.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVCAuthentication_0.Models.Context
{
    public class MyContext:DbContext
    {
        public MyContext():base("MyConnection")
        {
            Database.SetInitializer(new MyInit());
        }

        public DbSet<AppUser> AppUsers { get; set; }
    }
}