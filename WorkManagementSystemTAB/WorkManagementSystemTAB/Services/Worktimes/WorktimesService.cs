using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkManagementSystemTAB.Models;
using WorkManagementSystemTAB.Repository.Worktimes;

namespace WorkManagementSystemTAB.Services.Worktimes
{
    public class WorktimesService : IWorktimesService
    {
        private readonly IWorktimesRepository _worktimesRepository;
        public WorktimesService(IWorktimesRepository worktimesRepository) {
            _worktimesRepository = worktimesRepository;
        }
        public Worktime Add(Worktime entity) {
            throw new NotImplementedException();
        }

        public void Delete(Guid id) {
            throw new NotImplementedException();
        }

        public IEnumerable<Worktime> GetAll() {
            throw new NotImplementedException();
        }

        public Worktime GetById(Guid id) {
            throw new NotImplementedException();
        }
    }
}
