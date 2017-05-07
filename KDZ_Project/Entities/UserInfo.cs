using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KDZ_Project.Entities
{
   public class UserInfo
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None), ForeignKey("User")]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public virtual User User { get; set; }
        [NotMapped]
        public string FullName => $"{LastName} {FirstName} {MiddleName}";
    }
}
