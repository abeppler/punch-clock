using System;
using PunchClock.Domain.ViewModel;

namespace PunchClock.Domain.Entities
{
    public class Employee
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }

        protected Employee()
        {
        }

        public Employee(EmployeeViewModel viewModel)
        {
            Id = viewModel.Id;
            Name = viewModel.Name;
        }
    }
}