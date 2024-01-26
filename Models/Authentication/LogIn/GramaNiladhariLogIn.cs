using System.ComponentModel.DataAnnotations;

namespace serveSLhub.Models.Authentication.LogIn
{
    public class GramaNiladhariLogIn
    {
        [Required(ErrorMessage = "Email is required.")]
        [DataType(DataType.EmailAddress)]
        public string? email { get; set; }
       

        [Required(ErrorMessage = "Password is required.")]
        [DataType(DataType.Password)]
        public string? password { get; set; }
    }
}
