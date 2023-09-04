use BDVenta

-- Consultas
select * from TEmpleado
select * from TUsuario
select * from TProveedor
--==========================================================================
-- Agregar superadministrado
--==========================================================================
insert into TEmpleado(idempleado, nombre, dni, email, direccion, telefono, cargo, fechanacimiento)
	values('EMP001', 'Luis', '74927129', 'jefe@gmail.com', 'cusco', '987987987', 'superadministrador', '06-26-2003')

-- Supongamos que tienes un ID de empleado y un ID de usuario
DECLARE @idEmpleadoAdmin varchar(6) = 'EMP005';
DECLARE @idEmpleadoSuperAdmin varchar(6) = 'EMP001';

-- Obtén la imagen del empleado administrador
DECLARE @imagen varbinary(max);
SELECT @imagen = foto FROM TEmpleado WHERE idempleado = @idEmpleadoAdmin;

-- Actualiza la imagen del empleado superadministrador
UPDATE TEmpleado SET foto = @imagen WHERE idempleado = @idEmpleadoSuperAdmin;


select *from TComprobante
select *from TDetalleComprobante
select *from TProducto

CREATE TABLE TKardex (
    idkardex INT PRIMARY KEY,
    idproducto VARCHAR(6) REFERENCES TProducto (idproducto),
    fecha DATETIME,
    tipo VARCHAR(10),
    cantidad INT,
    precio DECIMAL(10, 2),
    saldo DECIMAL(10, 2)
);

INSERT INTO TKardex (idproducto, fecha, tipo, cantidad, precio, saldo)
VALUES ('ID_DEL_PRODUCTO', GETDATE(), 'Entrada', 10, 10.99, 100.00);

SELECT * FROM TKardex