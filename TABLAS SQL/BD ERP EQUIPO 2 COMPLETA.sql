Create database ERP
use ERP


-----------------------VENTAS--------------------------------
----SalesVentaDetalle
create table SalesVentaDetalle(
   idVentaDetalle int primary key not null IDENTITY(1,1),
   precioVenta float not null,
   cantidad float not null,
   subtotal float not null,
   idVenta int not null,
   estatus char not null,
)


---SalesOfertasAsociacion
create table SalesOfertasAsociacion(
idAsosiacion int not null IDENTITY(1,1),
idOferta int not null,
estatus char not null,
CONSTRAINT PK_OfertaAsociacion PRIMARY KEY (idAsosiacion,idOferta),
)


---SalesAsociaciones
create table SalesAsociaciones(
idAsosiacion int primary key not null IDENTITY(1,1),
nombre varchar(100) not null,
estatus char not null,
)

select * from SalesAsociaciones




---SalesMiembros
create table SalesMiembros(
idCliente int not null IDENTITY(1,1),
idAsosiacion int not null,
estatus char not null,
fechaIncorporacion date not null,
CONSTRAINT PK_Miembros PRIMARY KEY (idAsosiacion,idCliente),
)

select * from SalesMiembros
delete from SalesMiembros where idCliente = 1






---SalesCultivos
create table SalesCultivos(
    idCultivo   int primary key not null IDENTITY(1,1),
	nombre   varchar(100) not null,
	costoAsesoria float not null,
	estatus  char not null,
)







---SalesClientes
create table SalesClientes(
idCliente int primary key not null IDENTITY(1,1),
nombre varchar(100) not null,
razonSocial varchar(100) not null,
limiteCredito float not null,
rfc char(13) not null,
telefono char(12) not null,
email varchar(100) not null,
tipo char not null,
estatus char not null,
)
delete from SalesClientes where idCliente = 2
select * from SalesClientes

select idCliente, nombre from SalesClientes where nombre = 'ALEX'


insert into SalesClientes values(3,'ALEX','VENTAS',500,'ABC680524','3512634896','alex@gmail.com','A')
insert into SalesClientes values(4,'Gabino','VENTAS',800,'ABC680896','3512634239','gabino@gmail.com','A')
insert into SalesClientes values(5,'Alberto','VENTAS',700,'ABR680524','3512638689','alberto@gmail.com','A')
insert into SalesClientes values(6,'Alfonso','VENTAS',600,'ABC680896','3512633689','alfonso@gmail.com','A')
insert into SalesClientes values(7,'Andreas','VENTAS',300,'Ale680178','3512634899','andreas@gmail.com','A')
insert into SalesClientes values(8,'Bento','VENTAS',800,'AENC687924','3512634779','Bento@gmail.com','A')
insert into SalesClientes values(9,'Carlos','VENTAS',600,'CAL680584','3512634769','carlos@gmail.com','A')

insert into SalesClientes values(10,'Diego','VENTAS',600,'DIE680524','3512634969','diego@gmail.com','A')
insert into SalesClientes values(11,'Edgar','VENTAS',700,'EDG680524','3512634569','edgar@gmail.com','A')




-------------------------------------------------------------------sp_listar_SalesClientes
create proc sp_listar_SalesClientes
@tab_inicio int,
@tab_final int
as
declare @tablita_SalesClientes table
(
idCliente int primary key not null IDENTITY(1,1),
nombre varchar(100) not null,
razonSocial varchar(100) not null,
limiteCredito float not null,
rfc char(13) not null,
telefono char(12) not null,
email varchar(100) not null,
tipo char not null,
estatus char not null
)
insert into @tablita_SalesClientes
(
idCliente,nombre,razonSocial,limiteCredito,rfc,telefono,email,tipo
)

select ROW_NUMBER() over(order by idCliente asc)idCliente,nombre,razonSocial,limiteCredito,rfc,telefono,email,tipo,estatus from SalesClientes
select count(*) as cantidad from @tablita_SalesClientes
select * from @tablita_SalesClientes where idCliente between @tab_inicio and @tab_final

go

exec sp_listar_SalesClientes 1,10
------------------------------------------------------------------------------sp_listar_SalesClientes



---SalesVentas
create table SalesVentas(
idVenta int primary key not null IDENTITY(1,1),
fecha date not null,
subtotal float not null,
iva float not null,
total float not null,
cantPagada float not null,
comentarios varchar(100),
estatus char not null,
tipo char not null,
idCliente int not null,
idSucursal int not null,
idEmpleado int not null,
)



---SalesDireccionesCliente
create table SalesDireccionesCliente(
idDireccion int primary key not null IDENTITY(1,1),
calle varchar(100) not null,
numero varchar(15) not null,
colonia varchar(100) not null,
codigoPostal varchar(5) not null,
tipo char not null,
idCliente int not null,
idCiudad int not null,
estatus char not null,
)
select * from SalesDireccionesCliente
delete SalesDireccionesCliente where idDireccion = 1

