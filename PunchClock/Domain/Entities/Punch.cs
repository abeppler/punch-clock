using System;
using PunchClock.Domain.Entities.Enums;

namespace PunchClock.Domain.Entities
{
    public class Punch
    {
        public Guid Id { get; set; }
        public Guid EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public DateTimeOffset DateTime { get; set; }
        public PunchType PunchType { get; set; }
    }
}