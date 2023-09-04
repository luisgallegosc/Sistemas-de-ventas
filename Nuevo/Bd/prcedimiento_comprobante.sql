
use BDVenta

--==========================================================================
--==========================================================================
-- Generar codigo

create procedure uspGenerarCodigoComprobante
as
begin 
	declare @codigo varchar(6),
			@sgt int
			set @sgt = (select substring(max(idcomprobante), 4, 3) + 1 from TComprobante)
				if(@sgt is null)
					set @codigo ='COM001'
				else
					set @codigo = 'COM' + right('000' + cast(@sgt as varchar), 3)
				select @codigo as codigo
end



create PROCEDURE uspInsertarComprobante
(
    @tipocomprobante varchar(20),
    @nrocomprobante varchar(12),
    @fechaemision datetime,
    @monto decimal(10, 2),
    @montoletras varchar(100),
    @estado bit,
    @idempleado varchar(6),
    @idcliente varchar(6),
    @idproducto int, -- Agrega esta declaración
    @cantidad int, -- Agrega esta declaración
    @preciounitario decimal(10, 2) -- Agrega esta declaración
)
AS
BEGIN
    DECLARE @idcomprobante int

    -- Insertar en la tabla TComprobante
    INSERT INTO TComprobante (tipocomprobante, nrocomprobante, fechaemision, monto, montoletras, estado, idempleado, idcliente)
    VALUES (@tipocomprobante, @nrocomprobante, @fechaemision, @monto, @montoletras, @estado, @idempleado, @idcliente)

    -- Obtener el ID del último comprobante insertado
    SET @idcomprobante = SCOPE_IDENTITY()

    -- Insertar los detalles del comprobante en la tabla TDetalleComprobante
    INSERT INTO TDetalleComprobante (idcomprobante, idproducto, cantidad, preciounitario)
    VALUES (@idcomprobante, @idproducto, @cantidad, @preciounitario)
END


create procedure uspGenerarNumeroComprobante
as
begin 
	declare @numero varchar(6),
			@sgt int
			set @sgt = (select substring(max(nrocomprobante), 6, 7) + 2 from TComprobante)
				if(@sgt is null)
					set @numero ='001-2023001'
				else
					set @numero = '001-2023' + right('10000' + cast(@sgt as varchar), 7)
				select @numero as numero
end


create procedure uspGenerarNumeroComprobante
as
begin 
	declare @numero varchar(6),
			@sgt int
			set @sgt = (select substring(max(nrocomprobante), 5, 6) + 1 from TComprobante)
				if(@sgt is null)
					set @numero ='001-2023001'
				else
					set @numero = '001-2023' + right('10000' + cast(@sgt as varchar), 6)
				select @numero as codigo
end


