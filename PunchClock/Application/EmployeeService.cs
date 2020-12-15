using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PunchClock.Domain.Repository;
using PunchClock.Domain.Services;
using PunchClock.Dto;

namespace PunchClock.Application
{
    public class EmployeeService : IEmployeeService
    {
        private IEmployeeRepository _employeeRepository;
        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        public async Task<IEnumerable<EmployeeDto>> GetAll()
        {
            var employees = await _employeeRepository.GetAll();
            return employees.Select(x => new EmployeeDto {
                Id = x.Id,
                Name = x.Name
            })
            .ToList();          
        } 
    }
}