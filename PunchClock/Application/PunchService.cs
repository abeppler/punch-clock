using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PunchClock.Domain.Entities;
using PunchClock.Domain.Repository;
using PunchClock.Domain.Services;
using PunchClock.Domain.ViewModel;
using System.Linq;

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
                PunchType = x.PunchType == Domain.Entities.Enums.PunchType.PunchIn ? 'E' : 'S'
            })
            .ToList();
        }

        public Task Register(PunchViewModel punchViewModel)
        {            
            var punch = new Punch(punchViewModel);
            return _punchRepository.Save(punch);
        }
    }
}