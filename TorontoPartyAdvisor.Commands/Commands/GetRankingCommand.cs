using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TorontoPartyAdvisor.Commands.CommandArgs;
using TorontoPartyAdvisor.Commands.Helpers;

namespace TorontoPartyAdvisor.Commands.Commands
{
    public class GetRankingCommand : AbstractCommand, ICommand
    {
        public GetRankingCommandArgs Args { get; set; }
        public IEnumerable<RankingUserViewModel> Results { get; private set; }

        public void Execute()
        {
            using(var db = new PartyAdvisorEntities())
            {
                //no user authentified
                if (!db.Users.Any(x => x.FacebookToken == Args.AccessToken))
                {
                    //TODO: add log here

                    ILog logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
                    logger.Warn(FormatHelper.FormatCommandToLog(this, Args));


                    Results = new List<RankingUserViewModel>();
                    return;
                }

                var dbResults = db.Users.OrderByDescending(x => x.Points).Take(Args.NumberResults).Select(x => new RankingUserViewModel()
                {
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    FacebookId = x.FacebookId,
                    Score = x.Points
                }).ToList();

                if(dbResults.Count < Args.NumberResults)
                {
                    var nbResToAdd = Args.NumberResults - dbResults.Count;

                    for(int i=0;i<nbResToAdd;i++)
                    {
                        dbResults.Add(new RankingUserViewModel()
                        {
                                
                        });
                    }
                }

                Results = dbResults;
            }
        }
    }
}
