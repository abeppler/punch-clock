using System;
using PunchClock.Domain.Entities.Enums;

namespace PunchClock.Domain.ViewModel
{
    public class PunchViewModel
    {
        public Guid Id { get; set; }
        public Guid EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public DateTimeOffset DateTime { get; set; }        
        public char PunchType { get; set; }
        public PunchType PunchTypeEnum
        {
            get 
            {
                switch (PunchType)
                {
                    case 'E':
                        return PunchClock.Domain.Entities.Enums.PunchType.PunchIn;
                    
                    case 'S':
                        return PunchClock.Domain.Entities.Enums.PunchType.PunchOut;

                    default:
                        return PunchClock.Domain.Entities.Enums.PunchType.None;
                }
            }
        }
    }
}