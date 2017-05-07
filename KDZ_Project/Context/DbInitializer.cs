using KDZ_Project.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KDZ_Project.Context
{
    public class DbInitializer:DropCreateDatabaseAlways<CompetitiondbContext>
    {
        protected override void Seed(CompetitiondbContext context)
        {

            context.Users.Add(new User { Login="User" , Password="User"});
            context.Places.Add(new Places { Name="VDNH" });
            context.Places.Add(new Places { Name = "Лужники" });
            context.Disciplines.Add(new Disciplines { Name = "Футбол" });
            context.Disciplines.Add(new Disciplines { Name = "Баскетбол" });
            context.SaveChanges();
            var users = context.Users.ToList();
            context.Competitions.Add(new Competition { CreatorId =  1, Name = "Чемпионат", DateStart = DateTime.Now, MaxUsersCount = 50, Prize = 2999.99, DisciplineId = 1, PlaceId = 1, Users = users });
            context.UserInfos.Add(new UserInfo { Id = 1, FirstName = "Abc", LastName = "aBc", MiddleName = "abC" });
            context.SaveChanges();

        }
    }
}
