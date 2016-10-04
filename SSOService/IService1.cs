using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace SSOService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {

        [OperationContract]
        string GetData(int value);

        [OperationContract]
        CompositeType GetDataUsingDataContract(CompositeType composite);
        [OperationContract]
        string GetSignOnToken(AuthenticatingUser user);
        // TODO: Add your service operations here
        [OperationContract]
        AuthenticatedUser GetAuthenticatedUser(string encryptedToken);
        [OperationContract]
        void SignOff(string encryptedtoken);
        [OperationContract]
        bool ValidateUser(string userName, string password);
    }
    [DataContract]
    public class AuthenticatingUser
    {
        string userName;
        string password;

        [DataMember]
        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }

        [DataMember]
        public string Password
        {
            get { return password; }
            set { password = value; }
        }
    }
    [DataContract]
    public class AuthenticatedUser
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public List<LdapUserGroup> Groups { get; set; }        
    }
    [DataContract]
    public class LdapUserGroup
    {
        [DataMember]
        public string GroupName { get; set; }
    }
    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class CompositeType
    {
        bool boolValue = true;
        string stringValue = "Hello ";

        [DataMember]
        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; }
        }

        [DataMember]
        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }
    }
}