-------------------------------------------------------------------sp_listar_SalesDireccionesCliente
create proc sp_listar_SalesDireccionesCliente
@tab_inicio int,
@tab_final int
as
declare @tablita_SalesDireccionesCliente table
(
idDireccion int primary key not null IDENTITY(1,1),
calle varchar(100) not null,
numero varchar(15) not null,
colonia varchar(100) not null,
codigoPostal varchar(2) not null,
tipo char not null,
idCliente int not null,
idCiudad int not null,
estatus char not null
)
insert into @tablita_SalesDireccionesCliente
(
idDireccion,calle,numero,colonia,codigoPostal,tipo,idCliente,idCiudad
)

select ROW_NUMBER() over(order by idDireccion asc)idDireccion,calle,numero,colonia,codigoPostal,tipo,idCliente,idCiudad,estatus from SalesDireccionesCliente
select count(*) as cantidad from @tablita_SalesDireccionesCliente
select * from @tablita_SalesDireccionesCliente where idDireccion between @tab_inicio and @tab_final

go

exec sp_listar_SalesDireccionesCliente 1,10





--SalesParcelas
create table SalesParcelas(
idParcela int primary key not null IDENTITY(1,1),
extension float not null,
idCliente int not null,
idCultivo int not null,
idDireccion int not null,
estatus char not null,
)
select * from SalesParcelas
delete SalesParcelas where idParcela = 2
---JOIN -PARA PARCELAS
select  SalesClientes.idCliente, SalesDireccionesCliente.idDireccion, SalesClientes.nombre, SalesDireccionesCliente.calle, SalesDireccionesCliente.colonia
 from SalesDireccionesCliente JOIN SalesClientes ON SalesDireccionesCliente.idCliente = SalesClientes.idCliente
         
--JOIN CON LAS TABLAS SalePareclas, SalesClientes, SalesDireccionesCliente

select SalesParcelas.idParcela, SalesParcelas.extension, SalesParcelas.idCliente, SalesParcelas.idCultivo, SalesParcelas.idDireccion, SalesParcelas.estatus, SalesClientes.nombre, SalesDireccionesCliente.calle, SalesDireccionesCliente.colonia
from SalesParcelas inner JOIN SalesClientes ON SalesParcelas.idCliente = SalesClientes.idCliente
inner JOIN SalesDireccionesCliente ON SalesDireccionesCliente.idCliente = SalesParcelas.idCliente

select * from SalesParcelas

         




---SalesTripulacion
create table SalesTripulacion(
idEmpleado int not null IDENTITY(1,1),
idEnvio int not null,
rol varchar(50) not null,
estatus char not null,
CONSTRAINT PK_Tripulacion PRIMARY KEY (idEmpleado,idEnvio,rol),
)

---SalesCobro
create table SalesCobros(
idCobro int primary key not null IDENTITY(1,1),
fecha date not null,
importe float not null,
idVenta int not null,
estatus char not null,
)

---SalesDetallesEnvio
create table SalesDetallesEnvio(
idEnvio int not null IDENTITY(1,1),
idVenta int not null,
idDireccion int not null,
fechaEntregaPlaneada date not null,
peso float not null,
estatus char not null,
idContacto int not null,
CONSTRAINT PK_Detalles_Envio PRIMARY KEY (idEnvio,idVenta),
)


--SalesUnidadesTransporte
create table SalesUnidadesTransporte(
idUnidadTransporte int primary key not null IDENTITY(1,1),
placas varchar(10) not null,
marca varchar(80) not null,
modelo varchar(80) not null,
anio int not null,
capacidad int not null,
tipo varchar(30) not null,
estatus char not null,
)
select * from SalesUnidadesTransporte


-------------------------------------------------------------------sp_listar_SalesUnidadesTransporte
create proc sp_listar_SalesUnidadesTransporte
@tab_inicio int,
@tab_final int
as
declare @tablita_SalesUnidadesTransporte table
(
idUnidadTransporte int primary key not null IDENTITY(1,1),
placas varchar(10) not null,
marca varchar(80) not null,
modelo varchar(80) not null,
anio int not null,
capacidad int not null,
tipo varchar(30) not null,
estatus char not null
)
insert into @tablita_SalesUnidadesTransporte
(
idUnidadTransporte,placas,marca,modelo,anio,capacidad,tipo,estatus
)

select ROW_NUMBER() over(order by idUnidadTransporte asc)idUnidadTransporte,placas,marca,modelo,anio,capacidad,tipo,estatus from SalesUnidadesTransporte
select count(*) as cantidad from @tablita_SalesUnidadesTransporte
select * from @tablita_SalesUnidadesTransporte where idUnidadTransporte between @tab_inicio and @tab_final

go

exec sp_listar_SalesUnidadesTransporte 1,10
--------------------------------------------------------------sp_listar_SalesUnidadesTransporte





--SalesContactosCliente
create table SalesContactosCliente(
idContacto int primary key not null IDENTITY(1,1),
nombre varchar(100) not null,
telefono varchar(12) not null,
email varchar(100) not null,
idCliente int not null,
estatus char not null,
)

select * from SalesContactosCliente
alter table SalesContactosCliente add estatus char not null
delete SalesContactosCliente where idContacto = 1






---SalesAsesorias
create table SalesAsesorias(
idAsesoria int primary key not null IDENTITY(1,1),
fecha date not null,
comentarios varchar(200) not null,
estatus char not null,----A O I
costo float not null,
idParcela int not null,
idEmpleado int not null, 
idUnidadTransporte int not null,
)

