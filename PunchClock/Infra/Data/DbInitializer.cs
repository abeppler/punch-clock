using System.Linq;
using PunchClock.Domain.Entities;
using PunchClock.Domain.ViewModel;

namespace PunchClock.Infra.Data
{
    public static class DbInitializer
    {
        public static void Initialize(PunchClockContext context) {
            context.Database.EnsureCreated();

            if (context.Employees.Any())
            {
                return;                
            }

            var employees = new Employee[]
            {
                new Employee( new EmployeeViewModel { Name = "John Doe" } ),
                new Employee( new EmployeeViewModel { Name = "Richard Roe" } )
            };

            context.Employees.AddRange(employees);
            context.SaveChanges();
        }
    }
}