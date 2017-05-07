using KDZ_Project.Context;
using KDZ_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace KDZ_Project.Repositiories
{
    public class CompetitionsRepository
    {

        private CompetitiondbContext _context;

        public void Update(CompetitionViewModel c)
        {
            var comp = _context.Competitions.FirstOrDefault(x => x.Id == c.Id);

            var place = _context.Places.FirstOrDefault(x => x.Name == c.Place);

            var discipline = _context.Disciplines.FirstOrDefault(x => x.Name == c.Discipline);

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
            //comp.Users = c.Users;
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

            return _context.Competitions.Include(x => x.Discipline).Include(x => x.Place).Select(x => new CompetitionViewModel {
                Id = x.Id, 
                Name = x.Name,
                DateStart = x.DateStart,
                MaxUsersCount = x.MaxUsersCount,
                Prize = x.Prize,
                DateEnded = x.DateEnded,
                IsCanceled = x.IsCanceled,
                IsStarted = x.IsStarted, 
                Place = x.Place.Name,
                Discipline = x.Discipline.Name,
            }).ToList();
        }
    }
}
