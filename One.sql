create database CarsDrivers;
use CarsDrivers;

create table Cars
(
	NumberCar varchar(15) primary key,
    Brand varchar(30),
    Model varchar(30),
    YearOfRelease year,
    Color varchar(60),
    VIN varchar(25)
);

create table Drivers
(
	NumberDrCertificate varchar(20) primary key,
    FirstName varchar(20),
    LastName varchar(20),
    Patronymic varchar(20),
    DateOfIssueCert date
);

create table Car_Driver
(
	NumberCD int auto_increment primary key,
    NumberCar varchar(15),
    NumberDrCertificate varchar(20),
    StartDate date,
    EndDate date
);
alter table Car_Driver add
(
	foreign key (NumberCar) references Cars (NumberCar) on update cascade,
    foreign key (NumberDrCertificate) references Drivers (NumberDrCertificate) on update cascade
);

insert Cars(NumberCar, Brand, Model, YearOfRelease, Color, VIN) 
values
	('а111аа', 'Audi', 'A1', 2003, 'Black', '3KPF24AD6M5263104'),
    ('в222вв', 'Kia', 'Stringer', 2007, 'White', 'KNDCB3LC2M5'),
    ('с333сс', 'Honda', 'Crider', 2009, 'White', 'KNDC44LA9N5'),
    ('у444уу', 'Audi', 'A6', 2015, 'Black', 'KNALN2D72G5'),
    ('к555кк', 'Honda', 'Crosstour', 2005, 'Blue', '3KPFL4A70HE'),
    ('е666ее', 'Ford', 'Bronco', 2006, 'White', 'KNALD124845'),
    ('х777хх', 'Kia', 'Sportage', 2022, 'Orange', 'KNALD124545'),
    ('р888рр', 'Lexus', 'LX', 2018, 'White', 'KNALD124X45'),
    ('о999оо', 'Audi', 'A4', 2012, 'Black', 'KNALD124455'),
    ('м101мм', 'Lexus', 'LX', 2019, 'Black', 'KNALD12U255'),
    ('т112тт', 'Honda', 'Gienia', 2007, 'Blue', 'KNADM4A34C6'),
    ('а121вв', 'Audi', 'A1', 2005, 'Orange', 'KNADM5A37C6');
    
alter table Drivers add phone varchar(20);

insert Drivers(NumberDrCertificate, LastName, FirstName, Patronymic, DateOfIssueCert, phone) 
values
	('0101123456','Иванов','Алексей','Сергеевич',date('2002-01-01'), '89049562665'),
    ('0202123456','Захаров','Лев','Владимирович',date('2002-06-15'), '89069232323'),
    ('0303123456','Ильин','Иван','Богданович',date('2011-04-01'), '89549868512'),
    ('0404123456','Соловьев','Даниил','Тимурович',date('2020-01-06'), '89239512027'),
    ('0505123456','Зайцева','Ангелина','Максимовна',date('2005-02-01'), '89219521496'),
    ('0606123456','Кузьмин','Платон','Александрович',date('2002-05-01'), '89869748565'),
    ('0707123456','Чумакова','София','Владимировна',date('2017-01-01'), '89279276996'),
    ('0808123456','Корнеева','Алиса','Александровна',date('2015-08-11'), '89089044823'),
    ('0909123456','Назаров','Кирилл','Даниилович',date('2008-04-01'), '89129734957'),
    ('1010123456','Повлова','Вероника','Андреевна',date('2014-11-09'), '89029412973');

insert Car_Driver(NumberCar, NumberDrCertificate, StartDate, EndDate)
values
	('а111аа', '0909123456', date('2015-01-03'), date('2025-01-03')),
    ('в222вв', '0505123456', date('2015-01-03'), date('2025-01-03')),
    ('с333сс', '0101123456', date('2015-01-03'), date('2025-01-03')),
    ('у444уу', '0808123456', date('2015-01-03'), date('2025-01-03')),
    ('а121вв', '0707123456', date('2015-01-03'), date('2025-01-03')),
    ('е666ее', '0707123456', date('2015-01-03'), date('2025-01-03')),
    ('х777хх', '0202123456', date('2015-01-03'), date('2025-01-03')),
    ('р888рр', '1010123456', date('2015-01-03'), date('2025-01-03')),
    ('о999оо', '0303123456', date('2015-01-03'), date('2025-01-03')),
    ('м101мм', '0606123456', date('2015-01-03'), date('2025-01-03')),
    ('т112тт', '0404123456', date('2015-01-03'), date('2025-01-03'));


select NumberCar, Brand, Model, YearOfRelease from Cars where YearOfRelease between 2000 and 2006;
select LastName, FirstName, Patronymic, phone from Drivers where LastName like('%ов');
select LastName, FirstName, Patronymic from Drivers where DateOfIssueCert = (select min(DateOfIssueCert) from Drivers);
select LastName, FirstName, Patronymic, phone from Drivers natural join Car_Driver 
	group by NumberDrCertificate having count(NumberDrCertificate) >= 2;

select Brand, Model, count(Model) as Count from Cars group by Brand, Model order by Brand, Model;

create view viewDrivers as select * from Drivers;
create view viewCars2005_2007 as select Brand, Model, Color, YearOfRelease from Cars where YearOfRelease between 2005 and 2007;





