using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KDZ_Project.Entities
{
    [Table("Users")]
    public class User : Base.BaseIdEntity
    {
        public String Login { get; set; }
        public String Password { get; set; }
        public int? UserInfoId { get; set; }
        [ForeignKey("UserInfoId")]
        public virtual UserInfo UserInfo { get; set; }
        public virtual ICollection<Competition> Competitions { get; set; }
        public DateTime RegDate { get; set; } = DateTime.Now;
        public string Status { get; set; }
    }
}
