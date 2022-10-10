using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataAccessLayer.Models
{
    public class Medicine
    {
      //public Medicine()
      //{
      //  prescriptions = new List<Prescription>();
      //}
      [Key]
      [Required]
      public string Name { get; set; }

      [Required]
      [Range(0,1000)]
      public int Strength { get; set; }

      //public List<Prescription> prescriptions { get; set; }
    }
}
