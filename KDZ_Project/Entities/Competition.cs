using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KDZ_Project.Entities
{
    [Table("Competitions")]
    public class Competition:Base.BaseIdEntity
    {
        public int CreatorId { get; set; }
        public string Name { get; set; }
        public DateTime DateStart { get; set; }
        public int MaxUsersCount { get; set; }
        public double Prize { get; set; }
        public DateTime? DateEnded { get; set; }
        public bool IsCanceled { get; set; }
        public DateTime? DateCanceled { get; set; }
        public bool IsStarted { get; set; }
        [ForeignKey("Place")]
        public int PlaceId { get; set; }
        //[ForeignKey("Winner")]
        //public int? WinnerId { get; set; }
        [ForeignKey("Discipline")]
        public int DisciplineId { get; set; }
        //public virtual User Winner { get; set; }
        [ForeignKey("CreatorId")]
        public virtual User Creator { get; set; } 
        public virtual Disciplines Discipline { get; set; }
        public virtual Places Place { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
