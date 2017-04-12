using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KDZ_Project.Models
{
    public class CompetitionViewModel
    {
        public string Name { get; set; }
        public DateTime DateStart { get; set; }
        public int MaxUsersCount { get; set; }
        public double Prize { get; set; }
        public DateTime? DateEnded { get; set; }
        public bool IsCanceled { get; set; }
        public DateTime? DateCanceled { get; set; }
        public bool IsStarted { get; set; }
        public string Place { get; set; }
        public string Discipline { get; set; }
        public int Id { get; set; }
    }
}
