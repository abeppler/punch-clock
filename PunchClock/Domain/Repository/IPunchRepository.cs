using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PunchClock.Domain.Entities;

namespace PunchClock.Domain.Repository
{
    public interface IPunchRepository: IBaseRepository<Punch>
    {
        Task<List<Punch>> GetByEmployeeId(Guid employeeId);
        Task<Punch> GetLastPunchForToday(Guid employeeId);
    }
}