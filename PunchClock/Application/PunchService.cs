using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PunchClock.Domain.Entities;
using PunchClock.Domain.Repository;
using PunchClock.Domain.Services;
using PunchClock.Domain.ViewModel;
using System.Linq;
using PunchClock.Domain.Entities.Enums;
using FluentValidation;

namespace PunchClock.Application
{
    public class PunchService : IPunchService
    {
        private IPunchRepository _punchRepository;
        public PunchService(IPunchRepository punchRepository)
        {
            _punchRepository = punchRepository;
        }

        public async Task<List<PunchViewModel>> GetPunchesByEmployeeId(Guid employeeId)
        {
            var punches = await _punchRepository.GetByEmployeeId(employeeId);
            return punches.Select(x => new PunchViewModel {
                Id = x.Id,
                DateTime = x.DateTime,
                EmployeeId = x.EmployeeId,
                EmployeeName = x.Employee.Name,
                PunchType = ConvertToPunchTypeChar(x.PunchType)
            })
            .ToList();
        }

        private char ConvertToPunchTypeChar(PunchType punchType)
        {
            switch (punchType)
            {
                case PunchType.PunchIn:
                    return 'E';
                    
                case PunchType.PunchOut:
                    return 'S';

                default:
                    return '0';
            }
        }

        public Task Register(PunchViewModel punchViewModel)
        {
            var punch = new Punch(punchViewModel);
            punch.DateTime = DateTime.UtcNow;

            var lastPunchToday = _punchRepository.GetLastPunchForToday(punchViewModel.EmployeeId).Result;
            if (lastPunchToday == null)
            {
                punch.PunchType = PunchType.PunchIn;
            }
            else
            {
                punch.PunchType = lastPunchToday.PunchType == PunchType.PunchIn ? PunchType.PunchOut : PunchType.PunchIn;                
            }

            var validator = new PunchValidator();
            var result = validator.Validate(punch);
            if (!result.IsValid)
            {
                var errorsMsg = string.Join(',', result.Errors.Select(x => x.ErrorMessage));
                throw new ValidationException(errorsMsg);
            }

            return _punchRepository.Save(punch);
        }
    }
}