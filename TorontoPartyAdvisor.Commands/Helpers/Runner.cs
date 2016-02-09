using log4net;
using log4net.Config;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TorontoPartyAdvisor.Commands.Commands;

namespace TorontoPartyAdvisor.Commands.Helpers
{
    public sealed class Runner
    {
        public Runner()
        {
            var binFolder = System.IO.Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "bin");
            XmlConfigurator.Configure(new FileInfo(binFolder + @"\Log4Net.config"));
        }

        public static void RunCommand<T>(ref T command, Type referenceClass = null) where T : AbstractCommand, ICommand
        {
            command.Execute();
        }
    }
}
