using CustomerCare.Models.ClientsDomain;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CustomerCare.ViewModels
{
    public class ClientsViewModel: ViewModelBase
    {
        public ObservableCollection<Client> Clients { get; set; }

        public Command NewClientCommand { get; set; }

        public ClientsViewModel()
        {
            Clients = new ObservableCollection<Client>();

            NewClientCommand = new Command(async () => await NewClientCommandExecute());

            Initializer();
        }

        private async Task NewClientCommandExecute()
        {
            await PushAsync<NewClientViewModel>();
        }

        private void Initializer()
        {
            Clients.Add(new Client { Name = "MRV" });
            Clients.Add(new Client { Name = "CEMIG" });
            Clients.Add(new Client { Name = "CRC" });
            Clients.Add(new Client { Name = "ProAuto" });
        }
    }
}
