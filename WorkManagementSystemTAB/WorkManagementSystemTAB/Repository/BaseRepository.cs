using WorkManagementSystemTAB.Models;

namespace WorkManagementSystemTAB.Repository
{
    public abstract class BaseRepository
    {
        protected readonly TABWorkManagementSystemContext _context;
        public BaseRepository(TABWorkManagementSystemContext context) => _context = context;
        
        public void Save()
        {
            _context.SaveChanges();
        }

    }
}
