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

        private bool CheckIfWorktimeOverlap(ref IEnumerable<Worktime> workSchedule,WorktimeDTO newWorktime)
        {
            if (workSchedule == null || newWorktime == null)
                return false;

            return workSchedule.ToList().Exists(x => x.StartTime <= newWorktime.EndTime && newWorktime.StartTime <= x.EndTime);
                       
        }
        public Worktime Add(WorktimeDTO entity)
        {
            var workSchedule = _worktimesRepository.GetWorktimesByUserId(entity.UserId);
            if (CheckIfWorktimeOverlap(ref workSchedule, entity)) return null;

            var newWorktime = new Worktime() { StartTime = entity.StartTime, EndTime = entity.EndTime, UserId = entity.UserId, WorktimeId=Guid.NewGuid() };

            return _worktimesRepository.Add(newWorktime);
        }

        public IEnumerable<Worktime> GetUsersWorktimeSchedule(Guid userId)
        {
            return _worktimesRepository.GetWorktimesByUserId(userId);
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
            var tmp = new Dictionary<Guid, List<WorktimeDTO>>();
            
            foreach (var worktime in worktimeList)
            {
                if(!tmp.ContainsKey(worktime.UserId))
                {
                    tmp[worktime.UserId] = new List<WorktimeDTO>();
                }
                
                var currentUserWorktimes = _worktimesRepository.GetWorktimesByUserId(worktime.UserId);

                if(currentUserWorktimes.Any(x => x.StartTime <= worktime.EndTime && x.EndTime >= worktime.StartTime))
                {
                    return null;
                }

                tmp[worktime.UserId].Add(worktime);
            }

            foreach(var x in tmp)
            {
                var list = x.Value;

                for(int i = 0; i < list.Count;i++)
                {
                    for(int j = i + 1; j<list.Count;j++)
                    {
                        if(list[i] == list[j])
                        {
                            return null;
                        }
                    }
                }
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

        public Worktime Update(WorktimeUpdateDTO worktime)
        {
            if (worktime == null)
                return null;

            return _worktimesRepository.Update(worktime);
        }
    }
}
