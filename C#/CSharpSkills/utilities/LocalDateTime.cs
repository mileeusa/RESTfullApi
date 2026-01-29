using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Skills.utilities
{
    public struct LocalDateTime
    {
        public DateTime Date { get; }
        public readonly int Year => Date.ToLocalTime().Year;
        public readonly int Month => Date.ToLocalTime().Month;
        public readonly int Day => Date.ToLocalTime().Day;

        public DateTime TimeOfDay {  get; }
        public readonly int Hour => Date.ToLocalTime().Hour;
        public readonly int Minute => Date.ToLocalTime().Minute;
        public readonly int Second => Date.ToLocalTime().Second;
    }
}
