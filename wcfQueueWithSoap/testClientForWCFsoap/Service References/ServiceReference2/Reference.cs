﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace testClientForWCFsoap.ServiceReference2 {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference2.ITestSOAP")]
    public interface ITestSOAP {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITestSOAP/AddTwoNumbers", ReplyAction="http://tempuri.org/ITestSOAP/AddTwoNumbersResponse")]
        int AddTwoNumbers(int i1, int i2);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITestSOAP/AddTwoNumbers", ReplyAction="http://tempuri.org/ITestSOAP/AddTwoNumbersResponse")]
        System.Threading.Tasks.Task<int> AddTwoNumbersAsync(int i1, int i2);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITestSOAP/SubtractTwoNumbers", ReplyAction="http://tempuri.org/ITestSOAP/SubtractTwoNumbersResponse")]
        int SubtractTwoNumbers(int i1, int i2);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITestSOAP/SubtractTwoNumbers", ReplyAction="http://tempuri.org/ITestSOAP/SubtractTwoNumbersResponse")]
        System.Threading.Tasks.Task<int> SubtractTwoNumbersAsync(int i1, int i2);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ITestSOAPChannel : testClientForWCFsoap.ServiceReference2.ITestSOAP, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class TestSOAPClient : System.ServiceModel.ClientBase<testClientForWCFsoap.ServiceReference2.ITestSOAP>, testClientForWCFsoap.ServiceReference2.ITestSOAP {
        
        public TestSOAPClient() {
        }
        
        public TestSOAPClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public TestSOAPClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public TestSOAPClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public TestSOAPClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public int AddTwoNumbers(int i1, int i2) {
            return base.Channel.AddTwoNumbers(i1, i2);
        }
        
        public System.Threading.Tasks.Task<int> AddTwoNumbersAsync(int i1, int i2) {
            return base.Channel.AddTwoNumbersAsync(i1, i2);
        }
        
        public int SubtractTwoNumbers(int i1, int i2) {
            return base.Channel.SubtractTwoNumbers(i1, i2);
        }
        
        public System.Threading.Tasks.Task<int> SubtractTwoNumbersAsync(int i1, int i2) {
            return base.Channel.SubtractTwoNumbersAsync(i1, i2);
        }
    }
}
