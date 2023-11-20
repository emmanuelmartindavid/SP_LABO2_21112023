CREATE TABLE Huespedes(
Dni INT NOT NULL,
Nombre VARCHAR(50) NOT NULL,
Apellido VARCHAR(50) NOT NULL,
NumeroTelefono BIGINT NOT NULL,
PRIMARY KEY(Dni)
);

CREATE TABLE Habitaciones(
Numero INT NOT NULL,
Disponible BIT NOT NULL,
Tipo INT NOT NULL,
PRIMARY KEY(Numero)
);

CREATE TABLE Reservaciones(
DniHuesped INT NOT NULL,
CheckIn DATETIME NOT NULL,
CheckOut DATETIME NOT NULL,
NumeroHabitacion INT NOT NULL,
FOREIGN KEY (DniHuesped) REFERENCES Huespedes(Dni),
FOREIGN KEY (NumeroHabitacion) REFERENCES Habitaciones(Numero)
);


--DROP TABLE Huespedes;
--DROP TABLE Habitaciones;
--DROP TABLE Reservaciones;

insert into Habitaciones (Numero, Disponible, Tipo) values (101, 1, 0);
insert into Habitaciones (Numero, Disponible, Tipo) values (102, 1, 0);
insert into Habitaciones (Numero, Disponible, Tipo) values (103, 1, 0);
insert into Habitaciones (Numero, Disponible, Tipo) values (104, 1, 0);
insert into Habitaciones (Numero, Disponible, Tipo) values (105, 1, 0);
insert into Habitaciones (Numero, Disponible, Tipo) values (106, 1, 0);
insert into Habitaciones (Numero, Disponible, Tipo) values (107, 1, 0);
insert into Habitaciones (Numero, Disponible, Tipo) values (108, 1, 0);
insert into Habitaciones (Numero, Disponible, Tipo) values (109, 1, 0);
insert into Habitaciones (Numero, Disponible, Tipo) values (110, 1, 0);
insert into Habitaciones (Numero, Disponible, Tipo) values (111, 1, 1);
insert into Habitaciones (Numero, Disponible, Tipo) values (112, 1, 1);
insert into Habitaciones (Numero, Disponible, Tipo) values (113, 1, 1);
insert into Habitaciones (Numero, Disponible, Tipo) values (114, 1, 1);
insert into Habitaciones (Numero, Disponible, Tipo) values (115, 1, 1);
insert into Habitaciones (Numero, Disponible, Tipo) values (116, 1, 1);
insert into Habitaciones (Numero, Disponible, Tipo) values (117, 1, 1);
insert into Habitaciones (Numero, Disponible, Tipo) values (118, 1, 1);
insert into Habitaciones (Numero, Disponible, Tipo) values (119, 1, 1);
insert into Habitaciones (Numero, Disponible, Tipo) values (120, 1, 1);

