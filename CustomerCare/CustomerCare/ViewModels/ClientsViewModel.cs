using CustomerCare.Models.ClientsDomain;
using CustomerCare.Services;
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
        private IDataStore<Client> _clientDS;

        public ObservableCollection<Client> Clients { get; set; }

        public Command NewClientCommand { get; set; }

        public ClientsViewModel()
        {
            Clients = new ObservableCollection<Client>();

            NewClientCommand = new Command(async () => await NewClientCommandExecute());

            _clientDS = DependencyService.Get<IDataStore<Client>>();

            Initializer();
        }

        private async Task NewClientCommandExecute()
        {
            await PushAsync<NewClientViewModel>();
        }

        private void Initializer()
        {
            var clients = _clientDS.ListAll();

            Clients.Clear();

            foreach(var client in clients)
            {
                Clients.Add(client);
            }
        }
    }
}
