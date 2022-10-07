using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer
{
    public class DBContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source =.;Initial Catalog=Hospital;Integrated Security=true");
            }
        }

        public DbSet<Medicine> medicines { get; set; }
        public DbSet<Patient> patients { get; set; }
    }
}
