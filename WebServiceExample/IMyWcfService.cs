using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WebServiceExample
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IMyWcfService" in both code and config file together.
    [ServiceContract]
    public interface IMyWcfService
    {
        [OperationContract]
        void DoWork();

        [OperationContract]
        int MyCalculator(int a,int b);
    }
}
