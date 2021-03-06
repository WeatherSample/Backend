create schema if not exists forecast collate utf8_general_ci;

use forecast;
create table if not exists cities
(
    CityName varchar(255) unique not null
) engine = INNODB;

create table forecast
(
    CityName    varchar(255) not null,
    Description varchar(255) not null,
    WindSpeed   double       not null,
    Humidity    long         not null,
    Pressure    long         not null,
    TempMin     double       not null,
    TempMax     double       not null,
    FeelsLike   double       not null,
    Temp        double       not null,
    `LocalTime` varchar(255) not null
) engine = INNODB;

alter table forecast
    add constraint forecast_cities__fk
        foreign key (CityName) references cities (CityName)
            on delete cascade;
