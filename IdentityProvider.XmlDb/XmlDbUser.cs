using IdentityProviderBase.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityProvider.XmlDb
{
    public class XmlDbUser 
    {
        public int UserID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Telphone { get; set; }
        public string Password { get; set; }
        public string UserGroups { get; set; }
        public bool IsAuthenticaed { get; set; }
        public string LoggedInToken { get; set; }
    }
}