select * from SalesAsesorias
select * from SalesParcelas
select * from SalesUnidadesTransporte
select * from empleadoss
insert into SalesAsesorias values(1,'15-JUN-2020','Mantenimiento','A',2500,1,1,1)

-------------------------------------------------------------------sp_listar_SalesAsesorias
create proc sp_listar_SalesAsesorias
@tab_inicio int,
@tab_final int
as
declare @tablita_SalesAsesorias table
(
idAsesoria int primary key not null IDENTITY(1,1),
fecha date not null,
comentarios varchar(200) not null,
estatus char not null,----A O I
costo float not null,
idParcela int not null,
idEmpleado int not null, 
idUnidadTransporte int not null
)
insert into @tablita_SalesAsesorias
(
idAsesoria,fecha,comentarios,estatus,costo,idParcela,idEmpleado,idUnidadTransporte
)

select ROW_NUMBER() over(order by idAsesoria asc)idAsesoria,fecha,comentarios,estatus,costo,idParcela,idEmpleado,idUnidadTransporte from SalesAsesorias
select count(*) as cantidad from @tablita_SalesAsesorias
select * from @tablita_SalesAsesorias where idAsesoria between @tab_inicio and @tab_final

go

exec sp_listar_SalesAsesorias 1,10
--------------------------------------------------------------sp_listar_SalesUnidadesTransporte










---SalesEnvios
create table SalesEnvios(
idEnvio int primary key not null IDENTITY(1,1),
fechaInicio date not null,
fechaFin date not null,
idUnidadTransporte int not null,
pesoTotal float not null,
estatus char not null,
)


--SalesMantenimiento
create table SalesMantenimiento(
idMantenimiento int primary key not null IDENTITY(1,1),
fechaInicio date not null,
fechaFin date not null,
taller varchar(100) not null,
costo float not null,
comentarios varchar(200),
tipo varchar(30) not null,
idUnidadTransporte int not null,
estatus char not null,
)
select * from SalesMantenimiento



----------------PAGIANCION DE TABLAS ----------------------------















-------------------------------------------------------------------sp_listar_SalesMantenimiento

create proc sp_listar_SalesMantenimiento
@tab_inicio int,
@tab_final int
as
declare @tablita_SalesMantenimiento table
(
idMantenimiento int primary key not null IDENTITY(1,1),
fechaInicio date not null,
fechaFin date not null,
taller varchar(100) not null,
costo float not null,
comentarios varchar(200),
tipo varchar(30) not null,
idUnidadTransporte int not null,
estatus char not null
)
insert into @tablita_SalesMantenimiento
(
idMantenimiento,fechaInicio,fechaFin,taller,costo,comentarios,tipo,idUnidadTransporte,estatus
)

select ROW_NUMBER() over(order by idMantenimiento asc)idMantenimiento,fechaInicio,fechaFin,taller,costo,comentarios,tipo,idUnidadTransporte,estatus from SalesMantenimiento
select count(*) as cantidad from @tablita_SalesMantenimiento
select * from @tablita_SalesMantenimiento where idMantenimiento between @tab_inicio and @tab_final

go

exec sp_listar_SalesMantenimiento 1,10
--------------------------------------------------------------sp_listar_SalesMantenimiento

DROP PROCEDURE sp_listar_SalesContactosCliente
GO 
---------------------------------------sp_listar_SalesContactosCliente
create proc sp_listar_SalesContactosCliente
@tab_inicio int,
@tab_final int
as
declare @tablita_SalesContactosCliente table
(
idContacto int primary key not null IDENTITY(1,1),
nombre varchar(100) not null,
telefono varchar(12) not null,
email varchar(100) not null,
idCliente int not null,
estatus char not null
)
insert into @tablita_SalesContactosCliente
(
idContacto,nombre,telefono,email,idCliente,estatus
)

select ROW_NUMBER() over(order by idContacto asc)idContacto,nombre,telefono,email,idCliente,estatus from SalesContactosCliente
select count(*) as cantidad from @tablita_SalesContactosCliente
select * from @tablita_SalesContactosCliente where idContacto between @tab_inicio and @tab_final

go

exec sp_listar_SalesContactosCliente 1,10
--------------------------------------------------------------------sp_listar_SalesContactosCliente
DROP PROCEDURE sp_listar_SalesParcelas  
GO 
--------------------------------------------------------------------sp_listar_SalesParcelas
create proc sp_listar_SalesParcelas
@tab_inicio int,
@tab_final int

as
declare @tablita_SalesParcelas table
(
idParcela int primary key not null IDENTITY(1,1),
extension float not null,
idCliente int not null,
idCultivo int not null,
idDireccion int not null,
estatus char not null
)
insert into @tablita_SalesParcelas
(
idParcela,extension,idCliente,idCultivo,idDireccion,estatus
)
select ROW_NUMBER() over(order by idParcela asc)idParcela,extension,idCliente,idCultivo,idDireccion,estatus from SalesParcelas
select count(*) as cantidad from @tablita_SalesParcelas
select * from @tablita_SalesParcelas where idParcela between @tab_inicio and @tab_final


