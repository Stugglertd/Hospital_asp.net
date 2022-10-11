using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataAccessLayer.Models
{
    public class Prescription
    {
      //public Prescription()
      //{
      //  Medicine = new List<Medicine>();
      //}
      [Key]
      [Required]
      public int Id { get; set; }
      
      //[Required]
      //public Medicine Medicine { get; set; }
      [Required]
      public string MedicineName { get; set; }

      //[ForeignKey("Patient")]
      //public string PhoneNumber { get; set; }
      //[Required]
      //public Patient Patient { get; set; }
      
      [Required]
      public string PatientPhone { get; set; }

      [Required]
      public DateTime DateTime { get; set; }
    }
}
