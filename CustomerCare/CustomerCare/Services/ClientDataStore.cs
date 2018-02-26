using CustomerCare.Models.ClientsDomain;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

[assembly: Dependency(typeof(CustomerCare.Services.ClientDataStore))]
namespace CustomerCare.Services
{
    public class ClientDataStore: DataStore<Client>, IDataStore<Client>
    {
        public ClientDataStore() : base()
        {
            _repository = _uow.Client;
        }
    }
}
