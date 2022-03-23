using System;
using System.Collections.Generic;

namespace DB_CarsDrivers
{
    public partial class Viewdriver
    {
        public string NumberDrCertificate { get; set; } = null!;
        public string? LastName { get; set; }
        public string? FirstName { get; set; }
        public string? Patronymic { get; set; }
        public DateOnly? DateOfIssueCert { get; set; }
        public string? Phone { get; set; }
    }
}
