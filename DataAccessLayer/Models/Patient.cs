using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataAccessLayer.Models
{
    public class Patient
    {
      [Key]
      [DataType(DataType.PhoneNumber)]
      [Display(Name = "Phone Number")]
      [Required(ErrorMessage = "Phone Number Required!")]
      [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$",
                   ErrorMessage = "Entered phone format is not valid.")]
      public string PhoneNumber { get; set; }

      [Required(ErrorMessage = "Please enter name"), MaxLength(30)]
      public string Name { get; set; }

      [Required]
      [Range(1,100, ErrorMessage = "Please enter between 1 and 100")]
      public int Age { get; set; }

      [Required]
      [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail is not valid")]
      public string Email { get; set; }

      [Required]
      public string Address { get; set; }
    }
}
