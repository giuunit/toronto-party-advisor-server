using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TorontoPartyAdvisor.Commands.Helpers
{
    public class SuccessBox : BlackBox
    {
        public Dictionary<string, object> Results { get; private set; }

        public SuccessBox()
        {
            Success = true;
            Results = new Dictionary<string, object>();
        }

        public void AddData(string name, object value)
        {
            Results.Add(name, value);
        }
    }
}
