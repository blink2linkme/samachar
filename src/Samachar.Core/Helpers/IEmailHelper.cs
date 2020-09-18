using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace Samachar.Core.Helper
{
    /// <summary>
    /// Represents a helper for Email Processing
    /// </summary>
    public interface IEmailHelper
    {
        Task SendEmailAsync(string email, string subject, string message);
    }

    public class EmailHelper : IEmailHelper
    {
        private readonly ILogger<EmailHelper> _logger;
        public EmailHelper(ILogger<EmailHelper> logger)
        {
            this._logger = logger;
        }
        public Task SendEmailAsync(string email, string subject, string message)
        {
            _logger.LogInformation($"Email : {email}, subject : {subject}, message : {message}");
            return Task.CompletedTask;
        }
    }
}