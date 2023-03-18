using System.ComponentModel.DataAnnotations;

namespace Rooydaad.Web.Models
{
    public class LoginModel
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email address")]
        public string LoginProvider { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string ProviderKey { get; set; }
    }
}
