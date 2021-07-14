using System;
using System.Collections.Generic;
using WorkManagementSystemTAB.DTO.Request;
using WorkManagementSystemTAB.Models;

namespace WorkManagementSystemTAB.Repository.Absences
{
    public interface IAbsencesRepository 
    {
        Absence Add(Absence entity);
        void Delete(Guid id);
        IEnumerable<Absence> GetAll();
        Absence GetById(Guid id);
        public Absence Update(AbsenceUpdateDTO absence);
        public Absence Approve(Guid id);
    }
}
