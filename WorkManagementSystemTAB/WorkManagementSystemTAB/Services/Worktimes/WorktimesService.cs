using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkManagementSystemTAB.DTO.Request;
using WorkManagementSystemTAB.Models;
using WorkManagementSystemTAB.Repository.UserResitory;
using WorkManagementSystemTAB.Repository.Worktimes;

namespace WorkManagementSystemTAB.Services.Worktimes
{
    public class WorktimesService : IWorktimesService
    {
        private readonly IWorktimesRepository _worktimesRepository;
        private readonly IUsersRepository _usersRepository;
        public WorktimesService(IWorktimesRepository worktimesRepository, IUsersRepository usersRepository) {
            _worktimesRepository = worktimesRepository;
            _usersRepository = usersRepository;
        }

        public Worktime Add(WorktimeDTO entity)
        {
            var userId = _usersRepository.FindUserByEmail(entity.Email).UserId;
            var workSchedule = _worktimesRepository.GetWorktimesByUserId(userId);
            var overlappedWorktimes = workSchedule.Where(x => (x.StartTime < entity.EndTime && entity.StartTime < x.EndTime)).ToList();

            if(overlappedWorktimes.Any()) return null;

            var newWorktime = new Worktime() { StartTime = entity.StartTime, EndTime = entity.EndTime, UserId = userId, WorktimeId=Guid.NewGuid() };

            return _worktimesRepository.Add(newWorktime);
        }

        public IEnumerable<DTO.Response.WorktimeDTO> GetUsersWorktimeSchedule(string email)
        {
            var userId = _usersRepository.FindUserByEmail(email).UserId;

            var worktimeSchedule = _worktimesRepository.GetWorktimesByUserId(userId).Select(x => new DTO.Response.WorktimeDTO()
            {
                StartTime = x.StartTime,
                EndTime = x.EndTime
            });
            return worktimeSchedule.Any() ? worktimeSchedule : null;
        }

        public void Delete(Guid id) {
            _worktimesRepository.Delete(id);
        }

        public IEnumerable<Worktime> GetAll() {
            return _worktimesRepository.GetAll();
        }

        public Worktime GetById(Guid id) {
            return _worktimesRepository.GetById(id);
        }
    }
}
