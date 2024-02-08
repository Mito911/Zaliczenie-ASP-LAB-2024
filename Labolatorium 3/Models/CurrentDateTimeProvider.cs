namespace Laboratorium_3___App_ns.Models
{
    using Labolatorium_3.Models;
    using System;

    public class CurrentDateTimeProvider : IDateTimeProvider
    {
        public DateTime GetCurrentDateTime()
        {
            return DateTime.Now;
        }
    }
}
