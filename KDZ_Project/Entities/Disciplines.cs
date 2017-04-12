using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KDZ_Project.Entities
{
    public class Disciplines:Base.BaseIdEntity
    {
        public string Name { get; set; }
        public virtual ICollection<Competition> Competitions { get; set; }
    }
}
