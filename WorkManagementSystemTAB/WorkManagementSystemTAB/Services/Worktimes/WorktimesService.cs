using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkManagementSystemTAB.DTO.Request;
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
        

        public Worktime Add(WorktimeDTO entity)
        {
            var newWorktime = new Worktime()
            {

            };
            return _worktimesRepository.Add(newWorktime);
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
