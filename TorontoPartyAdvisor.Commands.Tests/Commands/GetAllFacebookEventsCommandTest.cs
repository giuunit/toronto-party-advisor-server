using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TorontoPartyAdvisor.Commands.Commands;

namespace TorontoPartyAdvisor.Commands.Tests.Commands
{
    [TestClass]
    public class GetAllFacebookEventsCommandTest
    {
        [TestMethod]
        public void Execute()
        {
            var cmd = new GetAllFacebookEventsCommand()
            {
                AccessTokenArgs = "CAACEdEose0cBAF8ehdz630uwq2kDBtZCemeKtWbtjz68ZBeb0MZAxQGrsf9LN9o4VZB3UB6qVbJnlRTNLxyHNhlx2fmlMxEbcGGniFZAntHMj9YmSwTgrTkDazSaxO30LCyIsPy2qA3PikZCxPQxZBPGZBhfNxHxXHPglMdYp6mEKMOimXX9DUe0TxWTzT0Vu7nzPAzv0Pal1AZDZD"
            };

            cmd.Execute();

            var list = cmd.Results.ToList();

            Assert.IsNotNull(list);
        }
    }
}
