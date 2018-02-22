using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerCare.Models
{
    public class Authentication: ModelBase, IUser
    {
        public string Name { get; set; }
        public string AccessToken { get; set; }
        public string IdToken { get; set; }

        public string DisplayableId { get; set; }

        public string IdentityProvider { get; set; }

        public string Identifier { get; set; }
        public bool Active { get; set; }
    }
}
