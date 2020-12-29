using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PunchClock.Domain.Services;
using PunchClock.Domain.ViewModel;
using PunchClock.Dto;
using PunchClock.Dto.Validators;

namespace PunchClock.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PunchController: ControllerBase
    {
        private IPunchService _punchService;

        public PunchController(IPunchService punchService)
        {
            _punchService = punchService;
        }

        [HttpGet("{employeeId}")]
        public async Task<ActionResult<IEnumerable<PunchViewModel>>> Get([FromRoute] Guid employeeId)
        {
            var punches = await _punchService.GetPunchesByEmployeeId(employeeId);
            return Ok(punches);
        }

        [HttpPost]
        public async Task<ActionResult> Post(PunchDto punchDto)
        {
            try
            {
                var validator = new PunchDtoValidator();
                var result = validator.Validate(punchDto);
                if (!result.IsValid)
                {
                    return BadRequest(result.Errors);
                }

                var punchViewModel = new PunchViewModel 
                {
                    EmployeeId = punchDto.EmployeeId,
                    EmployeeName = punchDto.EmployeeName,
                    PunchType = punchDto.PunchType
                };

                await _punchService.Register(punchViewModel);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }            
        }
    }
}