using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataAccessLayer.Models
{
    public class Medicine
    {
      [Key]
      [Required]
      public string Name { get; set; }

      [Required]
      [Range(0,1000)]
      public int Strength { get; set; }
    }
}
