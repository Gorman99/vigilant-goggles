using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApplication.Storage.Entities;

namespace WebApplication.Storage.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() : base("StringDBContext")
        {
            
        }

        public DbSet<Student> Students { get; set; }
    }
}