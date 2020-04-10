using System.ComponentModel.DataAnnotations;
using Tasky2.Entities;

namespace Tasky2.Models
{
    public class RegistrationViewModel
    {
        [DataType(DataType.EmailAddress), Required]
        public string Email { get; set; }

        [DataType(DataType.Text), Required, Display(Name = "First Name")]
        public string FirstName { get; set; }

        [DataType(DataType.Text), Required, Display(Name = "Last Name")]
        public string LastName { get; set; }
        
        [DataType(DataType.Password), Required, Compare("ConfirmPassword")]
        public string Password { get; set; }

        [DataType(DataType.Password), Required, Display(Name = "Confirm Password")]
        public string ConfirmPassword { get; set; }
    }
}
