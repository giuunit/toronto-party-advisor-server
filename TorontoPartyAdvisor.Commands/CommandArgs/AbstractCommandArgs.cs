using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TorontoPartyAdvisor.Commands.CommandArgs
{
    public class AbstractCommandArgs
    {
        public override string ToString()
        {
            string toReturn = string.Empty;

            foreach (var property in GetType().GetProperties())
            {
                if (property.PropertyType == typeof(List<string>))
                {
                    var list = property.GetValue(this, null) as List<string>;
                    if (list != null)
                    {
                        toReturn += property.Name + " : { " + string.Join(",", list) + " }" + "\n";
                    }
                }
                else
                {
                    toReturn += property.Name + " : " + property.GetValue(this, null) + "\n";
                }
            }

            return toReturn;
        }
    }
}
