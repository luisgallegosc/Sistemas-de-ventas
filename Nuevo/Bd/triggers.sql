use BDVenta

-- Triggers

create trigger trdInsertarEmpleado on TEmpleado
after insert
as
begin
	-- Declarar datos
	declare @idempleado varchar(6),
			@dni varchar(8),
			@email varchar(50);
	-- Recuperar datos
	select @idempleado = idempleado,
		   @dni = dni,
		   @email = email
	from inserted;
	-- Crear contraseña
	declare @contrasena varchar(32) = convert(varchar(32), hashbytes('MD5', @dni), 2);
	insert into TUsuario(usuario, contrasena, estado, idempleado)
	values (@email, @contrasena, 1, @idempleado);
end;


CREATE TRIGGER trg_ActualizarStock
ON TDetalleComprobante
AFTER INSERT
AS
BEGIN
    DECLARE @TipoProceso VARCHAR(10);

    -- Obtener el tipo de proceso de la inserción actual
    SELECT @TipoProceso = c.tipoproceso
    FROM TComprobante c
    INNER JOIN inserted i ON c.idcomprobante = i.idcomprobante;

    IF @TipoProceso = 'venta'
    BEGIN
        -- Actualizar el stock actual en la tabla TProducto (restar cantidad)
        UPDATE TProducto
        SET stockactual = stockactual - i.cantidad
        FROM TProducto p
        INNER JOIN inserted i ON p.idproducto = i.idproducto;
    END
    ELSE IF @TipoProceso = 'compra'
    BEGIN
        -- Actualizar el stock actual en la tabla TProducto (sumar cantidad)
        UPDATE TProducto
        SET stockactual = stockactual + i.cantidad
        FROM TProducto p
        INNER JOIN inserted i ON p.idproducto = i.idproducto;
    END
END;


drop trigger trg_ActualizarStock
