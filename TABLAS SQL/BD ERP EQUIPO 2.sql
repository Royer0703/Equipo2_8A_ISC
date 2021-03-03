Create database ERP
use ERP

---tabla empleados-- 
create table Empleados(
idEmpleado int primary key not null,
nombre varchar(30) not null,
apellidoPaterno varchar(30) not null,
apellidoMaterno varchar(30) not null,
sexo char not null,
fechaNacimiento varchar(20) not null,
curp varchar(20) not null,
estadoCivil varchar(20) not null,
fechaContratacion date not null,
salarioDiario float not null,
nss varchar(10) not null,
diasVacaciones int not null,
diasPermiso int not null,
direccion varchar(80) not null,
colonia varchar(50) not null,
codigoPostal varchar(5) not null,
escolaridad varchar(80) not null,
especialidad varchar(100) not null,
email varchar(100) not null,
pass varchar(20) not null,
tipo varchar(10) not null,
estatus char not null,
)

--tabla Ciudades--
create table RHCiudades(
idCiudad int primary key not null,
nombre varchar(80) not null,
idEstado int not null,
estatus char not null,
)

---tabla ComprasSucursales--
create table comprasSucursales(
idSucursal int primary key not null,
nombre varchar(50) not null,
telefono varchar(15) not null,
direccion varchar(80) not null,
colonia varchar(50) not null,
codigoPostal varchar(5) not null,
presupuesto float not null,
estatus char not null,
idCiudad int not null,
CONSTRAINT FK_Sucursales_Ciudades FOREIGN KEY (idCiudad)
REFERENCES RHCiudades(idCiudad),
)








-----------------------VENTAS--------------------------------
----SalesVentaDetalle
create table SalesVentaDetalle(
   idVentaDetalle int primary key not null,
   precioVenta float not null,
   cantidad float not null,
   subtotal float not null,
   idVenta int not null
   CONSTRAINT FK_VentaDetalle_Ventas FOREIGN KEY (idVenta) 
   REFERENCES SalesVentas(idVenta)
)

---SalesOfertasAsociacion
create table SalesOfertasAsociacion(
idAsosiacion int not null,
idOferta int not null,
estatus char not null,
CONSTRAINT PK_OfertaAsociacion PRIMARY KEY (idAsosiacion,idOferta),
CONSTRAINT FK_OfertaAsociacion_Asociacion FOREIGN KEY (idAsosiacion) 
REFERENCES SalesAsociaciones(idAsosiacion)
)


---SalesAsociaciones
create table SalesAsociaciones(
idAsosiacion int primary key not null,
nombre varchar(100) not null,
estatus char not null,
)

---SalesMiembros
create table SalesMiembros(
idCliente int not null,
idAsosiacion int not null,
estatus char not null,
fechaIncorporacion date not null,
CONSTRAINT PK_Miembros PRIMARY KEY (idAsosiacion,idCliente),
CONSTRAINT FK_Miembros_Clientes FOREIGN KEY (idCliente)
REFERENCES SalesClientes(idCliente),
CONSTRAINT FK_Miembros_Asociaciones FOREIGN KEY (idAsosiacion)
REFERENCES SalesAsociaciones(idAsosiacion)
)

---SalesCultivos
create table SalesCultivos(
    idCultivo   int primary key not null,
	nombre   varchar(100) not null,
	costoAsesoria float not null,
	estatus  char not null,
)

---SalesClientes
create table SalesClientes(
idCliente int primary key not null,
nombre varchar(100) not null,
razonSocial varchar(100) not null,
limiteCredito float not null,
rfc char(13) not null,
telefono char(12) not null,
email varchar(100) not null,
tipo char not null,
)


---SalesVentas
create table SalesVentas(
idVenta int primary key not null,
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

CONSTRAINT FK_Ventas_Clientes FOREIGN KEY (idCliente)
REFERENCES SalesClientes(idCliente),
CONSTRAINT FK_Ventas_Empleado FOREIGN KEY (idEmpleado)
REFERENCES Empleados(idEmpleado),
CONSTRAINT FK_Ventas_Sucursales FOREIGN KEY (idSucursal)
REFERENCES comprasSucursales(idSucursal),

)



---SalesDireccionesCliente
create table SalesDireccionesCliente(
idDireccion int primary key not null,
calle varchar(100) not null,
numero varchar(15) not null,
colonia varchar(100) not null,
codigoPostal varchar(2) not null,
tipo char not null,
idCliente int not null,
idCiudad int not null,--falta su FK tabla RHCIUDAD
CONSTRAINT FK_Direcciones_Cliente_Clientes FOREIGN KEY (idCliente)
REFERENCES SalesClientes(idCliente),
CONSTRAINT FK_Direcciones_Cliente_Ciudades FOREIGN KEY (idCiudad)
REFERENCES RHCiudades(idCiudad),

)

