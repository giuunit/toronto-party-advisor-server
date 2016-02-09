using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TorontoPartyAdvisor.Commands.CommandArgs;
using TorontoPartyAdvisor.Commands.CommandResults;
using TorontoPartyAdvisor.Commands.Helpers;

namespace TorontoPartyAdvisor.Commands.Commands
{
    public class GetGenderStatsCommand : AbstractCommand, ICommand
    {
        public GetGenderStatsCommandArgs Args { get; set; }
        public GetGenderStatsCommandResults Results { get; private set; }

        public void Execute()
        {
            using(var db = new PartyAdvisorEntities())
            {
                //latest position of the user
                var groupedPositions = (from p in db.Positions
                                        group p by p.UserId into grp
                                        select grp.OrderByDescending(g => g.Date).FirstOrDefault());

                var genderList = (from pp in db.PositionPlaces
                                  join p in groupedPositions on pp.PositionId equals p.Id
                                  join u in db.Users on p.UserId equals u.Id
                                  where pp.PlaceId == Args.PlaceId
                                  && p.Date > DbFunctions.AddMinutes(Args.Date, -Args.MinutesDifference)
                                  group u by u.Gender into g
                                  select new
                                  {
                                      name = g.Key,
                                      count = g.Count()
                                  }
                              ).ToDictionary(x => x.name, x => x.count);
                

                Results = new GetGenderStatsCommandResults()
                {
                    MaleUsers = genderList.ContainsKey(Const.MaleString) ? genderList[Const.MaleString] : 0, 
                    FemaleUsers = genderList.ContainsKey(Const.FemaleString) ? genderList[Const.FemaleString] : 0,
                    MinutesRequest = Args.MinutesDifference
                };
            }
        }
    }
}
