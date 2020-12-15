using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PunchClock.Domain.Entities;
using PunchClock.Domain.Repository;
using PunchClock.Infra.Data;

namespace PunchClock.Infra.Repository
{
    public class PunchRepository : IPunchRepository
    {
        protected readonly PunchClockContext _context;

        public PunchRepository(PunchClockContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Punch>> GetAll() => await _context
            .Set<Punch>()
            .AsNoTracking()
            .ToListAsync();

        public Task<List<Punch>> GetByEmployeeId(Guid employeeId) => _context
                .Set<Punch>()
                .Include(x => x.Employee)
                .Where(x => x.EmployeeId == employeeId)
                .ToListAsync();

        public Task Save(Punch punch)
        {
            if (punch.Id == Guid.Empty)
            {
                _context.Punches.Add(punch);
            } 
            else
            {
                var punchToUpdate = _context.Punches.First(x => x.Id == punch.Id);
                punchToUpdate.UpdateProperties(punch);
            }

            return _context.SaveChangesAsync();
        }
    }
}