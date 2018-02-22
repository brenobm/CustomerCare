using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerCare.Models.ClientsDomain
{
    public class Client
    {
        public string Name { get; set; }
        
        public IList<ClientArea> Areas { get; set; }

        public IList<ClientProjects> Projects { get; set; }
    }
}
