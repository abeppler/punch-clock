using System;
using PunchClock.Domain.Entities.Enums;
using PunchClock.Domain.ViewModel;

namespace PunchClock.Domain.Entities
{
    public class Punch
    {
        public Guid Id { get; set; }
        public Guid EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public DateTimeOffset DateTime { get; set; }
        public PunchType PunchType { get; set; }

        protected Punch()
        {   
        }

        public Punch(PunchViewModel viewModel)
        {
            EmployeeId = viewModel.EmployeeId;
            DateTime = viewModel.DateTime;
            PunchType = viewModel.PunchTypeEnum;
        }

        public void UpdateProperties(Punch punch) 
        {
            DateTime = punch.DateTime;
            PunchType = punch.PunchType;
        }
    }
}