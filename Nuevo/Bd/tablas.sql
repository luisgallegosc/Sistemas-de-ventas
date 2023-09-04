use master
go
if exists (select * from sysdatabases where name = 'BDVenta')
drop database BDVenta
go
create database BDVenta
go
--------------------------------------------------------------------------

use BDVenta
go

drop table TUsuario
drop table TComprobante
drop table TDetalleComprobante
drop table TProducto
drop table TEmpleado
drop table TCliente

create table TEmpleado(
	idempleado varchar(6) primary key,
	nombre varchar(50),
	dni varchar(8),
	email varchar(50),
	direccion varchar(50),
	telefono varchar(9),
	cargo varchar(20) check (cargo in ('vendedor', 'administrador', 'superadministrador')),
	foto image,
	fechanacimiento date
	)

create table TUsuario(
	usuario varchar(50) primary key,
	contrasena varchar(32),
	estado bit,
	idempleado varchar(6),
	foreign key (idempleado) references TEmpleado
	)

create table TCliente(
	idcliente varchar(6) primary key,
	nombre varchar(50),
	tipocliente varchar(20),
	dni varchar(8),
	ruc varchar(31),
	email varchar(50),
	direccion varchar(50),
	foto image,
	fechanacimiento date
	)


create table TComprobante(	
    idcomprobante varchar(6) primary key,
    tipocomprobante varchar(20),
    fechaemision datetime,
    monto decimal(10, 2),
    montoletras varchar(100) null ,
    estado bit,
	tipoproceso varchar(10),
    idempleado varchar(6),
    idcliente varchar(6) null,
	idproveedor varchar(6) null,
	foreign key (idproveedor) references TProveedor,
    foreign key (idempleado) references TEmpleado,
    foreign key (idcliente) references TCliente
)

create table TDetalleComprobante(
    iddetalle int primary key identity(1, 1),
    idcomprobante varchar(6), -- Referencia al comprobante al que pertenece este detalle
    idproducto varchar(6), -- Referencia al producto vendido
    cantidad int,
    preciounitario decimal(10, 2),
    foreign key (idcomprobante) references TComprobante,
    foreign key (idproducto) references TProducto
)


create table TProducto(
	idproducto varchar(6) primary key,
	denominacion varchar(50),
	cantidad int,
	preciounitario decimal(10, 2),
	stockinicial int,
	stockactual int
	)

use BDVenta
go

-- Agregar la tabla de Proveedores
drop table TKardex


create table TKardex(
    idkardex int primary key identity(1, 1),
    idproducto varchar(6), -- Asegúrate de definir la longitud máxima
    fecha datetime,
    tipooperacion varchar(10),
    cantidad int,
    preciounitario decimal(10, 2),
    montototal decimal(10, 2),
    constraint FK_TKardex_TProducto foreign key (idproducto) references TProducto(idproducto) -- Asegúrate de especificar la columna correcta
)


-- Ingresar una entrada en el Kardex utilizando el procedimiento almacenado
EXEC uspRegistrarEntradaKardex @IdProducto = 'ID_DEL_PRODUCTO', @Fecha = GETDATE(), @Cantidad = 10;

-- Ingresar una entrada en el Kardex directamente
INSERT INTO TKardex (idproducto, fecha, tipooperacion, cantidad)
VALUES ('ID_DEL_PRODUCTO', GETDATE(), 'Entrada', 10);

-- Ingresar una salida en el Kardex
INSERT INTO TKardex (idproducto, fecha, tipooperacion, cantidad)
VALUES ('ID_DEL_PRODUCTO', GETDATE(), 'Salida', 5);

-- Seleccionar registros del Kardex para un producto específico
SELECT * FROM TKardex WHERE idproducto = 'ID_DEL_PRODUCTO';


-- Procedimiento para registrar una entrada en el Kardex
CREATE PROCEDURE uspRegistrarEntradaKardex
    @IdProducto VARCHAR(6),
    @Fecha DATETIME,
    @Cantidad INT
AS
BEGIN
    DECLARE @SaldoAnterior INT;
    SELECT @SaldoAnterior = ISNULL(MAX(saldoActual), 0)
    FROM TKardex
    WHERE idproducto = @IdProducto;

    INSERT INTO TKardex (idproducto, fecha, tipoOperacion, cantidad, saldoActual)
    VALUES (@IdProducto, @Fecha, 'Entrada', @Cantidad, @SaldoAnterior + @Cantidad);
END;

-- Procedimiento para registrar una salida en el Kardex
CREATE PROCEDURE uspRegistrarSalidaKardex
    @IdProducto VARCHAR(6),
    @Fecha DATETIME,
    @Cantidad INT
AS
BEGIN
    DECLARE @SaldoAnterior INT;
    SELECT @SaldoAnterior = ISNULL(MAX(saldoActual), 0)
    FROM TKardex
    WHERE idproducto = @IdProducto;

    INSERT INTO TKardex (idproducto, fecha, tipoOperacion, cantidad, saldoActual)
    VALUES (@IdProducto, @Fecha, 'Salida', @Cantidad, @SaldoAnterior - @Cantidad);
END;
