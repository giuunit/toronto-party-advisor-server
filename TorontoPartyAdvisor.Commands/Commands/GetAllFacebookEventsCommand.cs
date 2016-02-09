using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TorontoPartyAdvisor.Commands.CommandArgs;
using TorontoPartyAdvisor.Commands.Helpers;

namespace TorontoPartyAdvisor.Commands.Commands
{
    public class GetAllFacebookEventsCommand : AbstractCommand, ICommand
    {
        public string AccessTokenArgs { get; set; }
        public IEnumerable<FacebookEventPlace> Results { get; private set; }

        public void Execute()
        {
            var places = CacheHelper.Places;
            var toReturn = new List<FacebookEventPlace>();
            List<Task> tasks = new List<Task>();

            foreach (var place in places)
            {
                if (string.IsNullOrWhiteSpace(place.FacebookId))
                    continue;

                var task = new Task<FacebookEventPlace>(() =>
                {
                    var cmd = new GetFacebookEventsCommand()
                    {
                        Args = new GetFacebookEventsCommandArgs()
                        {
                            Limit = 3,
                            FacebookAccessToken = AccessTokenArgs,
                            FacebookId = place.FacebookId
                        }
                    };

                    try
                    {
                        Runner.RunCommand(ref cmd);
                        if (cmd.Results != null && cmd.Results.Items != null && cmd.Results.Items.Count > 0)
                        {
                            return new FacebookEventPlace(cmd.Results.Items.FirstOrDefault(), place.Id);
                        }
                        else
                            return null;

                    }
                    //TODO LOG HERE
                    catch (Exception ex)
                    {
                        return null;
                    }
                });

                tasks.Add(task);
                task.Start();
            }

            Task.WaitAll(tasks.ToArray());

            foreach (Task<FacebookEventPlace> task in tasks)
            {
                if(task.Result != null)
                    toReturn.Add(task.Result);
            }

            if(toReturn.Count > 0)
                Results = toReturn;
        }
    }
}
