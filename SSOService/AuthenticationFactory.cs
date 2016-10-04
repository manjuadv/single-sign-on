using IdentityProviderBase;
using IdentityProviderBase.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SSOService
{
    public class AuthenticationFactory
    {
        IAuthenticatoinProvider authenticationProver;
        public AuthenticationFactory(IAuthenticatoinProvider authenticationProver)
        {
            this.authenticationProver = authenticationProver;
        }
        public void RecordLogIn(User user,string token)
        {
            authenticationProver.RecordUserLogin(user,token);
        }
        public void LogSucceeded(User user, string token)
        {
            authenticationProver.LogSignInEvent(user);
        }
        public User GetAuthenticatedUsre(string token)
        {
            return authenticationProver.GetAuthenticatedUserByToken(token);
        }
        public string IssueToken(User user)
        {
            return authenticationProver.IssueAuthenticationToken(user);
        }
        public void SignOff(string token)
        {
            //User user = authenticationProver.GetAuthenticatedUserByToken(token);
            authenticationProver.KillLoginSession(token);
        }
        public bool ValidateUser(string userName, string password)
        {
            return authenticationProver.ValidateUser(userName, password);
        }
    }
}