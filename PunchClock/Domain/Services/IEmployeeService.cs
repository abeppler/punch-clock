using System.Collections.Generic;
using System.Threading.Tasks;
using PunchClock.Dto;

namespace PunchClock.Domain.Services
{
    public interface IEmployeeService
    {
         Task<IEnumerable<EmployeeDto>> GetAll();
    }
}