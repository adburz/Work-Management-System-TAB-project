using System;
using System.Collections.Generic;
using WorkManagementSystemTAB.DTO.Request;
using WorkManagementSystemTAB.Models;

namespace WorkManagementSystemTAB.Services.Absences
{
    public interface IAbsencesService : IService<Absence, Guid,AbsenceDTO>
    {
        public Absence Update(AbsenceUpdateDTO absence);
        public Absence Approve(Guid id);
        public bool IsAuthor(Guid userId, string email);
        public IEnumerable<Absence> GetAllActive();
        public IEnumerable<Absence> GetAllWorkerAbsensces(Guid userId);
        public IEnumerable<Absence> GetAllActiveWorkerAbsences(Guid userId);
        public IEnumerable<Absence> GetAllConfirmed();
        public IEnumerable<Absence> GetAllConfirmedeWorkerAbsences(Guid userId);
        public IEnumerable<IEnumerable<WorktimeDTO>> FindReplacment(Guid absenceId);
    }
}
