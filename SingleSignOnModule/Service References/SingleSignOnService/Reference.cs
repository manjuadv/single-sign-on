﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34209
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SingleSignOnModule.SingleSignOnService {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="CompositeType", Namespace="http://schemas.datacontract.org/2004/07/SSOService")]
    [System.SerializableAttribute()]
    public partial class CompositeType : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool BoolValueField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string StringValueField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool BoolValue {
            get {
                return this.BoolValueField;
            }
            set {
                if ((this.BoolValueField.Equals(value) != true)) {
                    this.BoolValueField = value;
                    this.RaisePropertyChanged("BoolValue");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string StringValue {
            get {
                return this.StringValueField;
            }
            set {
                if ((object.ReferenceEquals(this.StringValueField, value) != true)) {
                    this.StringValueField = value;
                    this.RaisePropertyChanged("StringValue");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="AuthenticatingUser", Namespace="http://schemas.datacontract.org/2004/07/SSOService")]
    [System.SerializableAttribute()]
    public partial class AuthenticatingUser : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string PasswordField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string UserNameField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Password {
            get {
                return this.PasswordField;
            }
            set {
                if ((object.ReferenceEquals(this.PasswordField, value) != true)) {
                    this.PasswordField = value;
                    this.RaisePropertyChanged("Password");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string UserName {
            get {
                return this.UserNameField;
            }
            set {
                if ((object.ReferenceEquals(this.UserNameField, value) != true)) {
                    this.UserNameField = value;
                    this.RaisePropertyChanged("UserName");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="AuthenticatedUser", Namespace="http://schemas.datacontract.org/2004/07/SSOService")]
    [System.SerializableAttribute()]
    public partial class AuthenticatedUser : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private SingleSignOnModule.SingleSignOnService.LdapUserGroup[] GroupsField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NameField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public SingleSignOnModule.SingleSignOnService.LdapUserGroup[] Groups {
            get {
                return this.GroupsField;
            }
            set {
                if ((object.ReferenceEquals(this.GroupsField, value) != true)) {
                    this.GroupsField = value;
                    this.RaisePropertyChanged("Groups");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Name {
            get {
                return this.NameField;
            }
            set {
                if ((object.ReferenceEquals(this.NameField, value) != true)) {
                    this.NameField = value;
                    this.RaisePropertyChanged("Name");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="LdapUserGroup", Namespace="http://schemas.datacontract.org/2004/07/SSOService")]
    [System.SerializableAttribute()]
    public partial class LdapUserGroup : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string GroupNameField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string GroupName {
            get {
                return this.GroupNameField;
            }
            set {
                if ((object.ReferenceEquals(this.GroupNameField, value) != true)) {
                    this.GroupNameField = value;
                    this.RaisePropertyChanged("GroupName");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="SingleSignOnService.IService1")]
    public interface IService1 {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetData", ReplyAction="http://tempuri.org/IService1/GetDataResponse")]
        string GetData(int value);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetData", ReplyAction="http://tempuri.org/IService1/GetDataResponse")]
        System.Threading.Tasks.Task<string> GetDataAsync(int value);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetDataUsingDataContract", ReplyAction="http://tempuri.org/IService1/GetDataUsingDataContractResponse")]
        SingleSignOnModule.SingleSignOnService.CompositeType GetDataUsingDataContract(SingleSignOnModule.SingleSignOnService.CompositeType composite);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetDataUsingDataContract", ReplyAction="http://tempuri.org/IService1/GetDataUsingDataContractResponse")]
        System.Threading.Tasks.Task<SingleSignOnModule.SingleSignOnService.CompositeType> GetDataUsingDataContractAsync(SingleSignOnModule.SingleSignOnService.CompositeType composite);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetSignOnToken", ReplyAction="http://tempuri.org/IService1/GetSignOnTokenResponse")]
        string GetSignOnToken(SingleSignOnModule.SingleSignOnService.AuthenticatingUser user);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetSignOnToken", ReplyAction="http://tempuri.org/IService1/GetSignOnTokenResponse")]
        System.Threading.Tasks.Task<string> GetSignOnTokenAsync(SingleSignOnModule.SingleSignOnService.AuthenticatingUser user);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetAuthenticatedUser", ReplyAction="http://tempuri.org/IService1/GetAuthenticatedUserResponse")]
        SingleSignOnModule.SingleSignOnService.AuthenticatedUser GetAuthenticatedUser(string encryptedToken);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetAuthenticatedUser", ReplyAction="http://tempuri.org/IService1/GetAuthenticatedUserResponse")]
        System.Threading.Tasks.Task<SingleSignOnModule.SingleSignOnService.AuthenticatedUser> GetAuthenticatedUserAsync(string encryptedToken);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/SignOff", ReplyAction="http://tempuri.org/IService1/SignOffResponse")]
        void SignOff(string encryptedtoken);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/SignOff", ReplyAction="http://tempuri.org/IService1/SignOffResponse")]
        System.Threading.Tasks.Task SignOffAsync(string encryptedtoken);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IService1Channel : SingleSignOnModule.SingleSignOnService.IService1, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class Service1Client : System.ServiceModel.ClientBase<SingleSignOnModule.SingleSignOnService.IService1>, SingleSignOnModule.SingleSignOnService.IService1 {
        
        public Service1Client() {
        }
        
        public Service1Client(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public Service1Client(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Service1Client(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Service1Client(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string GetData(int value) {
            return base.Channel.GetData(value);
        }
        
        public System.Threading.Tasks.Task<string> GetDataAsync(int value) {
            return base.Channel.GetDataAsync(value);
        }
        
        public SingleSignOnModule.SingleSignOnService.CompositeType GetDataUsingDataContract(SingleSignOnModule.SingleSignOnService.CompositeType composite) {
            return base.Channel.GetDataUsingDataContract(composite);
        }
        
        public System.Threading.Tasks.Task<SingleSignOnModule.SingleSignOnService.CompositeType> GetDataUsingDataContractAsync(SingleSignOnModule.SingleSignOnService.CompositeType composite) {
            return base.Channel.GetDataUsingDataContractAsync(composite);
        }
        
        public string GetSignOnToken(SingleSignOnModule.SingleSignOnService.AuthenticatingUser user) {
            return base.Channel.GetSignOnToken(user);
        }
        
        public System.Threading.Tasks.Task<string> GetSignOnTokenAsync(SingleSignOnModule.SingleSignOnService.AuthenticatingUser user) {
            return base.Channel.GetSignOnTokenAsync(user);
        }
        
        public SingleSignOnModule.SingleSignOnService.AuthenticatedUser GetAuthenticatedUser(string encryptedToken) {
            return base.Channel.GetAuthenticatedUser(encryptedToken);
        }
        
        public System.Threading.Tasks.Task<SingleSignOnModule.SingleSignOnService.AuthenticatedUser> GetAuthenticatedUserAsync(string encryptedToken) {
            return base.Channel.GetAuthenticatedUserAsync(encryptedToken);
        }
        
        public void SignOff(string encryptedtoken) {
            base.Channel.SignOff(encryptedtoken);
        }
        
        public System.Threading.Tasks.Task SignOffAsync(string encryptedtoken) {
            return base.Channel.SignOffAsync(encryptedtoken);
        }
    }
}