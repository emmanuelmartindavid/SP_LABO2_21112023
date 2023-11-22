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

insert into Huespedes (Dni, Nombre, Apellido, NumeroTelefono) values (43437966, 'Betsy', 'Bedder', '1512617128');
insert into Huespedes (Dni, Nombre, Apellido, NumeroTelefono) values (37287832, 'Cyndi', 'Limeburner', '8334800581');
insert into Huespedes (Dni, Nombre, Apellido, NumeroTelefono) values (42139134, 'Karrah', 'Culp', '7947625867');
insert into Huespedes (Dni, Nombre, Apellido, NumeroTelefono) values (41862762, 'Brion', 'Dionsetti', '6661941281');
insert into Huespedes (Dni, Nombre, Apellido, NumeroTelefono) values (32086441, 'Anette', 'Fearney', '1845210925');
insert into Huespedes (Dni, Nombre, Apellido, NumeroTelefono) values (49505980, 'Bron', 'Puttrell', '8658331386');
insert into Huespedes (Dni, Nombre, Apellido, NumeroTelefono) values (47945530, 'Jenn', 'MacNeilley', '5849690584');
insert into Huespedes (Dni, Nombre, Apellido, NumeroTelefono) values (43785590, 'Laural', 'Huggons', '3352350386');
insert into Huespedes (Dni, Nombre, Apellido, NumeroTelefono) values (47833216, 'Anabelle', 'Binder', '2326439160');
insert into Huespedes (Dni, Nombre, Apellido, NumeroTelefono) values (34886137, 'Maura', 'Sandry', '1879525954');


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
