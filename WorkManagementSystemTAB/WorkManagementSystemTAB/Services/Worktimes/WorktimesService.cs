using System;
using System.Collections.Generic;
using System.Linq;
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

        private bool checkIfWorktimeOverlap(ref IEnumerable<Worktime> workSchedule,WorktimeDTO newWorktime)
        {
            var overlappedWorktimes = workSchedule.Where(x => (x.StartTime <= newWorktime.EndTime && newWorktime.StartTime <= x.EndTime)).ToList();
            return overlappedWorktimes.Any() ? true : false;
        }
        public Worktime Add(WorktimeDTO entity)
        {
            var workSchedule = _worktimesRepository.GetWorktimesByUserId(entity.UserId);
            if (checkIfWorktimeOverlap(ref workSchedule, entity)) return null;

            var newWorktime = new Worktime() { StartTime = entity.StartTime, EndTime = entity.EndTime, UserId = entity.UserId, WorktimeId=Guid.NewGuid() };

            return _worktimesRepository.Add(newWorktime);
        }

        public IEnumerable<DTO.Response.WorktimeDTO> GetUsersWorktimeSchedule(Guid userId)
        {
            var worktimeSchedule = _worktimesRepository.GetWorktimesByUserId(userId).Select(x => new DTO.Response.WorktimeDTO()
            {
                StartTime = x.StartTime,
                EndTime = x.EndTime,
                WorktimeId=x.WorktimeId 
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

        public IEnumerable<Worktime> AddWorktimeList(IEnumerable<WorktimeDTO> worktimeList)
        {
            var workSchedule = _worktimesRepository.GetWorktimesByUserId(worktimeList.First().UserId);
            var tempWorktimeList = worktimeList.ToList();
            foreach(var worktimeBlock in worktimeList)
            {
                if (checkIfWorktimeOverlap(ref workSchedule, worktimeBlock)) return null;
                tempWorktimeList.Remove(worktimeBlock);
                var overlappedWorktimes = tempWorktimeList.Where(x => (x.StartTime <= worktimeBlock.EndTime && worktimeBlock.StartTime <= x.EndTime)).ToList();
                if (overlappedWorktimes.Any()) return null;
            }
            var newWorktimes = worktimeList.Select(x => new Worktime()
            {
                EndTime = x.EndTime,
                StartTime = x.StartTime,
                UserId = x.UserId,
                WorktimeId = Guid.NewGuid()
            }).ToList();
            return _worktimesRepository.AddListOfWorktimes(newWorktimes);
        }

        public Worktime UpdateWorktime(Worktime worktime)
        {
            if (worktime == null)
                return null;

            return _worktimesRepository.UpdateWorktime(worktime);
        }
    }
}
