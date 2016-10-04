using IdentityProvider.InMemoryDatabase.Objs;
using IdentityProviderBase.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityProvider.InMemoryDatabase
{
    public class InMemoryDb
    {
        private static InMemoryDb instance = null;
        private static readonly object padlock = new object();
        private static List<InMemoryUser> users;
        private static int tokenCounter;
        InMemoryDb()
        {
            users = new List<InMemoryUser>();
            InMemoryUser user1 = new InMemoryUser { Name = "Manjula Ranasinghe", Email = "pathmakumaraad@gmail.com", Telphone = "0949309443", Password = "abc123",LoggedInToken="21",IsAuthenticaed=true };
            user1.UserGroups = new List<UserGroup>();
            user1.UserGroups.Add(new UserGroup { GroupName = "Admin" });
            user1.UserGroups.Add(new UserGroup { GroupName = "Accountent" });
            user1.UserGroups.Add(new UserGroup { GroupName = "Everyone" });
            users.Add(user1);

            InMemoryUser user2 = new InMemoryUser { Name = "Holder Martin", Email = "hmatin@gmail.com", Telphone = "332323233", Password = "123abc", LoggedInToken = "22", IsAuthenticaed = true };
            user2.UserGroups = new List<UserGroup>();
            user2.UserGroups.Add(new UserGroup { GroupName = "Accountent" });
            user2.UserGroups.Add(new UserGroup { GroupName = "Everyone" });
            users.Add(user2);

            InMemoryUser user3 = new InMemoryUser { Name = "Michal Sukenton", Email = "msukenton@gmail.com", Telphone = "144034333", Password = "123abc", LoggedInToken = "23", IsAuthenticaed = true };
            user3.UserGroups = new List<UserGroup>();
            user3.UserGroups.Add(new UserGroup { GroupName = "Sales" });
            user3.UserGroups.Add(new UserGroup { GroupName = "Everyone" });
            users.Add(user3);

            InMemoryUser user4 = new InMemoryUser { Name = "Linton Kusker", Email = "lkusker@gmail.com", Telphone = "0954945333", Password = "123abc", LoggedInToken = "24", IsAuthenticaed = true };
            user4.UserGroups = new List<UserGroup>();
            user4.UserGroups.Add(new UserGroup { GroupName = "Sales" });
            user4.UserGroups.Add(new UserGroup { GroupName = "Accountent" });
            user4.UserGroups.Add(new UserGroup { GroupName = "Everyone" });
            users.Add(user4);
        }

        public static InMemoryDb Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (padlock)
                    {
                        if (instance == null)
                        {
                            instance = new InMemoryDb();
                        }
                    }
                }
                return instance;
            }
        }
        public List<InMemoryUser> Users
        {
            get
            {
                return users;
            }
        }
        public int TokenCounter { get { return tokenCounter++; } }
    }
}
