using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityProvider.LDAP
{
    public class LdapAuthenticatoinLog
    {
        public LdapAuthenticatoinLog()
        {
            AuthenticationLogs = new List<LdapAuthLogElement>();
        }
        public List<LdapAuthLogElement> AuthenticationLogs { get; set; }
    }
    public class LdapAuthLogElement
    {
        public string UsreName { get; set; }
        public bool IsAuthenticated { get; set; }
        public string LoggedInToken { get; set; }
    }
}