select SalesParcelas.idParcela, SalesParcelas.extension, SalesParcelas.idCliente, SalesParcelas.idCultivo, SalesParcelas.idDireccion, SalesParcelas.estatus, SalesClientes.nombre, SalesDireccionesCliente.calle, SalesDireccionesCliente.colonia, SalesCultivos.nombre from SalesParcelas 
JOIN SalesClientes ON SalesParcelas.idCliente = SalesClientes.idCliente 
JOIN SalesDireccionesCliente ON SalesDireccionesCliente.idDireccion = SalesParcelas.idDireccion
JOIN SalesCultivos ON SalesCultivos.idCultivo = SalesParcelas.idCultivo

select SalesParcelas.idParcela, SalesParcelas.extension, SalesParcelas.idCliente, SalesParcelas.idCultivo, SalesParcelas.idDireccion, SalesParcelas.estatus, SalesClientes.nombre, SalesDireccionesCliente.calle, SalesDireccionesCliente.colonia, SalesCultivos.nombre from SalesParcelas JOIN SalesClientes ON SalesParcelas.idCliente = SalesClientes.idCliente  JOIN SalesDireccionesCliente ON SalesDireccionesCliente.idDireccion = SalesParcelas.idDireccion JOIN SalesCultivos ON SalesCultivos.idCultivo = SalesParcelas.idCultivo


SELECT * FROM SalesParcelas

go

exec sp_listar_SalesParcelas 1,10



--------------------------------------------------------------------sp_listar_SalesParcelas


---paginacion de salesCultivos-----
create proc sp_listar_SalesCultivos
@tab_inicio int,
@tab_final int
as
declare @tablita_SalesCultivos table
(
idCultivo   int primary key not null IDENTITY(1,1),
nombre   varchar(100) not null,
costoAsesoria float not null,
estatus  char not null
)
insert into @tablita_SalesCultivos
(
idCultivo,nombre,costoAsesoria,estatus
)

select ROW_NUMBER() over(order by idCultivo asc)idCultivo,nombre,costoAsesoria,estatus from SalesCultivos
select count(*) as cantidad from @tablita_SalesCultivos
select * from @tablita_SalesCultivos where idCultivo between @tab_inicio and @tab_final

go

exec sp_listar_SalesCultivos 1,10

---------------------------------------------------------------------------------------------------paginacion de salescultivos-------------------


------pag de salesMiembros------
create proc sp_listar_SalesMiembros
@tab_inicio int,
@tab_final int
as
declare @tablita_SalesMiembros table
(
idCliente int not null IDENTITY(1,1),
idAsosiacion int not null,
estatus char not null,
fechaIncorporacion date not null
)
insert into @tablita_SalesMiembros
(
idCliente,idAsosiacion,estatus,fechaIncorporacion
)

select ROW_NUMBER() over(order by idCliente asc)idCliente,idAsosiacion,estatus,fechaIncorporacion from SalesMiembros
select count(*) as cantidad from @tablita_SalesMiembros
select * from @tablita_SalesMiembros where idCliente between @tab_inicio and @tab_final

go

exec sp_listar_SalesMiembros 1,10

----------------------------------------------sp_listar_SalesMiembros



---------------------------------------sp_listar_SalesAsociaciones
create proc sp_listar_SalesAsociaciones
@tab_inicio int,
@tab_final int
as
declare @tablita_SalesAsociaciones table
(
idAsosiacion int primary key not null IDENTITY(1,1),
nombre varchar(100) not null,
estatus char not null
)
insert into @tablita_SalesAsociaciones
(
idAsosiacion,nombre,estatus
)

select ROW_NUMBER() over(order by idAsosiacion asc)idAsosiacion,nombre,estatus from SalesAsociaciones
select count(*) as cantidad from @tablita_SalesAsociaciones
select * from @tablita_SalesAsociaciones where idAsosiacion between @tab_inicio and @tab_final

go

exec sp_listar_SalesAsociaciones 1,10
--------------------------------------------------------------------sp_listar_SalesAsociaciones











------FK DE VENTAS-----------

alter table SalesVentaDetalle add constraint FK_VentaDetalle_Ventas
foreign key(idVenta) references SalesVentas(idVenta)
go 

alter table SalesOfertasAsociacion add constraint FK_OfertaAsociacion_Asociacion
foreign key(idAsosiacion) references SalesAsociaciones(idAsosiacion)
go 

alter table SalesOfertasAsociacion add constraint FK_OfertaAsociacion_Ofertas
foreign key(idOferta) references Ofertas(idOferta)--ejecuta tabla ofertas
go 

alter table SalesMiembros add constraint FK_Miembros_Clientes
foreign key(idCliente) references SalesClientes(idCliente)
go 

alter table SalesMiembros add constraint FK_Miembros_Asociaciones
foreign key(idAsosiacion) references SalesAsociaciones(idAsosiacion)
go


alter table SalesVentas add constraint FK_Ventas_Clientes
foreign key(idCliente) references SalesClientes(idCliente)
go

alter table SalesVentas add constraint FK_Ventas_Empleado
foreign key(idEmpleado) references Empleados(idEmpleado)--tabla empleados
go

alter table SalesVentas add constraint FK_Ventas_Sucursales
foreign key(idSucursal) references Sucursales(idSucursal)---tabla sucursales
go

