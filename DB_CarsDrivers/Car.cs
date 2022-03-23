using System;
using System.Collections.Generic;

namespace DB_CarsDrivers
{
    public partial class Car
    {
        public Car()
        {
            CarDrivers = new HashSet<CarDriver>();
        }

        public string NumberCar { get; set; } = null!;
        public string? Brand { get; set; }
        public string? Model { get; set; }
        public short? YearOfRelease { get; set; }
        public string? Color { get; set; }
        public string? Vin { get; set; }

        public virtual ICollection<CarDriver> CarDrivers { get; set; }
    }
}
