using DB_CarsDrivers;

using (CarsDriversContext db = new CarsDriversContext())
{
    // получаем объекты из бд и выводим на консоль
    var cars = db.Cars.ToList();
    var drivers = db.Drivers.ToList();
    var carDriver = db.CarDrivers.ToList();

    Console.WriteLine("Машины, произведенные с 2000г по 2006г:");
    foreach (Car c in cars)
    {
        if (c.YearOfRelease >= 2000 && c.YearOfRelease <= 2006)
            Console.WriteLine($"\t{c.NumberCar} {c.Brand} {c.Model} {c.YearOfRelease}");
    }

    Console.WriteLine("\nФамилии водителей, заканчиввающиеся на -ов :");
    foreach (Driver d in drivers)
    {
        if (d.LastName.ToLower().EndsWith("ов"))
            Console.WriteLine($"\t{d.LastName} {d.FirstName} {d.Patronymic} {d.Phone}");
    }
}