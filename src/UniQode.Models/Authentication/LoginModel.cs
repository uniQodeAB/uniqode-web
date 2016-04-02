using System.ComponentModel.DataAnnotations;

namespace UniQode.Models.Authentication
{
    public class LoginModel
    {
        [Required(ErrorMessage = "An email is required to login")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "A password is required to login")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        public string ReturnUrl { get; set; }
    }
}