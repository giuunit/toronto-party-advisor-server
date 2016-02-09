using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TorontoPartyAdvisor.Commands.CommandResults
{
    public class GetUserInfoCommandResults
    {
        public int Points { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FacebookId { get; set; }
        public string Gender { get; set; }
    }
}
