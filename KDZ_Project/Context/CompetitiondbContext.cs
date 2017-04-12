using KDZ_Project.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KDZ_Project.Context
{
    public class CompetitiondbContext:DbContext
    {
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Competition> Competitions { get; set; }
        public virtual DbSet<UserInfo> UserInfos { get; set; }
        public virtual DbSet<Places> Places { get; set; }
        public virtual DbSet<Disciplines> Disciplines { get; set; }
        public CompetitiondbContext()
        {
            Database.SetInitializer(new DbInitializer());
            
        }
    }

}
