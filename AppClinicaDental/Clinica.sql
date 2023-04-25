Create database [Clinica]

use [Clinica]
Create table Cita
(Cedula int not null primary key,
Nombre varchar(100) not null,
Fecha datetime not null,
MontoTotal decimal not null,
MontoPorAdelantado decimal  not null,
Email varchar(200) not null,
Procedimiento int  not null,
MontoIva decimal not null);

drop table Cita;
select * from cita; 