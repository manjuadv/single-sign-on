using IdentityProvider.InMemoryDatabase.Objs;
using IdentityProviderBase;
using IdentityProviderBase.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityProvider.InMemoryDatabase
{
    public class InMemoryDbAuthenticationProvider : AuthenticatoinProvider
    {
        
        protected override User GetUserByIdentityExecute(string email)
        {
            return InMemoryDb.Instance.Users.FirstOrDefault(r => r.Email == email);
        }

        protected override IList<UserGroup> GetUserGroupsExecute(string email)
        {
            User user = GetUserByIdentityExecute(email);
            if (user != null)
            {
                return user.UserGroups;
            }
            else
            {
                return null;
            }
        }

        protected override bool ValidateUserExecute(string email, string password)
        {
            User user = GetUserByIdentityExecute(email);
            if (user != null)
            {
                return user.Password == password;
            }
            else
            {
                return false;
            }
        }

        protected override IList<User> SearchExecute(string keyword)
        {
            IEnumerable<User> result = InMemoryDb.Instance.Users.Where(r => r.Name.ToLower().Contains(keyword.ToLower()));
            List<User> returnList = new List<User>();
            returnList.AddRange(result);
            return returnList;
        }

        protected override void RecordUserLoginExecute(User user, string token)
        {
            InMemoryUser authenticatingUser = InMemoryDb.Instance.Users.Find(r => r.Email == user.Email);
            if (authenticatingUser != null)
            {
                authenticatingUser.IsAuthenticaed = true;
                authenticatingUser.LoggedInToken = token;
            }
        }

        protected override User GetAuthenticatedUserByTokenExecute(string token)
        {
            InMemoryUser authenticatedUser = InMemoryDb.Instance.Users.Find(r => r.IsAuthenticaed && r.LoggedInToken == token);
            return authenticatedUser;
        }

        protected override string IssueAuthenticationTokenExecute(User user)
        {
            return "21";
        }

        protected override void KillLoginSessionExecute(string token)
        {
            for (int i = 0; i < InMemoryDb.Instance.Users.Count; i++)
            {
                if (InMemoryDb.Instance.Users[i].LoggedInToken == token)
                {
                    InMemoryDb.Instance.Users[i].IsAuthenticaed = false;
                    InMemoryDb.Instance.Users[i].LoggedInToken = null;
                }
            }
        }
    }
}
