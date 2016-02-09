using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TorontoPartyAdvisor.Commands.CommandArgs;
using TorontoPartyAdvisor.Commands.Helpers;

namespace TorontoPartyAdvisor.Commands.Commands
{
    public class LogInUserCommand: AbstractCommand, ICommand
    {
        public LogInUserCommandArgs Args { get; set; }
        public SuccessBox Result { get; private set; }

        public void Execute()
        {
            using(var db = new PartyAdvisorEntities())
            {
                var fbUser = db.Users.SingleOrDefault(x => x.FacebookId == Args.FacebookId);

                //User already exists
                if (fbUser != null)
                {
                    fbUser.FacebookToken = Args.FacebookAccessToken;
                    fbUser.LastLoginDate = DateTimeOffset.Now;
                    db.Entry(fbUser).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }

                else
                {
                    //new user
                    var user = new User()
                    {
                        FirstName = Args.FirstName,
                        LastName = Args.LastName,
                        Gender = Args.Gender,
                        FacebookToken = Args.FacebookAccessToken,
                        Email = Args.Email,
                        FacebookId = Args.FacebookId,
                        Timezone = Args.TimeZone,
                        Locale = Args.Locale,
                        DateCreated = DateTimeOffset.Now,
                        LastLoginDate = DateTimeOffset.Now,
                        Points = 0
                    };

                    db.Entry(user).State = System.Data.Entity.EntityState.Added;
                    db.SaveChanges();

                }

                Result = new SuccessBox();
                Result.AddData("AccessToken", Args.FacebookAccessToken);
            }
        }
    }
}
