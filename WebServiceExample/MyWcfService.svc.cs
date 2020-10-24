using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WebServiceExample
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "MyWcfService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select MyWcfService.svc or MyWcfService.svc.cs at the Solution Explorer and start debugging.
    public class MyWcfService : IMyWcfService
    {
        public void DoWork()
        {
        }

        public int MyCalculator(int a, int b)
        {
            return a + b;
        }
    }
}
