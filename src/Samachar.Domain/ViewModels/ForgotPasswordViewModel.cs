using System.ComponentModel.DataAnnotations;

namespace Samachar.Domain.ViewModels
{
    /// <summary>
    /// Represents a view model entity of Forgot Password
    /// </summary>
    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
