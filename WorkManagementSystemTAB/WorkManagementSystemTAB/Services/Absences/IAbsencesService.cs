using System;
using System.Collections;
using System.Collections.Generic;
using WorkManagementSystemTAB.DTO.Request;
using WorkManagementSystemTAB.Models;

namespace WorkManagementSystemTAB.Services.Absences
{
    public interface IAbsencesService : IService<Absence, Guid,AbsenceDTO>
    {
        public Absence Modify(Absence absence);
        public Absence Approve(Guid id);
        public bool IsAuthor(Absence absence, string email);
        public IEnumerable<Absence> GetAllActive();
    }
}
