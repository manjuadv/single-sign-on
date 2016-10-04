using IdentityProviderBase;
using IdentityProviderBase.Identity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.DirectoryServices;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility;

namespace IdentityProvider.LDAP
{
    public class LdapAuthenticationProvider : AuthenticatoinProvider
    {
        string xmlFilePaht = System.Web.HttpContext.Current.Server.MapPath("AuthLog.xml");
        string ldapServerURL = ConfigurationManager.AppSettings["ldapServerUrl"];
        private static readonly object authFileWriteLock = new object();

        protected override User GetUserByIdentityExecute(string identity)
        {
            if (identity == null)
                return null;

            string userRelativePath = "cn=" + identity + ",dc=example,dc=com";
            string userLdapPath = ldapServerURL + "/"+userRelativePath;
            DirectoryEntry directryEntry = new DirectoryEntry(userLdapPath, "", "", AuthenticationTypes.Anonymous);
            if (directryEntry!=null)
            {
                User user = new User();
                if (directryEntry.Properties["mail"].Count>0)
                    user.Email = directryEntry.Properties["mail"][0].ToString();
                if (directryEntry.Properties["givenName"].Count > 0)
                    user.Name = directryEntry.Properties["givenName"][0].ToString();
                if (directryEntry.Properties["telephoneNumber"].Count > 0)
                    user.Telphone = directryEntry.Properties["telephoneNumber"][0].ToString();

                user.UserGroups = GetGroups(userRelativePath);
                return user;
            }
            return null;
        }
        private List<UserGroup> GetGroups(string userLdapPath)
        {
            List<UserGroup> groupList = new List<UserGroup>();
            DirectoryEntry rootEntry = new DirectoryEntry(ldapServerURL + "/dc=example,dc=com", "", "", AuthenticationTypes.Anonymous);
            if (rootEntry != null)
            {
                DirectorySearcher groups = new DirectorySearcher(rootEntry, "(ou=" + "*" + ")");
                if (groups != null)
                {
                    SearchResultCollection roupRes = groups.FindAll();
                    for (int i = 0; i < roupRes.Count; i++)
                    {
                        if (roupRes[i].Properties != null)
                        {
                            for (int j = 0; j < roupRes[i].Properties["uniqueMember"].Count; j++)
                            {
                                string memberPath = roupRes[i].Properties["uniqueMember"][j].ToString();
                                if(memberPath.Trim()==userLdapPath.Trim())
                                {
                                    string groupName = roupRes[i].Properties["cn"][0].ToString();
                                    groupList.Add(new UserGroup { GroupName = groupName });
                                }
                            }
                        }
                    }
                }
            }
            return groupList;
        }
        protected override IList<UserGroup> GetUserGroupsExecute(string identity)
        {
            string userLdapPath = ldapServerURL + "/cn=" + identity + ",dc=example,dc=com";
            return GetGroups(userLdapPath);
        }

        protected override bool ValidateUserExecute(string identity, string password)
        {
            return GetUserByIdentityExecute(identity) != null;
        }

        protected override IList<User> SearchExecute(string keyword)
        {
            throw new NotImplementedException();
        }

        protected override void RecordUserLoginExecute(User user, string token)
        {
            WriteLogInRecord(user.Name, token);
        }

        protected override User GetAuthenticatedUserByTokenExecute(string token)
        {
            string identity=GetUserIdentityByToken(token);
            return GetUserByIdentity(identity);
        }

        protected override string IssueAuthenticationTokenExecute(User user)
        {
            return DateTime.Now.Ticks.ToString();
        }

        protected override void KillLoginSessionExecute(string token)
        {
            WriteLogOutRecord(token);
        }
        private string GetUserIdentityByToken(string token)
        {
            LdapAuthenticatoinLog log;
            lock (authFileWriteLock)
            {
                if (!File.Exists(xmlFilePaht))
                {
                    return null;
                }
                else
                {
                    log = XmlSerializationHelper.Deserialize<LdapAuthenticatoinLog>(xmlFilePaht);
                    
                    for (int i = 0; i < log.AuthenticationLogs.Count; i++)
                    {
                        if (log.AuthenticationLogs[i].LoggedInToken == token)
                        {
                            return log.AuthenticationLogs[i].UsreName;
                        }
                    }
                    return null;
                }
            }
        }
        private LdapAuthenticatoinLog GetAuthLog()
        {
            LdapAuthenticatoinLog log;
            lock (authFileWriteLock)
            {
                if (!File.Exists(xmlFilePaht))
                {
                    log = new LdapAuthenticatoinLog();
                    XmlSerializationHelper.Serialize(typeof(LdapAuthenticatoinLog), log, xmlFilePaht);
                }
                else
                {
                    log = XmlSerializationHelper.Deserialize<LdapAuthenticatoinLog>(xmlFilePaht);
                }
                return log;
            }
        }
        private void WriteLogInRecord(string  userName,string token)
        {
            WriteAuthLog(userName, token, true);
        }
        private void WriteLogOutRecord(string token)
        {
            LdapAuthenticatoinLog log;
            lock (authFileWriteLock)
            {
                if (File.Exists(xmlFilePaht))
                {
                    log = XmlSerializationHelper.Deserialize<LdapAuthenticatoinLog>(xmlFilePaht);
                    for (int i = 0; i < log.AuthenticationLogs.Count; i++)
                    {
                        if (log.AuthenticationLogs[i].LoggedInToken == token)
                        {
                            log.AuthenticationLogs.RemoveAt(i);
                            break;
                        }
                    }
                    XmlSerializationHelper.Serialize(typeof(LdapAuthenticatoinLog), log, xmlFilePaht);
                }
            }
        }
        private void WriteAuthLog(string  userName,string token, bool authenticated)
        {
            LdapAuthenticatoinLog log;
            lock (authFileWriteLock)
            {
                if (!File.Exists(xmlFilePaht))
                {
                    log = new LdapAuthenticatoinLog();
                    log.AuthenticationLogs.Add(new LdapAuthLogElement { UsreName = userName, IsAuthenticated = authenticated, LoggedInToken = token });
                    XmlSerializationHelper.Serialize(typeof(LdapAuthenticatoinLog), log, xmlFilePaht);
                }
                else
                {
                    log = XmlSerializationHelper.Deserialize<LdapAuthenticatoinLog>(xmlFilePaht);
                    bool recordFound = false;
                    for (int i = 0; i < log.AuthenticationLogs.Count; i++)
                    {
                        if (log.AuthenticationLogs[i].UsreName == userName)
                        {
                            log.AuthenticationLogs[i].IsAuthenticated = authenticated;
                            log.AuthenticationLogs[i].LoggedInToken = token;
                            recordFound = true;
                            break;
                        }
                    }
                    if (!recordFound)
                    {
                        log = new LdapAuthenticatoinLog();
                        log.AuthenticationLogs.Add(new LdapAuthLogElement { UsreName = userName, IsAuthenticated = authenticated, LoggedInToken = token });
                    }
                }
                XmlSerializationHelper.Serialize(typeof(LdapAuthenticatoinLog), log, xmlFilePaht);
            }
        }
    }
}
