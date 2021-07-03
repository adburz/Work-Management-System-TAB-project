using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        public Absence Modify(Absence absence);
        public Absence Approve(Guid id);

    }
}
