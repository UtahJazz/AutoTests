﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.0
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ServiceTest.ServiceReference {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="User", Namespace="http://schemas.datacontract.org/2004/07/AutoTests")]
    [System.SerializableAttribute()]
    public partial class User : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int IdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string PasswordField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string UserNameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<short> UserRightsField;
        
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
        public int Id {
            get {
                return this.IdField;
            }
            set {
                if ((this.IdField.Equals(value) != true)) {
                    this.IdField = value;
                    this.RaisePropertyChanged("Id");
                }
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
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<short> UserRights {
            get {
                return this.UserRightsField;
            }
            set {
                if ((this.UserRightsField.Equals(value) != true)) {
                    this.UserRightsField = value;
                    this.RaisePropertyChanged("UserRights");
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
    [System.Runtime.Serialization.DataContractAttribute(Name="TestSet", Namespace="http://schemas.datacontract.org/2004/07/AutoTests")]
    [System.SerializableAttribute()]
    public partial class TestSet : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<short> ComplexityField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int IdField;
        
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
        public System.Nullable<short> Complexity {
            get {
                return this.ComplexityField;
            }
            set {
                if ((this.ComplexityField.Equals(value) != true)) {
                    this.ComplexityField = value;
                    this.RaisePropertyChanged("Complexity");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Id {
            get {
                return this.IdField;
            }
            set {
                if ((this.IdField.Equals(value) != true)) {
                    this.IdField = value;
                    this.RaisePropertyChanged("Id");
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
    [System.Runtime.Serialization.DataContractAttribute(Name="Test", Namespace="http://schemas.datacontract.org/2004/07/AutoTests")]
    [System.SerializableAttribute()]
    public partial class Test : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string AnswerField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Nullable<short> ComplexityField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int IdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private ServiceTest.ServiceReference.TestSet[] TestSetsField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string TextField;
        
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
        public string Answer {
            get {
                return this.AnswerField;
            }
            set {
                if ((object.ReferenceEquals(this.AnswerField, value) != true)) {
                    this.AnswerField = value;
                    this.RaisePropertyChanged("Answer");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<short> Complexity {
            get {
                return this.ComplexityField;
            }
            set {
                if ((this.ComplexityField.Equals(value) != true)) {
                    this.ComplexityField = value;
                    this.RaisePropertyChanged("Complexity");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Id {
            get {
                return this.IdField;
            }
            set {
                if ((this.IdField.Equals(value) != true)) {
                    this.IdField = value;
                    this.RaisePropertyChanged("Id");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public ServiceTest.ServiceReference.TestSet[] TestSets {
            get {
                return this.TestSetsField;
            }
            set {
                if ((object.ReferenceEquals(this.TestSetsField, value) != true)) {
                    this.TestSetsField = value;
                    this.RaisePropertyChanged("TestSets");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Text {
            get {
                return this.TextField;
            }
            set {
                if ((object.ReferenceEquals(this.TextField, value) != true)) {
                    this.TextField = value;
                    this.RaisePropertyChanged("Text");
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
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference.IUsersRegistrationService")]
    public interface IUsersRegistrationService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUsersRegistrationService/GetAllUsers", ReplyAction="http://tempuri.org/IUsersRegistrationService/GetAllUsersResponse")]
        ServiceTest.ServiceReference.User[] GetAllUsers();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUsersRegistrationService/GetAllUsers", ReplyAction="http://tempuri.org/IUsersRegistrationService/GetAllUsersResponse")]
        System.Threading.Tasks.Task<ServiceTest.ServiceReference.User[]> GetAllUsersAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUsersRegistrationService/AddUser", ReplyAction="http://tempuri.org/IUsersRegistrationService/AddUserResponse")]
        string AddUser(ServiceTest.ServiceReference.User user);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUsersRegistrationService/AddUser", ReplyAction="http://tempuri.org/IUsersRegistrationService/AddUserResponse")]
        System.Threading.Tasks.Task<string> AddUserAsync(ServiceTest.ServiceReference.User user);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUsersRegistrationService/LogIn", ReplyAction="http://tempuri.org/IUsersRegistrationService/LogInResponse")]
        string LogIn(string userName, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUsersRegistrationService/LogIn", ReplyAction="http://tempuri.org/IUsersRegistrationService/LogInResponse")]
        System.Threading.Tasks.Task<string> LogInAsync(string userName, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUsersRegistrationService/GetAllTestSets", ReplyAction="http://tempuri.org/IUsersRegistrationService/GetAllTestSetsResponse")]
        ServiceTest.ServiceReference.TestSet[] GetAllTestSets();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUsersRegistrationService/GetAllTestSets", ReplyAction="http://tempuri.org/IUsersRegistrationService/GetAllTestSetsResponse")]
        System.Threading.Tasks.Task<ServiceTest.ServiceReference.TestSet[]> GetAllTestSetsAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUsersRegistrationService/GetAllTests", ReplyAction="http://tempuri.org/IUsersRegistrationService/GetAllTestsResponse")]
        ServiceTest.ServiceReference.Test[] GetAllTests();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUsersRegistrationService/GetAllTests", ReplyAction="http://tempuri.org/IUsersRegistrationService/GetAllTestsResponse")]
        System.Threading.Tasks.Task<ServiceTest.ServiceReference.Test[]> GetAllTestsAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUsersRegistrationService/AddTest", ReplyAction="http://tempuri.org/IUsersRegistrationService/AddTestResponse")]
        string AddTest(ServiceTest.ServiceReference.Test test);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUsersRegistrationService/AddTest", ReplyAction="http://tempuri.org/IUsersRegistrationService/AddTestResponse")]
        System.Threading.Tasks.Task<string> AddTestAsync(ServiceTest.ServiceReference.Test test);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IUsersRegistrationServiceChannel : global::ServiceTest.ServiceReference.IUsersRegistrationService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class UsersRegistrationServiceClient : System.ServiceModel.ClientBase<global::ServiceTest.ServiceReference.IUsersRegistrationService>, global::ServiceTest.ServiceReference.IUsersRegistrationService {
        
        public UsersRegistrationServiceClient() {
        }
        
        public UsersRegistrationServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public UsersRegistrationServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public UsersRegistrationServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public UsersRegistrationServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public ServiceTest.ServiceReference.User[] GetAllUsers() {
            return base.Channel.GetAllUsers();
        }
        
        public System.Threading.Tasks.Task<ServiceTest.ServiceReference.User[]> GetAllUsersAsync() {
            return base.Channel.GetAllUsersAsync();
        }
        
        public string AddUser(ServiceTest.ServiceReference.User user) {
            return base.Channel.AddUser(user);
        }
        
        public System.Threading.Tasks.Task<string> AddUserAsync(ServiceTest.ServiceReference.User user) {
            return base.Channel.AddUserAsync(user);
        }
        
        public string LogIn(string userName, string password) {
            return base.Channel.LogIn(userName, password);
        }
        
        public System.Threading.Tasks.Task<string> LogInAsync(string userName, string password) {
            return base.Channel.LogInAsync(userName, password);
        }
        
        public ServiceTest.ServiceReference.TestSet[] GetAllTestSets() {
            return base.Channel.GetAllTestSets();
        }
        
        public System.Threading.Tasks.Task<ServiceTest.ServiceReference.TestSet[]> GetAllTestSetsAsync() {
            return base.Channel.GetAllTestSetsAsync();
        }
        
        public ServiceTest.ServiceReference.Test[] GetAllTests() {
            return base.Channel.GetAllTests();
        }
        
        public System.Threading.Tasks.Task<ServiceTest.ServiceReference.Test[]> GetAllTestsAsync() {
            return base.Channel.GetAllTestsAsync();
        }
        
        public string AddTest(ServiceTest.ServiceReference.Test test) {
            return base.Channel.AddTest(test);
        }
        
        public System.Threading.Tasks.Task<string> AddTestAsync(ServiceTest.ServiceReference.Test test) {
            return base.Channel.AddTestAsync(test);
        }
    }
}
