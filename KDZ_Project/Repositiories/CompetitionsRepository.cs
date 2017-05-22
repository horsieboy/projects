using KDZ_Project.Context;
using KDZ_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using KDZ_Project.Entities;

namespace KDZ_Project.Repositiories
{
    public class CompetitionsRepository
    {

        private IQueryable<Competition> GetQuary()
            {


            return _context.Competitions.Include(x => x.Creator).Include(x => x.Discipline).Include(x => x.Place).Include(x=>x.Users);


            }

        private CompetitionViewModel Map(Competition x)
        {
            return new CompetitionViewModel
            {
                Users = x.Users.Select(u => new UserViewModel2 {Id = u.Id, Name = u.Login }),
                Id = x.Id,
                Contestants = x.Users.Count(),
                Name = x.Name,
                DateStart = x.DateStart,
                MaxUsersCount = x.MaxUsersCount,
                Prize = x.Prize,
                DateEnded = x.DateEnded,
                IsCanceled = x.IsCanceled,
                Creator = x.Creator.Login,
                CreatorId = x.Creator.Id,
                IsStarted = x.IsStarted,
                Place = x.Place.Name,
                Discipline = x.Discipline.Name,
            };
        }

        private CompetitiondbContext _context;

        public void Update(CompetitionViewModel c)
        {
            var comp = _context.Competitions.FirstOrDefault(x => x.Id == c.Id);

            var place = _context.Places.FirstOrDefault(x => x.Name == c.Place);

            var discipline = _context.Disciplines.FirstOrDefault(x => x.Name == c.Discipline);

            //comp.Contestants = c.Users.Count();
            comp.Name = c.Name;
            comp.PlaceId = place.Id;
            comp.DisciplineId = discipline.Id;
            comp.DateStart = c.DateStart;
            comp.DateEnded = c.DateEnded;
            comp.DateCanceled = c.DateCanceled;
            comp.IsCanceled = c.IsCanceled;
            comp.IsStarted = c.IsStarted;
            comp.MaxUsersCount = c.MaxUsersCount;
            comp.Prize = c.Prize;
            _context.SaveChanges();

        }

        public void Remove(int d)
        {
            var comp = _context.Competitions.FirstOrDefault(x => x.Id == d);

            _context.Competitions.Remove(comp);

            _context.SaveChanges();

        }


        public CompetitionsRepository()
        {
            _context = new CompetitiondbContext();
        }

        public IEnumerable<CompetitionViewModel> GetCompetitions() {

            return GetQuary().Select(Map).ToList();
        }

        public IEnumerable<CompetitionViewModel> GetCompetitions(string search)
        {

            if (string.IsNullOrWhiteSpace(search)) return GetCompetitions();

            return GetQuary().Where(x => x.Name.Trim().ToLower().Contains(search.Trim().ToLower())).Select(Map).ToList();
        }

        public bool Apply(int compId,int userId)
        {
            var comp = GetQuary().FirstOrDefault(x => x.Id == compId);
            var user = _context.Users.FirstOrDefault(x => x.Id == userId);
            comp.Users.Add(user);
            _context.SaveChanges();
            return CanApply(compId, userId);
        }
        public bool Dismiss(int compId, int userId)
        {
            var comp = GetQuary().FirstOrDefault(x => x.Id == compId);
            var user = _context.Users.FirstOrDefault(x => x.Id == userId);
            comp.Users.Remove(user);
            _context.SaveChanges();
            return CanApply(compId, userId);
        }
        public bool CanApply(int compid, int userid)
        {

            var comp = GetQuary().FirstOrDefault(x => x.Id == compid);

            return comp.MaxUsersCount - comp.Users.Count > 0 && !comp.Users.Any(u => u.Id == userid);
        }

        public IEnumerable<UserViewModel2> GetCompetitionUsers(int compId)
        {
            var comp = GetQuary().FirstOrDefault(x => x.Id == compId);

            return comp.Users.Select(u => new UserViewModel2 { Id = u.Id, Name = u.Login });
        }

        public IEnumerable<CompetitionViewModel2> GetUserCompetitions(int userId)
        {
            return GetQuary().Where(c => c.Users.Any(u => u.Id == userId)).Select(x => new CompetitionViewModel2
            {
                Id = x.Id,
                Name = x.Name,
            }).ToList();
        }
    }
}
