using System.Threading.Tasks;

namespace CustomerCare.Helpers
{
    public interface IMessageService
    {
        Task ShowAsync(string title, string message);
    }
}
