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
            return _worktimesRepository.Add(entity);
        }

        public void Delete(Guid id) {
            _worktimesRepository.Delete(id);
        }

        public IEnumerable<Worktime> GetAll() {
            throw new NotImplementedException();
        }

        public Worktime GetById(Guid id) {
            return _worktimesRepository.GetById(id);
        }
    }
}
