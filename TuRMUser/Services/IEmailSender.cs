using System.Threading.Tasks;

namespace TuRM.User.Services
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string message);
    }
}
