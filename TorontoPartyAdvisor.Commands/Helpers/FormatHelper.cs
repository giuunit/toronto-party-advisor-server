using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TorontoPartyAdvisor.Commands.CommandArgs;
using TorontoPartyAdvisor.Commands.Commands;

namespace TorontoPartyAdvisor.Commands.Helpers
{
    //only used in this assembly (Commands)
    public class FormatHelper
    {
        public static string FormatCommandToLog(AbstractCommand command, AbstractCommandArgs args = null, string optionalText = null)
        {
            StringBuilder builder = new StringBuilder();

            builder.AppendLine("Command : " + command.GetType().FullName);

            if (args != null)
            {
                builder.AppendLine("Args");
                builder.AppendLine("******");
                builder.Append(args);
            }

            if (!string.IsNullOrWhiteSpace(optionalText))
            {
                builder.AppendLine(optionalText);
            }

            return builder.ToString();
        }

        public static FacebookHoursFormatted FormatFacebookHoursDay(FacebookHoursBox obj, DayOfWeek? day = null)
        {
            var dayTest = day ?? DateTimeOffset.Now.DayOfWeek;

            var toReturn = new FacebookHoursFormatted()
            {
                Day = dayTest
            };

            switch (dayTest)
            {
                case DayOfWeek.Monday:
                    toReturn.StartTime = obj.Hours.Mon1Open;
                    toReturn.EndTime = obj.Hours.Mon1Close;
                    return toReturn;
                case DayOfWeek.Tuesday:
                    toReturn.StartTime = obj.Hours.Tue1Open;
                    toReturn.EndTime = obj.Hours.Tue1Close;
                    return toReturn;
                case DayOfWeek.Wednesday:
                    toReturn.StartTime = obj.Hours.Wed1Open;
                    toReturn.EndTime = obj.Hours.Wed1Close;
                    return toReturn;
                case DayOfWeek.Thursday:
                    toReturn.StartTime = obj.Hours.Thu1Open;
                    toReturn.EndTime = obj.Hours.Thu1Close;
                    return toReturn;
                case DayOfWeek.Friday:
                    toReturn.StartTime = obj.Hours.Fri1Open;
                    toReturn.EndTime = obj.Hours.Fri1Close;
                    return toReturn;
                case DayOfWeek.Saturday:
                    toReturn.StartTime = obj.Hours.Sat1Open;
                    toReturn.EndTime = obj.Hours.Sat1Close;
                    return toReturn;
                case DayOfWeek.Sunday:
                    toReturn.StartTime = obj.Hours.Sun1Open;
                    toReturn.EndTime = obj.Hours.Sun1Close;
                    return toReturn;
                default:
                    throw new InvalidEnumArgumentException();
            }
        }
    }
}
