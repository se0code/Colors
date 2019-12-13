using Colors.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Colors.DAL.Context
{
    public class ColorContext : DbContext
    {
        public ColorContext() : base("ColorDbConnection")
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<ColorContext>());


        }


        public DbSet<ColorEntity> Colors { get; set; }


    }
}
