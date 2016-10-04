using IdentityProviderBase;
using IdentityProviderBase.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityProvider.XmlDb
{
    public class XmlDbAuthenticationProvider : AuthenticatoinProvider 
    {
        protected override User GetUserByIdentityExecute(string identity)
        {
            XmlDbUser xmlDbUser = new XmlDbInstance().Users.FirstOrDefault(r => r.Email == identity);
            if (xmlDbUser != null)
            {
                User user = new User { Email = xmlDbUser.Email, Name = xmlDbUser.Name, Password = xmlDbUser.Password, Telphone = xmlDbUser.Telphone };
                user.UserGroups = new List<UserGroup>();
                if (xmlDbUser.UserGroups != null)
                {
                    foreach (var item in xmlDbUser.UserGroups.Split(','))
                    {
                        user.UserGroups.Add(new UserGroup { GroupName = item });
                    }
                }
                //foreach
                return user;
            }
            else
            {
                return null;
            }
        }

        protected override IList<UserGroup> GetUserGroupsExecute(string identity)
        {
            User user = GetUserByIdentityExecute(identity);
            if (user != null)
            {
                return user.UserGroups;
            }
            else
            {
                return null;
            }
        }

        protected override bool ValidateUserExecute(string identity, string password)
        {
            User user = GetUserByIdentityExecute(identity);
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
            IEnumerable<XmlDbUser> result = new XmlDbInstance().Users.Where(r => r.Name.ToLower().Contains(keyword.ToLower()));
            List<User> returnList = new List<User>();
            foreach (var xmlDbUser in result)
            {
                returnList.Add(new User { Email = xmlDbUser.Email, Name = xmlDbUser.Name, Password = xmlDbUser.Password, Telphone = xmlDbUser.Telphone });
            }
            return returnList;
        }

        protected override void RecordUserLoginExecute(User user, string token)
        {
            XmlDbInstance db = new XmlDbInstance();
            XmlDbUser xmlDbUser = db.Users.FirstOrDefault(r => r.Email == user.Email);
            if (xmlDbUser != null)
            {
                xmlDbUser.IsAuthenticaed = true;
                xmlDbUser.LoggedInToken = token;
                db.EditUser(xmlDbUser);
            }

        }

        protected override User GetAuthenticatedUserByTokenExecute(string token)
        {
            XmlDbUser xmlDbUser = new XmlDbInstance().Users.FirstOrDefault(r => r.IsAuthenticaed && r.UserID.ToString() == token);
            if (xmlDbUser != null)
            {
                User user = new User { Email = xmlDbUser.Email, Name = xmlDbUser.Name, Password = xmlDbUser.Password, Telphone = xmlDbUser.Telphone };
                user.UserGroups = new List<UserGroup>();
                if (xmlDbUser.UserGroups != null)
                {
                    foreach (var item in xmlDbUser.UserGroups.Split(','))
                    {
                        user.UserGroups.Add(new UserGroup { GroupName = item });
                    }
                }
                //foreach
                return user;
            }
            else
            {
                return null;
            }
        }

        protected override string IssueAuthenticationTokenExecute(User user)
        {
            XmlDbUser xmlDbUser = new XmlDbInstance().Users.FirstOrDefault(r => r.Email == user.Email);
            if (xmlDbUser != null)
            {
                return xmlDbUser.UserID.ToString();
            }
            return null;
        }

        protected override void KillLoginSessionExecute(string token)
        {
            XmlDbInstance db = new XmlDbInstance();
            XmlDbUser xmlDbUser = db.Users.FirstOrDefault(r => r.LoggedInToken == token);
            if (xmlDbUser != null)
            {
                xmlDbUser.IsAuthenticaed = false;
                xmlDbUser.LoggedInToken = null;
                db.EditUser(xmlDbUser);
            }
        }
    }
}
