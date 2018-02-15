using System.Threading.Tasks;
using Xamarin.Forms;

[assembly: Dependency(typeof(CustomerCare.Helpers.MessageService))]
namespace CustomerCare.Helpers
{
    public class MessageService : IMessageService
    {
        public async Task ShowAsync(string title, string message)
        {
            await App.Current.MainPage.DisplayAlert(title, message, "ok");
        }
    }
}