alter table SalesDireccionesCliente add constraint FK_Direcciones_Cliente_Clientes
foreign key(idCliente) references SalesClientes(idCliente)
go

alter table SalesDireccionesCliente add constraint FK_Direcciones_Cliente_Ciudades
foreign key(idCiudad) references Ciudades(idCiudad)--tabla cuidades
go

alter table SalesParcelas add constraint FK_Parcelas_Clientes
foreign key(idCliente) references SalesClientes(idCliente)
go

alter table SalesParcelas add constraint FK_Parcelas_Cultivos
foreign key(idCultivo) references SalesCultivos(idCultivo)
go


alter table SalesParcelas add constraint FK_Direcciones_Cliente
foreign key(idDireccion) references SalesDireccionesCliente(idDireccion)
go

alter table SalesTripulacion add constraint FK_Tripulacion_Envios
foreign key(idEnvio) references SalesEnvios(idEnvio)
go

alter table SalesTripulacion add constraint FK_Tripulacion_Empleados
foreign key(idEmpleado) references Empleados(idEmpleado)
go


alter table SalesCobros add constraint FK_Cobros_Ventas
foreign key(idVenta) references SalesVentas(idVenta)
go


alter table SalesDetallesEnvio add constraint FK_Detalles_Envio_Envios
foreign key(idEnvio) references SalesEnvios(idEnvio)
go



alter table SalesDetallesEnvio add constraint FK_Detalles_Envio_Ventas
foreign key(idVenta) references SalesVentas(idVenta)
go


alter table SalesDetallesEnvio add constraint FK_Detalles_Envio_Direcciones_Cliente
foreign key(idDireccion) references SalesDireccionesCliente(idDireccion)
go

alter table SalesDetallesEnvio add constraint FK_Detalles_Envio_ContactosCliente
foreign key(idContacto) references SalesContactosCliente(idContacto)
go


alter table SalesContactosCliente add constraint FK_ContactosCliente_Clientes
foreign key(idCliente) references SalesClientes(idCliente)
go


alter table SalesAsesorias add constraint FK_Asesorias_clientesCultivos
foreign key(idParcela) references SalesParcelas(idParcela)
go


alter table SalesAsesorias add constraint FK_Asesorias_UnidadesTransporte
foreign key(idUnidadTransporte) references SalesUnidadesTransporte(idUnidadTransporte)
go

alter table SalesAsesorias add constraint FK_Asesorias_Empleados
foreign key(idEmpleado) references Empleados(idEmpleado)
go

ALTER TABLE SalesAsesorias
   DROP CONSTRAINT FK_Asesorias_Empleados



alter table SalesEnvios add constraint FK_EnviosVentas_UnidadesTransporte
foreign key(idUnidadTransporte) references SalesUnidadesTransporte(idUnidadTransporte)
go



alter table SalesMantenimiento add constraint FK_Mantenimiento_UnidadesTransporte
foreign key(idUnidadTransporte) references SalesUnidadesTransporte(idUnidadTransporte)
go






----------------RECURSOS HUMANOS--------------------

Create Table FormasPago(
idFormaPago int primary key NOT NULL,
nombre varchar(50) NOT NULL,
estatus char NOT NULL
)

Create Table Periodos(
idPeriodo int primary key NOT NULL,
nombre varchar(50) NOT NULL,
fechaInicio date NOT NULL,
fechaFin date NOT NULL,
estatus char NOT NULL
)

Create Table Deducciones(
idDeduccion int primary key NOT NULL,
nombre varchar(30) NOT NULL,
descripcion varchar(80) NOT NULL,
porcentaje float NOT NULL
) 

Create Table Percepciones(
idPercepcion int primary key NOT NULL,
nombre varchar(30) NOT NULL,
descripcion varchar(80) NOT NULL,
diasPagar int NOT NULL
)

Create Table Puestos(
idPuesto int primary key NOT NULL,
nombre varchar(60) NOT NULL,
salarioMinimo float NOT NULL,
salarioMaximo float NOT NULL,
estatus char NOT NULL
)

Create Table Departamentos(
idDepartamento int primary key NOT NULL,
nombre varchar(50) NOT NULL,
estatus char NOT NULL
)

Create Table Turnos(
idTurno int primary key NOT NULL,
nombre varchar(20) NOT NULL,
horaInicio date NOT NULL,
horaFin date NOT NULL,
dias varchar(30) NOT NULL
)

Create Table Estados(
idEstado int primary key NOT NULL,
nombre varchar(60) NOT NULL,
siglas varchar(10) NOT NULL,
estatus char NOT NULL
)

Create Table Ciudades(
idCiudad int primary key NOT NULL,
nombre varchar(80) NOT NULL,
idEstado int NOT NULL,
estatus char NOT NULL,

)
select * from Ciudades

insert into Ciudades values(2,'Los Reyes',1,'A')
insert into Ciudades values(3,'Morelia',1,'A')
insert into Ciudades values(4,'Uruapan',1,'A')


