using System.Threading.Tasks;

namespace TuRM.User.Services
{
    public interface ISmsSender
    {
        Task SendSmsAsync(string number, string message);
    }
}
