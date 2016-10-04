using IdentityProviderBase.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityProviderBase
{
    public abstract class AuthenticatoinProvider : IAuthenticatoinProvider
    {
        public User GetUserByIdentity(string identity)
        {
            return GetUserByIdentityExecute(identity);
        }

        public IList<UserGroup> GetUserGroups(string identity)
        {
            return GetUserGroupsExecute(identity);
        }

        public bool ValidateUser(string identity, string password)
        {
            return ValidateUserExecute(identity, password);
        }

        public IList<User> Search(string keyword)
        {
            return SearchExecute(keyword);
        }
        public void RecordUserLogin(User user,string token)
        {
            RecordUserLoginExecute(user,token);
        }
        public void LogSignInEvent(User user)
        {
            string eventMsg = DateTime.Now.ToString() + " Logged In " + user.Name;
        }
        public void LogResourceAccess(User user, string resourceUri)
        {
            string eventMsg = DateTime.Now.ToString() + " User " + user.Name + " : Accessed " + resourceUri;
        }
        public User GetAuthenticatedUserByToken(string token)
        {
            return GetAuthenticatedUserByTokenExecute(token);
        }
        public string IssueAuthenticationToken(User user)
        {
            return IssueAuthenticationTokenExecute(user);
        }
        public void KillLoginSession(string token)
        {
            KillLoginSessionExecute(token);
        }
        protected abstract User GetUserByIdentityExecute(string identity);
        protected abstract IList<UserGroup> GetUserGroupsExecute(string identity);
        protected abstract bool ValidateUserExecute(string identity, string password);
        protected abstract IList<User> SearchExecute(string keyword);
        protected abstract void RecordUserLoginExecute(User user,string token);
        protected abstract User GetAuthenticatedUserByTokenExecute(string token);
        protected abstract string IssueAuthenticationTokenExecute(User user);
        protected abstract void KillLoginSessionExecute(string identity);
        //protected abstract void LogSignInEventExecute(User user);

    }
}
