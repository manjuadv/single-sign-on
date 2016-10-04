using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityProviderBase.Identity
{
    public class User
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Telphone { get; set; }
        public string Password { get; set; }
        public IList<UserGroup> UserGroups { get; set; }
        public bool IsAuthenticaed { get; set; }
    }
}
