using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApplication.Api.Storage.Entities;

namespace WebApplication.Api.Storage
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() : base("StringDBContext")
        {

        }

        public DbSet<Student> Students { get; set; }
    }
}