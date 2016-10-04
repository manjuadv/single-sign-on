using IdentityProviderBase.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using Utility;

namespace SSOService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }
        public string GetSignOnToken(AuthenticatingUser user)
        {          
            User authUser = new User { Email = user.UserName, Name = user.UserName, Password = user.Password };

            string authTicketVal = AuthProviderProxy.GetAuthProvider().IssueToken(authUser);
            if (!string.IsNullOrEmpty(authTicketVal))
            {
                AuthProviderProxy.GetAuthProvider().RecordLogIn(authUser, authTicketVal);
                AuthProviderProxy.GetAuthProvider().LogSucceeded(authUser, authTicketVal);
                return CryptoHelper.Encrypt(authTicketVal, "abc123");
            }
            else
            {
                return null;
            }
        }
        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }


        public AuthenticatedUser GetAuthenticatedUser(string encryptedToken)
        {
            string token = CryptoHelper.Decrypt(encryptedToken, "abc123");

            User user = AuthProviderProxy.GetAuthProvider().GetAuthenticatedUsre(token);
            if (user != null)
            {
                AuthenticatedUser authenticatedUser = new AuthenticatedUser { Name = user.Name };
                authenticatedUser.Groups = new List<LdapUserGroup>();
                foreach (UserGroup group in user.UserGroups)
                {
                    authenticatedUser.Groups.Add(new LdapUserGroup { GroupName = group.GroupName });
                }
                return authenticatedUser;
            }
            else
            {
                return null;
            }
        }
        public void SignOff(string encryptedToken)
        {
            string token = CryptoHelper.Decrypt(encryptedToken, "abc123");
            AuthProviderProxy.GetAuthProvider().SignOff(token);
        }
        public bool ValidateUser(string userName, string password)
        {
            return AuthProviderProxy.GetAuthProvider().ValidateUser(userName, password);
        }
    }
}
