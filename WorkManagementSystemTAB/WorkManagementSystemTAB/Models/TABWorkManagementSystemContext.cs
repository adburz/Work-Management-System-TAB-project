using Microsoft.EntityFrameworkCore;



namespace WorkManagementSystemTAB.Models
{
    public partial class TABWorkManagementSystemContext : DbContext
    {
        public TABWorkManagementSystemContext(DbContextOptions<TABWorkManagementSystemContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Absence> Absences { get; set; }
        public virtual DbSet<AbsenceType> AbsenceTypes { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Worktime> Worktimes { get; set; }
    }
}
