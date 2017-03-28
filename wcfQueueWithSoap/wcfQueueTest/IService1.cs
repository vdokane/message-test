using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace wcfQueueTest
{
    #region sample code that came with WCF
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        string GetData(int value);

        [OperationContract]
        CompositeType GetDataUsingDataContract(CompositeType composite);

        // TODO: Add your service operations here
    }
    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    // You can add XSD files into the project. After building the project, you can directly use the data types defined there, with the namespace "wcfQueueTest.ContractType".

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
    #endregion


    #region my code for a sample message
    [ServiceContract]
    public interface IMessageServicer
    {
        [OperationContract]
        string GetMessage(SampleMessage sampleMessage);
    }

    [ServiceContract]
    public interface ITestSOAP
    {
        [OperationContract]
        int AddTwoNumbers(int i1, int i2);

        [OperationContract]
        int SubtractTwoNumbers(int i1, int i2);

    }

   

    [DataContract]
    public class SampleMessage
    {
        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string BusinessKey { get; set; }

    }

    #endregion

}
