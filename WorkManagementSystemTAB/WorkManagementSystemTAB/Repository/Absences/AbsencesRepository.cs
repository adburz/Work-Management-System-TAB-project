using System;
using System.Collections.Generic;
using System.Linq;
using WorkManagementSystemTAB.DTO.Request;
using WorkManagementSystemTAB.Models;

namespace WorkManagementSystemTAB.Repository.Absences
{
    public class AbsencesRepository : BaseRepository, IAbsencesRepository
    {

        public AbsencesRepository(TABWorkManagementSystemContext context) : base(context) { }

        public Absence Add(Absence absence)
        {
            var result = _context.Absences.FirstOrDefault(x => x.AbsenceId == absence.AbsenceId);

            if (result != null)
                return result;

            _context.Absences.Add(absence);
            Save();

            return absence;
        }

        public void Delete(Guid id)
        {
            var foundAbsence = GetById(id);

            if (foundAbsence != null)
            {
                _context.Absences.Remove(foundAbsence);
                Save();
            }
        }

        public IEnumerable<Absence> GetAll()
        {
            return _context.Absences.ToList();
        }

        public Absence GetById(Guid id)
        {
            return _context.Absences.FirstOrDefault(x => x.AbsenceId == id);
        }

        public Absence Update(AbsenceUpdateDTO absence)
        {
            var foundAbsence = GetById(absence.AbsenceId);

            if (foundAbsence == null)
                return null;

            if ( absence.AbsenceTypeId != null)
                foundAbsence.AbsenceTypeId = (Guid)absence.AbsenceTypeId;

            if ( absence.StartDate != null)
                foundAbsence.StartDate = (DateTime)absence.StartDate;

            if ( absence.EndDate != null)
                foundAbsence.EndDate = (DateTime)absence.EndDate;

            if ( absence.UserId != null)
                foundAbsence.UserId = (Guid)absence.UserId;

            if (absence.Confirmed != null)
                foundAbsence.Confirmed = (bool)absence.Confirmed;

            Save();
            return foundAbsence;
        }

        public Absence Approve(Guid id)
        {
            var absence = GetById(id);

            if (absence == null)
                return null;

            absence.Confirmed = true;

            Save();

            return absence;
        }
    }
}
