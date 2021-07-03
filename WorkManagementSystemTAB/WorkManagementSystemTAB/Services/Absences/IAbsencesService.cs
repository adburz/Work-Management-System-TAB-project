using System;
using WorkManagementSystemTAB.DTO.Request;
using WorkManagementSystemTAB.Models;

namespace WorkManagementSystemTAB.Services.Absences
{
    public interface IAbsencesService : IService<Absence, Guid,AbsenceDTO>
    {

    }
}