Create Table Empleados(
idEmpleado int primary key NOT NULL IDENTITY(1,1),
nombre varchar(30) NOT NULL,
apellidoPaterno varchar(30),
apellidoMaterno varchar(30),
sexo char,
fechaNacimiento date,
curp varchar(20),
estadoCivil varchar(20),
fechaContratacion date,
salarioDiario float,
nss varchar(10),
diasVacaciones int,
diasPermiso int,
fotografia image,
direccion varchar(80),
colonia varchar(50),
codigoPostal varchar(5),
escolaridad varchar(80),
especialidad varchar(100),
email varchar(100) NOT NULL,
pass varchar(20) NOT NULL,
tipo varchar(10),
estatus char,
idDepartamento int,
idPuesto int,
idCiudad int,
idSucursal int,
idTurno int,
)
select * from Empleados

create table empleadoss
(
idEmpleado int primary key NOT NULL,
nombre varchar(30) NOT NULL,
apellidoPaterno varchar(30) NOT NULL,
apellidoMaterno varchar(30) NOT NULL,
sexo char NOT NULL,
fechaNacimiento date NOT NULL,
curp varchar(20) NOT NULL,
estadoCivil varchar(20) NOT NULL,
fechaContratacion date NOT NULL,
salarioDiario float NOT NULL,
nss varchar(10) NOT NULL,
diasVacaciones int NOT NULL,
diasPermiso int NOT NULL,
direccion varchar(80) NOT NULL,
colonia varchar(50) NOT NULL,
codigoPostal varchar(5) NOT NULL,
escolaridad varchar(80) NOT NULL,
especialidad varchar(100) NOT NULL,
email varchar(100) NOT NULL,
pass varchar(20) NOT NULL,
tipo varchar(10) NOT NULL,
estatus char NOT NULL,
idDepartamento int, 
idPuesto int,
idCiudad int,
idSucursal int,
idTurno int,
)

select * from empleadoss
insert into empleadoss values (1,'Alex','Perez','RIOS','M','15-JUN-1987','ROVI490617HSPDSS05','Casado','5-JUN-1999',2500,'0795759554',5,3,'CENTRO #356','CENTRO','59610','PREPA','PROGRAMACION','alex@gmail.com','Hola123','Empleado','A',NUll,NUll,NUll,NUll,NUll )
insert into empleadoss values (2,'Juan','Carlos','Perez','M','2-JUN-1987','ROVI490617HSPDFF65','Casado','5-JUN-1999',2600,'0795759548',5,3,'VALENCIA #356','CENTRO','59610','PREPA','PROGRAMACION','Jjuan@gmail.com','Hola123','Empleado','A',NUll,NUll,NUll,NUll,NUll )
insert into empleadoss values (3,'Alexis','Gomez','Luis','M','5-JUN-1987','ALEI490617HSPDSS05','Casado','5-JUN-1999',2500,'0795759554',5,3,'VALENCIA#2 #356','CENTRO','59610','PREPA','PROGRAMACION','alexis@gmail.com','Hola123','Empleado','A',NUll,NUll,NUll,NUll,NUll )







Create Table Asistencias(
idAsistencia int primary key NOT NULL,
fecha date NOT NULL,
horaEntrada date NOT NULL,
horaSalida date NOT NULL,
dia varchar(10) NOT NULL,
idEmpleado int NOT NULL,

)

Create Table HistorialPuestos(
idEmpleado int primary key NOT NULL,
idPuesto int NOT NULL,
idDepartamento int NOT NULL,
fechaInicio date NOT NULL,
fechaFin date NOT NULL,

)

Create Table AusenciasJustificadas(
idAudsencia int primary key NOT NULL,
fechaSolicitud date NOT NULL,
fechaInicio date NOT NULL,
fechaFin date NOT NULL,
tipo char NOT NULL,
idEmpleadoSolicita int NOT NULL,
idEmpleadoAutoriza int NOT NULL,
evidencia image NOT NULL,
estatus char NOT NULL,
motivo varchar(100) NOT NULL,

)

Create Table DocumentacionEmpleado(
idDocumento int primary key NOT NULL,
nombreDocumento varchar(80) NOT NULL,
fechaEntrega date NOT NULL,
documento image NOT NULL,
idEmpleado int NOT NULL,

)

Create Table Nominas(
idNomina int primary key NOT NULL,
fechaElaboracion date NOT NULL,
fechaPago date NOT NULL,
subtotal float NOT NULL,
retenciones float NOT NULL,
total float NOT NULL,
diasTrabajados int NOT NULL,
estatus char NOT NULL,
idEmpleado int NOT NULL,
idFormaPago int NOT NULL,
idPeriodo int NOT NULL,

)

Create Table NominasDeducciones(
idNomina int NOT NULL,
idDeduccion int primary key NOT NULL,
importe float NOT NULL,

)

Create Table NominasPercepciones(
idNomina int NOT NULL,
idPercepcion int NOT NULL,
importe float NOT NULL,
Constraint pk_NominasPercepciones PRIMARY KEY (idNomina,idPercepcion),
)


--------------------FK DE RH------------------------------


alter table Ciudades add constraint fk_Ciudades_Estado
foreign key(idEstado) references Estados(idEstado)
go


alter table Empleados add constraint fk_Empleados_Ciudades
foreign key(idCiudad) references Ciudades(idCiudad)
go

alter table Empleados add constraint fk_Empleados_Departamentos
foreign key(idDepartamento) references Departamentos(idDepartamento)
go

alter table Empleados add constraint fk_Empleados_Puestos
foreign key(idPuesto) references Puestos(idPuesto)
go

