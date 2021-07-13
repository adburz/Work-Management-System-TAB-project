using System;
using System.Collections.Generic;
using System.Linq;
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

        public Absence Update(Absence absence)
        {
            var foundAbsence = GetById(absence.AbsenceId);

            if (foundAbsence == null)
                return null;

            if (absence.AbsenceTypeId != Guid.Empty)
                foundAbsence.AbsenceTypeId = absence.AbsenceTypeId;

            if (absence.StartDate != DateTime.MinValue)
                foundAbsence.StartDate = absence.StartDate;

            if (absence.EndDate != DateTime.MinValue)
                foundAbsence.EndDate = absence.EndDate;

            if (absence.UserId != Guid.Empty)
                foundAbsence.UserId = absence.UserId;

            foundAbsence.Confirmed = absence.Confirmed;

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
