using CustomerCare.Models.ClientsDomain;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

[assembly: Dependency(typeof(CustomerCare.DataLayer.Repositories.ClientRepository))]
namespace CustomerCare.DataLayer.Repositories
{
    public class ClientRepository : RepositoryBase<Client>, IClientRepository
    {
        public ClientRepository(CustomerCareContext context) : base(context)
        {
        }
    }
}