--SalesParcelas
create table SalesParcelas(
idParcela int primary key not null,
extension float not null,
idCliente int not null,
idCultivo int not null,
idDireccion int not null,

CONSTRAINT FK_Parcelas_Clientes FOREIGN KEY (idCliente)
REFERENCES SalesClientes(idCliente),
CONSTRAINT FK_Parcelas_Cultivos FOREIGN KEY (idCultivo)
REFERENCES SalesCultivos(idCultivo),
CONSTRAINT FK_Direcciones_Cliente FOREIGN KEY (idDireccion)
REFERENCES SalesDireccionesCliente(idDireccion),
)

---SalesTripulacion
create table SalesTripulacion(
idEmpleado int not null,---falta esta es de tabla RH EMPLEADO FK
idEnvio int not null,
rol varchar(50) not null,

CONSTRAINT PK_Tripulacion PRIMARY KEY (idEmpleado,idEnvio,rol),

CONSTRAINT FK_Tripulacion_Envios FOREIGN KEY (idEnvio)
REFERENCES SalesEnvios(idEnvio),
CONSTRAINT FK_Tripulacion_Empleados FOREIGN KEY (idEmpleado)
REFERENCES Empleados(idEmpleado),

)

---SalesCobro
create table SalesCobro(
idCobro int primary key not null,
fecha date not null,
importe float not null,
idVenta int not null,

CONSTRAINT FK_Cobro_Ventas FOREIGN KEY (idVenta)
REFERENCES SalesVentas(idVenta)

)

---SalesDetallesEnvio
create table SalesDetallesEnvio(
idEnvio int not null,
idVenta int not null,
idDireccion int not null,
fechaEntregaPlaneada date not null,
peso float not null,
estatus char not null,
idContacto int not null,

CONSTRAINT PK_Detalles_Envio PRIMARY KEY (idEnvio,idVenta),

CONSTRAINT FK_Detalles_Envio_Envios FOREIGN KEY (idEnvio)
REFERENCES SalesEnvios(idEnvio),--
CONSTRAINT FK_Detalles_Envio_Ventas FOREIGN KEY (idVenta)
REFERENCES SalesVentas(idVenta),
CONSTRAINT FK_Detalles_Envio_Direcciones_Cliente FOREIGN KEY (idDireccion)
REFERENCES SalesDireccionesCliente(idDireccion),
CONSTRAINT FK_Detalles_Envio_ContactosCliente FOREIGN KEY (idContacto)
REFERENCES SalesContactosCliente(idContacto),
)

--SalesUnidadesTransporte
create table SalesUnidadesTransporte(
idUnidadTransporte int primary key not null,
placas varchar(10) not null,
marca varchar(80) not null,
modelo varchar(80) not null,
anio int not null,
capacidad int not null,
tipo varchar(30) not null,
)

--SalesContactosCliente
create table SalesContactosCliente(
idContacto int primary key not null,
nombre varchar(100) not null,
telefono varchar(12) not null,
email varchar(100) not null,
idCliente int not null,
CONSTRAINT FK_ContactosCliente_Clientes FOREIGN KEY (idCliente)
REFERENCES SalesClientes(idCliente),
)


---SalesAsesorias
create table SalesAsesorias(
idAsesoria int primary key not null,
fecha date not null,
comentarios varchar(200) not null,
estatus char not null,
costo float not null,
idParcela int not null,
idEmpleado int not null, 
idUnidadTransporte int not null,

CONSTRAINT FK_Asesorias_clientesCultivos FOREIGN KEY (idParcela)
REFERENCES SalesParcelas(idParcela),
CONSTRAINT FK_Asesorias_UnidadesTransporte FOREIGN KEY (idUnidadTransporte)
REFERENCES SalesUnidadesTransporte(idUnidadTransporte),
CONSTRAINT FK_Asesorias_Empleados FOREIGN KEY (idEmpleado)
REFERENCES Empleados(idEmpleado),
)


---SalesEnvios
create table SalesEnvios(
idEnvio int primary key not null,
fechaInicio date not null,
fechaFin date not null,
idUnidadTransporte int not null,
pesoTotal float not null,
CONSTRAINT FK_EnviosVentas_UnidadesTransporte FOREIGN KEY (idUnidadTransporte)
REFERENCES SalesUnidadesTransporte(idUnidadTransporte),
)


--SalesMantenimiento
create table SalesMantenimiento(
idMantenimiento int primary key not null,
fechaInicio date not null,
fechaFin date not null,
taller varchar(100) not null,
costo float not null,
comentarios varchar(200),
tipo varchar(30) not null,
idUnidadTransporte int not null,

CONSTRAINT FK_Mantenimiento_UnidadesTransporte FOREIGN KEY (idUnidadTransporte)
REFERENCES SalesUnidadesTransporte(idUnidadTransporte),
)