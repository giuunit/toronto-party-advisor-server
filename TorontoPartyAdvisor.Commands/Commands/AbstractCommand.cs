using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TorontoPartyAdvisor.Commands.Commands
{
    public class AbstractCommand
    {
        public string ToStringJson()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
