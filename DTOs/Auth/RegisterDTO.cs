using System.ComponentModel.DataAnnotations;

namespace PLACTECUGHH.DTOs.Auth
{
    public class RegisterDTO
    {
        [Required(ErrorMessage = "First Name is required")]
        [Display(Name = "First Name")]
        [StringLength(15, MinimumLength = 3, ErrorMessage = "First Name must be at least {2}, and maximum {1} characters")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required")]
        [Display(Name = "Last Name")]
        [StringLength(15, MinimumLength = 3, ErrorMessage = "Last Name must be at least {2}, and maximum {1} characters")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [Display(Name = "Email")]
        [RegularExpression("^[0-9a-zA-Z]+([0-9a-zA-Z]*[-._+])*[0-9a-zA-Z]+@[0-9a-zA-Z]+([-.][0-9a-zA-Z]+)*([0-9a-zA-Z]*[.])[a-zA-Z]{2,6}$", ErrorMessage = "Invalid Email Address")]
        public string email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [Display(Name = "Password")]
        [StringLength(15, MinimumLength = 8, ErrorMessage = "Password must be at least {2}, and maximum {1} characters")]
        [RegularExpression(
            @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^A-Za-z0-9]).{8,15}$",
            ErrorMessage = "Password must contain at least one uppercase letter, one lowercase letter, one number, and one symbol"
        )]
        public string passWord { get; set; }
    }
}
