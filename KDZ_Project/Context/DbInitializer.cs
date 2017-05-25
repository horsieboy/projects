using KDZ_Project.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KDZ_Project.Context
{
    public class DbInitializer
#if DEBUG  
        :DropCreateDatabaseAlways<CompetitiondbContext>
#else
        :CreateDatabaseIfNotExists<CompetitiondbContext>
#endif 
    {
        protected override void Seed(CompetitiondbContext context)
        {

            context.Users.Add(new User { Login="User" , Password="User"});
            context.Places.Add(new Places { Name = "место не выбрано" });
            context.Places.Add(new Places { Name="Арена 1" });
            context.Places.Add(new Places { Name = "Арена 2" });
            context.Places.Add(new Places { Name = "Арена 3" });
            context.Places.Add(new Places { Name = "Арена 4" });
            context.Disciplines.Add(new Disciplines { Name = "Дисциплина не выбрана" });
            context.Disciplines.Add(new Disciplines { Name = "CS:GO" });
            context.Disciplines.Add(new Disciplines { Name = "Dota 2" });
            context.Disciplines.Add(new Disciplines { Name = "Hearthstone" });
            context.SaveChanges();
            var users = context.Users.ToList();
            context.Competitions.Add(new Competition { CreatorId =  1, Name = "Чемпионат", DateStart = DateTime.Now, MaxUsersCount = 50, Prize = 2999.99, DisciplineId = 1, PlaceId = 1, Users = users });
            context.UserInfos.Add(new UserInfo { Id = 1, FirstName = "Abc", LastName = "aBc", MiddleName = "abC" });
            context.SaveChanges();

        }
    }
}
