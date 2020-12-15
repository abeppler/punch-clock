using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using PunchClock.Domain.Entities;
using PunchClock.Domain.Repository;
using PunchClock.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace PunchClock.Infra.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        protected readonly PunchClockContext _context;

        public EmployeeRepository(PunchClockContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Employee>> GetAll() => await _context
            .Set<Employee>()
            .AsNoTracking()
            .ToListAsync();

        public Task Save(Employee employee)
        {
            if (employee.Id == Guid.Empty)
            {
                _context.Employees.Add(employee);
            } 
            else
            {
                var employeeToUpdate = _context.Employees.First(x => x.Id == employee.Id);
                employeeToUpdate.UpdateProperties(employee);
            }

            return _context.SaveChangesAsync();
        }
    }
}