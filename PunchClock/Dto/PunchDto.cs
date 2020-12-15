using System;

namespace PunchClock.Dto
{
    public class PunchDto
    {
        public Guid EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public DateTimeOffset DateTime { get; set; }
        public char PunchType { get; set; }
    }
}