alter table Empleados add constraint fk_Empleados_Turnos
foreign key(idTurno) references Turnos(idTurno)
go


alter table Asistencias add constraint fk_Asistencias_Empleados
foreign key(idEmpleado) references Empleados(idEmpleado)
go


alter table HistorialPuestos add constraint fk_Historial_Puestos
foreign key(idPuesto) references Puestos(idPuesto)
go


alter table HistorialPuestos add constraint fk_Historial_Empleados
foreign key(idEmpleado) references Empleados(idEmpleado)
go



alter table HistorialPuestos add constraint fk_Historial_Departamentos
foreign key(idDepartamento) references Departamentos(idDepartamento)
go


alter table AusenciasJustificadas add constraint fk_AusenciasJustificadas_Empleados_2
foreign key(idEmpleadoAutoriza) references Empleados(idEmpleado)
go


alter table AusenciasJustificadas add constraint fk_AusenciasJustificadas_Empleados
foreign key(idEmpleadoSolicita) references Empleados(idEmpleado)
go



alter table DocumentacionEmpleado add constraint fk_DocumentacionEmpleado_Empleados
foreign key(idEmpleado) references Empleados(idEmpleado)
go


alter table Nominas add constraint fk_Nominas_FormasPago
foreign key(idFormaPago) references FormasPago(idFormaPago)
go


alter table Nominas add constraint fk_Nominas_Empleados
foreign key(idEmpleado) references Empleados(idEmpleado)
go

alter table Nominas add constraint fk_Nominas_Periodos
foreign key(idPeriodo) references Periodos(idPeriodo)
go


alter table NominasDeducciones add constraint fk_NominasDeducciones_Nominas
foreign key(idNomina) references Nominas(idNomina)
go


alter table NominasDeducciones add constraint fk_NominasDeducciones_Deducciones
foreign key(idDeduccion) references Deducciones(idDeduccion)
go


alter table NominasPercepciones add constraint fk_NominasPercepciones_Nominas
foreign key(idNomina) references Nominas(idNomina)
go


alter table NominasPercepciones add constraint fk_NominasPercepciones_Percepciones
foreign key(idPercepcion) references Percepciones(idPercepcion)
go









----------------COMPRAS---------------------

create table Laboratorios (
	idLaboratorio int identity not null,
	nombre varchar(50) not null,
	origen varchar(30) not null,
	estatus char not null,
	constraint PK_Laboratorios primary key (idLaboratorio)
)

create table Categorias (
	idCategoria int identity not null,
	nombre varchar(30) not null,
	estatus char not null,
	constraint PK_Categorias primary key (idCategoria)
)

create table Empaques (
	idEmpaque int identity not null,
	nombre varchar(80) not null,
	capacidad float not null,
	estatus char not null,
	idUnidad int not null,
	constraint PK_Empaques primary key (idEmpaque)
)

create table UnidadesMedida (
	idUnidad int identity not null,
	nombre varchar(80) not null,
	siglas varchar(20) not null,
	estatus char not null,
	constraint PK_UnidadMedida primary key (idUnidad)
)

create table Ofertas (
	idOferta int identity not null,
	nombre varchar(50) not null,
	descripcion varchar(100) not null,
	porDescuento float not null,
	fechaInicio date not null,
	fechaFin date not null,
	canMinProductos int not null,
	estatus char not null,
	idPresentacion int not null,
	constraint PK_Ofertas primary key (idOferta)
)

create table Productos (
	idProducto int identity not null,
	nombre varchar(50) not null,
	descripcion varchar(100) not null,
	ingredienteActivo varchar(100) not null,
	bandaToxicologica varchar(80) not null,
	aplicacion varchar(200) not null,
	uso varchar(200) not null,
	estatus char not null,
	idLaboratorio int not null,
	idCategoria int not null,
	constraint PK_Productos primary key (idProducto)
)

create table PresentacionesProducto (
	idPresentacion int identity not null,
	precioCompra float not null,
	precioVenta float not null,
	puntoReorden float not null,
	idProducto int not null,
	idEmpaque int not null,
	constraint PK_PresentacionesProducto primary key (idPresentacion)
)

create table ExistenciasSucursal (
	idPresentacion int not null,
	idSucursal int not null,
	cantidad float not null,
	constraint PK_ExistenciasSucursal primary key (idPresentacion, idSucursal)
)

create table Sucursales (
	idSucursal int identity not null,
	nombre varchar(50) not null,
	telefono varchar(15) not null,
	direccion varchar(80) not null,
	colonia varchar(50) not null,
	codigoPostal varchar(5) not null,
	presupuesto float not null,
	estatus char not null,
	idCiudad int not null,
	constraint PK_Sucursales primary key (idSucursal)
)

create table ImagenesProducto (
	idImagen int identity not null,
	nombreImagen varchar(100),
	imagen varbinary not null,
	principal char not null,
	idProducto int not null,
	constraint PK_ImagenesProducto primary key (idImagen)
)

create table ProductosProveedor (
	idProveedor int not null,
	idPresentacion int not null,
	diasRetardo int not null,
	precioEstandar float not null,
	precioUltimaCompra float not null,
	cantMinPedir int not null,
	cantMaxPedir int not null,
	constraint PK_ProductosProveedor primary key (idProveedor, idPresentacion)
)

