using WorkManagementSystemTAB.Models;

namespace WorkManagementSystemTAB.Repository.Authorization
{
    public class AuthorizationRepository :BaseRepository, IAuthorizationRepository
    {

        public AuthorizationRepository(TABWorkManagementSystemContext context) : base(context) { }

        
    }
}
