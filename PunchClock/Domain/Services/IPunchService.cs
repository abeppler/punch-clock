using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PunchClock.Domain.ViewModel;

namespace PunchClock.Domain.Services
{
    public interface IPunchService
    {
         Task<List<PunchViewModel>> GetPunchesByEmployeeId(Guid employeeId);
         Task Register(PunchViewModel punch);
    }
}