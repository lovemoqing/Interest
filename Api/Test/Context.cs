using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI
{
    public class Context
    {
        private IInternet _internet;
        public Context(IInternet internet)
        {
            _internet = internet;
        }
        public void Execute()
        {
            _internet.Charge();
        }
    }
}
