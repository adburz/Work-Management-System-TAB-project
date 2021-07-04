using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Security.Claims;
using WorkManagementSystemTAB.DTO.Request;
using WorkManagementSystemTAB.Models;
using WorkManagementSystemTAB.Services.Absences;

namespace WorkManagementSystemTAB.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class AbsencesController : BaseAccessController
    {
        private readonly IAbsencesService _absenceService;
        public AbsencesController(IAbsencesService absenceService) {
            _absenceService = absenceService;
        }

        
        [HttpGet]
        public IActionResult GetAbsences() 
        {
            var absences = _absenceService.GetAll();

            return Ok(absences);
        }

        [HttpGet("worker/{id}")]
        public IActionResult GetAllWorkerAbsences(Guid id)
        {
            var allWorkerAbsences = _absenceService.GetAllWorkerAbsensces(id);

            if (allWorkerAbsences == null)
                return NotFound();

            return Ok(allWorkerAbsences);
        }

        [HttpGet("active")]
        public IActionResult GetAllActiveAbsences()
        {
            return Ok(_absenceService.GetAllActive());
        }

        [HttpGet("active/worker/{id}")]
        public IActionResult GetAllActiveWorkerAbsences(Guid id) //active == not confirmed
        {
            var allActiveWorkerAbsences = _absenceService.GetAllActiveWorkerAbsences(id);

            if (allActiveWorkerAbsences == null)
                return NotFound();

            return Ok(allActiveWorkerAbsences);
        }

        [HttpGet("confirmed")]
        public IActionResult GetAllConfirmedAbsences()
        {
            return Ok(_absenceService.GetAllConfirmed());
        }

        [HttpGet("confirmed/worker/{id}")]
        public IActionResult GetAllConfirmedWorkerAbsences(Guid id) //active == not confirmed
        {
            var allConfirmedWorkerAbsences = _absenceService.GetAllConfirmedeWorkerAbsences(id);

            if (allConfirmedWorkerAbsences == null)
                return NotFound();

            return Ok(allConfirmedWorkerAbsences);
        }


        [HttpGet("id/{id}")]
        public IActionResult GetAbsenceById(Guid id)
        {
            var absence = _absenceService.GetById(id);

            if (absence == null)
                return NotFound();

            return Ok(absence);
        }

        

        [HttpPost]
        public IActionResult AddAbsence(AbsenceDTO absenceDTO)
        {
            var newAbsence = _absenceService.Add(absenceDTO);

            if (newAbsence == null)
                return BadRequest( new { Success = false, Error = "There was an error (multiple requests)" });

            return Ok(newAbsence);
        }
        
        [HttpPut]
        public IActionResult ModifyAbsence(Absence absence)
        {
            if (!_absenceService.IsAuthor(absence, this.User.FindFirstValue("email")) && !IsManagerOrAbove())
                return Unauthorized();


            var result = _absenceService.Modify(absence);
            if (result == null)
                return NotFound();

            return Ok(result);
        }


        [HttpDelete("id/{id}")]
        public IActionResult DeleteAbsence(Guid id)
        {
            var absence = _absenceService.GetById(id);

            if (absence == null)
                return NotFound();

            if (!_absenceService.IsAuthor(absence, this.User.FindFirstValue("email")) && !IsManagerOrAbove())
                return Unauthorized();

            _absenceService.Delete(id);

            return Ok();
        }


        [HttpPost("approve")]
        public IActionResult ApproveAbsence(Guid id)
        {
            if (!IsManagerOrAbove())
                return Unauthorized();

            var result =_absenceService.Approve(id);

            if (result == null)
                return NotFound();

            return Ok(result);
        }


    }
}