create table PedidoDetalle (
	idPedidoDetalle int identity not null,
	cantPedida int not null,
	precioCompra float not null,
	subTotal float not null,
	cantRecibida int not null,
	cantRechazada int not null,
	cantAceptada float not null,
	idPedido int not null,
	idPresentacion int not null,
	constraint PK_PedidoDetalle primary key (idPedidoDetalle)
)

create table Pedidos (
	idPedido int identity not null,
	fechaRegistro date not null,
	fechaRecepcion date not null,
	totalPagar float not null,
	cantidadPagada float not null,
	estatus char not null,
	idProveedor int not null,
	idSucursal int not null,
	idEmpleado int not null,
	constraint PK_Pedidos primary key (idPedido)
)

create table ContactosProveedor (
	idContacto int identity not null,
	nombre varchar(80) not null,
	telefono varchar(12) not null,
	email varchar(100) not null,
	idProveedor int not null,
	constraint PK_ContactosProveedor primary key (idContacto)
)

create table Proveedores (
	idProveedor int identity not null,
	nombre varchar(80) not null,
	telefono varchar(12) not null,
	email varchar(100) not null,
	direccion varchar(80) not null,
	colonia varchar(50) not null,
	codigoPostal varchar(5) not null,
	constraint PK_Proveedores primary key (idProveedor)
)

create table CuentasProveedor (
	idCuentaProveedor int identity not null,
	idProveedor int not null,
	noCuenta varchar(10) not null,
	banco varchar(30) not null,
	referenciaBancaria varchar(20) not null,
	constraint PK_CuentasProveedor primary key (idCuentaProveedor)
)

create table Pagos (
	idPago int not null,
	fecha date not null,
	importe float not null,
	idPedido int not null,
	idFormaPago int not null,
	constraint PK_Pagos primary key (idPago)
)


-----------------------------------------------------------
-----------------------Claves Foraneas---------------------
-----------------------------------------------------------

alter table Empaques add constraint FK_Empaques_UnidadMedida
foreign key(idUnidad) references UnidadesMedida(idUnidad)
go 

alter table Ofertas add constraint FK_Ofertas_PresentacionesProducto
foreign key(idPresentacion) references PresentacionesProducto(idPresentacion)
go 

alter table Productos add constraint FK_Productos_Laboratorios
foreign key(idLaboratorio) references Laboratorios(idLaboratorio)
go 

alter table Productos add constraint FK_Productos_Categorias
foreign key(idCategoria) references Categorias(idCategoria)
go 

alter table PresentacionesProducto add constraint FK_PresentacionesProducto_Productos
foreign key(idProducto) references Productos(idProducto)
go 

alter table PresentacionesProducto add constraint FK_PresentacionesProducto_Empaques
foreign key(idEmpaque) references Empaques(idEmpaque)
go 

alter table ExistenciasSucursal add constraint FK_ExistenciasSucursal_Sucursales
foreign key(idSucursal) references Sucursales(idSucursal)
go 

alter table ExistenciasSucursal add constraint FK_ExistenciasSucursal_PresentacionesProducto
foreign key(idPresentacion) references PresentacionesProducto(idPresentacion)
go 

alter table Sucursales add constraint FK_Sucursales_Ciudades
foreign key(idCiudad) references Ciudades(idCiudad)
go 

alter table ImagenesProducto add constraint FK_ImagenesProducto_Productos
foreign key(idProducto) references Productos(idProducto)
go 

alter table ProductosProveedor add constraint FK_ProductosProveedor_Proveedores
foreign key(idProveedor) references Proveedores(idProveedor)
go 

alter table ProductosProveedor add constraint FK_ProductosProveedor_PresentacionesProducto
foreign key(idPresentacion) references PresentacionesProducto(idPresentacion)
go 

alter table PedidoDetalle add constraint FK_PedidosDetalle_Pedidos
foreign key(idPedido) references Pedidos(idPedido)
go 

alter table PedidoDetalle add constraint FK_PedidosDetalle_PresentacionesProducto
foreign key(idPresentacion) references PresentacionesProducto(idPresentacion)
go 

alter table Pedidos add constraint FK_Pedidos_Proveedores
foreign key(idProveedor) references Proveedores(idProveedor)
go 

alter table Pedidos add constraint FK_Pedidos_Sucursales
foreign key(idSucursal) references Sucursales(idSucursal)
go 

alter table Pedidos add constraint FK_Pedidos_Empleados
foreign key(idEmpleado) references Empleados(idEmpleado)
go 

alter table ContactosProveedor add constraint FK_ContactosProveedor_Proveedores
foreign key(idProveedor) references Proveedores(idProveedor)
go 

alter table Proveedores add constraint FK_Proveedores_Ciudades
foreign key(idCiudad) references Ciudades(idCiudad)
go 

alter table CuentasProveedor add constraint FK_CuentasProveedor_Proveedores
foreign key(idProveedor) references Proveedores(idProveedor)
go 

alter table Pagos add constraint FK_Pagos_Pedidos
foreign key(idPedido) references Pedidos(idPedido)
go 

alter table Pagos add constraint FK_Pagos_FormasPago
foreign key(idFormaPago) references FormasPago(idFormaPago)
go 