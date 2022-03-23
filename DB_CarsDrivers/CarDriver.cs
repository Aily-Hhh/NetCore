using System;
using System.Collections.Generic;

namespace DB_CarsDrivers
{
    public partial class CarDriver
    {
        public int NumberCd { get; set; }
        public string? NumberCar { get; set; }
        public string? NumberDrCertificate { get; set; }
        public DateOnly? StartDate { get; set; }
        public DateOnly? EndDate { get; set; }

        public virtual Car? NumberCarNavigation { get; set; }
        public virtual Driver? NumberDrCertificateNavigation { get; set; }
    }
}
