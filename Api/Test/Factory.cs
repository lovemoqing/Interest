using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI
{
    public class Factory
    {
        public static IInternet Create()
        {
            return new OperationA();
        }
    }
}
