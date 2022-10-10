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
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Prescription>()
        //               .HasOne<Medicine>(u => u.Medicine);
        //               //.WithOne(m => m.Presc)
        //               //.HasForeignKey<Memberships>(fk => fk.EmailId);
        //}
        public DbSet<Medicine> medicines { get; set; }
        public DbSet<Patient> patients { get; set; }
        public DbSet<Prescription> prescriptions { get; set; }
    }
}
