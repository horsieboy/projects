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
