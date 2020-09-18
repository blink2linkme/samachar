using System.ComponentModel.DataAnnotations;

namespace Samachar.Domain.ViewModels
{
    public class LoginWith2faViewModel
    {
        [DataType(DataType.Text)]
        [Display(Name = "Authenticator Code")]
        [StringLength(7, ErrorMessage = "The {0} must be at least {2} and at max {1} character long.", MinimumLength = 6)]
        public string TwoFactorCode { get; set; }
        [Display(Name = "Remember this machine")]
        public bool RememberMachine { get; set; }
        public bool RememberMe { get; set; }
        public string ReturnUrl { get; set; }
    }
}
