﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WinFormsSpaghetti.CrmRepositoryService {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Company", Namespace="http://schemas.datacontract.org/2004/07/Contracts")]
    [System.SerializableAttribute()]
    public partial class Company : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private WinFormsSpaghetti.CrmRepositoryService.Employee[] EmployeesField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private long IdField;
        
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
        public WinFormsSpaghetti.CrmRepositoryService.Employee[] Employees {
            get {
                return this.EmployeesField;
            }
            set {
                if ((object.ReferenceEquals(this.EmployeesField, value) != true)) {
                    this.EmployeesField = value;
                    this.RaisePropertyChanged("Employees");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public long Id {
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
    [System.Runtime.Serialization.DataContractAttribute(Name="Employee", Namespace="http://schemas.datacontract.org/2004/07/Contracts")]
    [System.SerializableAttribute()]
    public partial class Employee : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private long IdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string SurnameField;
        
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
        public long Id {
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
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Surname {
            get {
                return this.SurnameField;
            }
            set {
                if ((object.ReferenceEquals(this.SurnameField, value) != true)) {
                    this.SurnameField = value;
                    this.RaisePropertyChanged("Surname");
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
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="CrmRepositoryService.ICRMRepository", CallbackContract=typeof(WinFormsSpaghetti.CrmRepositoryService.ICRMRepositoryCallback))]
    public interface ICRMRepository {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICRMRepository/GetAllCompanies", ReplyAction="http://tempuri.org/ICRMRepository/GetAllCompaniesResponse")]
        WinFormsSpaghetti.CrmRepositoryService.Company[] GetAllCompanies();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICRMRepository/GetAllCompanies", ReplyAction="http://tempuri.org/ICRMRepository/GetAllCompaniesResponse")]
        System.Threading.Tasks.Task<WinFormsSpaghetti.CrmRepositoryService.Company[]> GetAllCompaniesAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICRMRepository/GetAllEmployees", ReplyAction="http://tempuri.org/ICRMRepository/GetAllEmployeesResponse")]
        WinFormsSpaghetti.CrmRepositoryService.Employee[] GetAllEmployees();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICRMRepository/GetAllEmployees", ReplyAction="http://tempuri.org/ICRMRepository/GetAllEmployeesResponse")]
        System.Threading.Tasks.Task<WinFormsSpaghetti.CrmRepositoryService.Employee[]> GetAllEmployeesAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICRMRepository/GetEmployeesByCompany", ReplyAction="http://tempuri.org/ICRMRepository/GetEmployeesByCompanyResponse")]
        WinFormsSpaghetti.CrmRepositoryService.Employee[] GetEmployeesByCompany(string companyName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICRMRepository/GetEmployeesByCompany", ReplyAction="http://tempuri.org/ICRMRepository/GetEmployeesByCompanyResponse")]
        System.Threading.Tasks.Task<WinFormsSpaghetti.CrmRepositoryService.Employee[]> GetEmployeesByCompanyAsync(string companyName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICRMRepository/AddCompany", ReplyAction="http://tempuri.org/ICRMRepository/AddCompanyResponse")]
        void AddCompany(WinFormsSpaghetti.CrmRepositoryService.Company company);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICRMRepository/AddCompany", ReplyAction="http://tempuri.org/ICRMRepository/AddCompanyResponse")]
        System.Threading.Tasks.Task AddCompanyAsync(WinFormsSpaghetti.CrmRepositoryService.Company company);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICRMRepository/AddEmployee", ReplyAction="http://tempuri.org/ICRMRepository/AddEmployeeResponse")]
        void AddEmployee(WinFormsSpaghetti.CrmRepositoryService.Employee employee);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICRMRepository/AddEmployee", ReplyAction="http://tempuri.org/ICRMRepository/AddEmployeeResponse")]
        System.Threading.Tasks.Task AddEmployeeAsync(WinFormsSpaghetti.CrmRepositoryService.Employee employee);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICRMRepository/AddEmployeeToCompany", ReplyAction="http://tempuri.org/ICRMRepository/AddEmployeeToCompanyResponse")]
        void AddEmployeeToCompany(WinFormsSpaghetti.CrmRepositoryService.Employee employee, WinFormsSpaghetti.CrmRepositoryService.Company company);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICRMRepository/AddEmployeeToCompany", ReplyAction="http://tempuri.org/ICRMRepository/AddEmployeeToCompanyResponse")]
        System.Threading.Tasks.Task AddEmployeeToCompanyAsync(WinFormsSpaghetti.CrmRepositoryService.Employee employee, WinFormsSpaghetti.CrmRepositoryService.Company company);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/ICRMRepository/KeepAlive")]
        void KeepAlive();
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/ICRMRepository/KeepAlive")]
        System.Threading.Tasks.Task KeepAliveAsync();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ICRMRepositoryCallback {
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/ICRMRepository/Signal")]
        void Signal();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ICRMRepositoryChannel : WinFormsSpaghetti.CrmRepositoryService.ICRMRepository, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class CRMRepositoryClient : System.ServiceModel.DuplexClientBase<WinFormsSpaghetti.CrmRepositoryService.ICRMRepository>, WinFormsSpaghetti.CrmRepositoryService.ICRMRepository {
        
        public CRMRepositoryClient(System.ServiceModel.InstanceContext callbackInstance) : 
                base(callbackInstance) {
        }
        
        public CRMRepositoryClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName) : 
                base(callbackInstance, endpointConfigurationName) {
        }
        
        public CRMRepositoryClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, string remoteAddress) : 
                base(callbackInstance, endpointConfigurationName, remoteAddress) {
        }
        
        public CRMRepositoryClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(callbackInstance, endpointConfigurationName, remoteAddress) {
        }
        
        public CRMRepositoryClient(System.ServiceModel.InstanceContext callbackInstance, System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(callbackInstance, binding, remoteAddress) {
        }
        
        public WinFormsSpaghetti.CrmRepositoryService.Company[] GetAllCompanies() {
            return base.Channel.GetAllCompanies();
        }
        
        public System.Threading.Tasks.Task<WinFormsSpaghetti.CrmRepositoryService.Company[]> GetAllCompaniesAsync() {
            return base.Channel.GetAllCompaniesAsync();
        }
        
        public WinFormsSpaghetti.CrmRepositoryService.Employee[] GetAllEmployees() {
            return base.Channel.GetAllEmployees();
        }
        
        public System.Threading.Tasks.Task<WinFormsSpaghetti.CrmRepositoryService.Employee[]> GetAllEmployeesAsync() {
            return base.Channel.GetAllEmployeesAsync();
        }
        
        public WinFormsSpaghetti.CrmRepositoryService.Employee[] GetEmployeesByCompany(string companyName) {
            return base.Channel.GetEmployeesByCompany(companyName);
        }
        
        public System.Threading.Tasks.Task<WinFormsSpaghetti.CrmRepositoryService.Employee[]> GetEmployeesByCompanyAsync(string companyName) {
            return base.Channel.GetEmployeesByCompanyAsync(companyName);
        }
        
        public void AddCompany(WinFormsSpaghetti.CrmRepositoryService.Company company) {
            base.Channel.AddCompany(company);
        }
        
        public System.Threading.Tasks.Task AddCompanyAsync(WinFormsSpaghetti.CrmRepositoryService.Company company) {
            return base.Channel.AddCompanyAsync(company);
        }
        
        public void AddEmployee(WinFormsSpaghetti.CrmRepositoryService.Employee employee) {
            base.Channel.AddEmployee(employee);
        }
        
        public System.Threading.Tasks.Task AddEmployeeAsync(WinFormsSpaghetti.CrmRepositoryService.Employee employee) {
            return base.Channel.AddEmployeeAsync(employee);
        }
        
        public void AddEmployeeToCompany(WinFormsSpaghetti.CrmRepositoryService.Employee employee, WinFormsSpaghetti.CrmRepositoryService.Company company) {
            base.Channel.AddEmployeeToCompany(employee, company);
        }
        
        public System.Threading.Tasks.Task AddEmployeeToCompanyAsync(WinFormsSpaghetti.CrmRepositoryService.Employee employee, WinFormsSpaghetti.CrmRepositoryService.Company company) {
            return base.Channel.AddEmployeeToCompanyAsync(employee, company);
        }
        
        public void KeepAlive() {
            base.Channel.KeepAlive();
        }
        
        public System.Threading.Tasks.Task KeepAliveAsync() {
            return base.Channel.KeepAliveAsync();
        }
    }
}
