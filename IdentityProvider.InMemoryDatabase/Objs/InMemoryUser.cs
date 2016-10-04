using IdentityProviderBase.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityProvider.InMemoryDatabase.Objs
{
    public class InMemoryUser : User
    {
        //public bool IsLogedIn { get; set; }
        public string LoggedInToken { get; set; }
    }
}
