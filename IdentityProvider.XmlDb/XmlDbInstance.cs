using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Utility;

namespace IdentityProvider.XmlDb
{
    public class XmlDbInstance
    {
        private static XmlDbInstance instance = null;
        private static readonly object writeLock = new object();
        private XmlDbSchema db;
        string userXmlDataFilePath;
        public XmlDbInstance()
        {
            //userXmlDataFilePath = ConfigurationManager.AppSettings["userXmlDataFilePath"];
            userXmlDataFilePath = System.Web.HttpContext.Current.Server.MapPath("UsersDatabase.xml");
            
            lock (writeLock)
            {
                if (!File.Exists(userXmlDataFilePath))
                {
                    db=GetInitialUserData();
                    XmlSerializationHelper.Serialize(typeof(XmlDbSchema), db, userXmlDataFilePath);
                }
                else
                {
                    db = XmlSerializationHelper.Deserialize<XmlDbSchema>(userXmlDataFilePath);
                }
            }
        }

        public void EditUser(XmlDbUser xmlDbUser)
        {
            for (int i = 0; i < Users.Count; i++)
            {
                if(Users[i].UserID==xmlDbUser.UserID)
                {
                    lock (writeLock)
                    {
                        Users[i] = xmlDbUser;
                        XmlSerializationHelper.Serialize(typeof(XmlDbSchema), db, userXmlDataFilePath);
                    }
                    break;
                }
            }
        }
        public XmlDbSchema DB { get { return db; } }
        public List<XmlDbUser> Users 
        {
            get
            {
                lock (writeLock)
                {
                    db = XmlSerializationHelper.Deserialize<XmlDbSchema>(userXmlDataFilePath);
                    return db.Users;
                }
            }
        }
        private XmlDbSchema GetInitialUserData()
        {
            List<XmlDbUser> users = new List<XmlDbUser>();
            XmlDbUser user1 = new XmlDbUser { UserID = 1, LoggedInToken = null, Name = "Manjula Ranasinghe", Email = "pathmakumaraad@gmail.com", Telphone = "0949309443", Password = "abc123" };
            user1.UserGroups = "Admin,Accountent,Everyone";
            users.Add(user1);

            XmlDbUser user2 = new XmlDbUser { UserID = 2, Name = "Holder Martin", Email = "hmatin@gmail.com", Telphone = "332323233", Password = "123abc" };
            user2.UserGroups = "Accountent,Everyone"; 
            users.Add(user2);

            XmlDbUser user3 = new XmlDbUser { UserID = 3, Name = "Michal Sukenton", Email = "msukenton@gmail.com", Telphone = "144034333", Password = "123abc" };
            user3.UserGroups = "Sales,Everyone"; 
            users.Add(user3);

            XmlDbUser user4 = new XmlDbUser { UserID = 4, Name = "Linton Kusker", Email = "lkusker@gmail.com", Telphone = "0954945333", Password = "123abc" };
            user4.UserGroups = "Accountent,Sales,Everyone"; 
            users.Add(user4);

            XmlDbSchema dbSchema = new XmlDbSchema();
            dbSchema.Users = users;

            return dbSchema;
        }

    }
}
