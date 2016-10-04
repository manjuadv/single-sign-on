using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityProviderBase.Identity
{
    public class UserGroup
    {
        public UserGroup ParentGroup { get; set; }
        public string GroupName { get; set; }
    }
}
