using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkManagementSystemTAB.DTO.Request;
using WorkManagementSystemTAB.Models;
using WorkManagementSystemTAB.Services.AbsenceTypes;

namespace WorkManagementSystemTAB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AbsenceTypesController : BaseAccessController
    {
        private readonly IAbsenceTypesService _absenceTypesService;
        public AbsenceTypesController(IAbsenceTypesService absenceTypesService)
        {
            _absenceTypesService = absenceTypesService;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult GetAbsenceTypes()
        {
            var absenceTypes = _absenceTypesService.GetAll();

            if (absenceTypes == null)
                return NotFound();

            return Ok(absenceTypes);
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public IActionResult GetAbsenceTypeById(Guid id)
        {
            var result = _absenceTypesService.GetById(id);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpGet("{name}")]
        [AllowAnonymous]
        public IActionResult GetAbsenceTypeByName(string name)
        {
            var result = _absenceTypesService.GetByName(name);

            if (result == null)
                return NotFound();

            return Ok(result);

        }



        [HttpPost]
        public IActionResult AddAbsenceType([FromBody] AbsenceTypeDTO absenceTypeRequest)
        {
            if (!IsManagerOrAbove())
                return Unauthorized();

            var result = _absenceTypesService.Add(absenceTypeRequest);
            if (result == null)
                return NotFound();

            return Ok(result);

        }


        [HttpPut]
        public IActionResult ModifyAbsenceType([FromBody] AbsenceType absenceTypeRequest)
        {
            if (!IsManagerOrAbove())
                return Unauthorized();

            var result = _absenceTypesService.Modify(absenceTypeRequest);
            if (result == null)
                return NotFound();


            return Ok(result);

        }


        [HttpDelete]
        public IActionResult DeleteAbsenceType([FromBody] Guid id)
        {
            if (!IsManagerOrAbove())
                return Unauthorized();

            _absenceTypesService.Delete(id);

            return Ok();

        }

    }
}
