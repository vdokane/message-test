﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace testClientForWCFsoap.ServiceReference1 {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="SampleMessage", Namespace="http://schemas.datacontract.org/2004/07/wcfQueueTest")]
    [System.SerializableAttribute()]
    public partial class SampleMessage : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string BusinessKeyField;
        
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
        public string BusinessKey {
            get {
                return this.BusinessKeyField;
            }
            set {
                if ((object.ReferenceEquals(this.BusinessKeyField, value) != true)) {
                    this.BusinessKeyField = value;
                    this.RaisePropertyChanged("BusinessKey");
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
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference1.IMessageServicer")]
    public interface IMessageServicer {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMessageServicer/GetMessage", ReplyAction="http://tempuri.org/IMessageServicer/GetMessageResponse")]
        string GetMessage(testClientForWCFsoap.ServiceReference1.SampleMessage sampleMessage);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMessageServicer/GetMessage", ReplyAction="http://tempuri.org/IMessageServicer/GetMessageResponse")]
        System.Threading.Tasks.Task<string> GetMessageAsync(testClientForWCFsoap.ServiceReference1.SampleMessage sampleMessage);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IMessageServicerChannel : testClientForWCFsoap.ServiceReference1.IMessageServicer, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class MessageServicerClient : System.ServiceModel.ClientBase<testClientForWCFsoap.ServiceReference1.IMessageServicer>, testClientForWCFsoap.ServiceReference1.IMessageServicer {
        
        public MessageServicerClient() {
        }
        
        public MessageServicerClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public MessageServicerClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public MessageServicerClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public MessageServicerClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string GetMessage(testClientForWCFsoap.ServiceReference1.SampleMessage sampleMessage) {
            return base.Channel.GetMessage(sampleMessage);
        }
        
        public System.Threading.Tasks.Task<string> GetMessageAsync(testClientForWCFsoap.ServiceReference1.SampleMessage sampleMessage) {
            return base.Channel.GetMessageAsync(sampleMessage);
        }
    }
}
