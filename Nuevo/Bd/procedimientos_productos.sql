-- procedimientos productos
use BDVenta

create procedure uspInsertarProducto
	@idProducto varchar(6),
	@denominacion varchar(50),
	@cantidad int,
	@preciounitario decimal(10, 2),
	@stockinicial int,
	@stockactual int
as
begin
	if exists(select * from TProducto where  idProducto = @idProducto)
		begin
			select coderror = 0, mensaje = 'Ya se encuentra el Producto'
		end 
	else
		begin
			insert into TProducto(idProducto, denominacion, cantidad, preciounitario, stockinicial, stockactual)
			values(@idProducto, @denominacion, @cantidad, @preciounitario, @stockinicial, @stockactual)
			select coderror = 1, mensaje = 'Producto registrado'
		end
end
--==========================================================================
-- Actualizar
--==========================================================================
create procedure uspActualizarProducto
	@idProducto varchar(6),
	@denominacion varchar(50),
	@cantidad int,
	@preciounitario decimal(10, 2),
	@stockinicial int,
	@stockactual int
as
begin
	if exists(select * from TProducto where  idProducto = @idProducto)
		begin
			update TProducto 
			set denominacion = @denominacion,
				cantidad = @cantidad,
				preciounitario = @preciounitario,
				stockinicial = @stockinicial,
				stockactual = @stockactual
			where idProducto = @idProducto;
			select coderror = 1, mensaje = 'Producto actualizado';
		end 
	else
		begin
			select coderror = 0, mensaje = 'No se pudo actualizar'
		end
end
--==========================================================================
-- Generar codigo
--==========================================================================
create procedure uspGenerarCodigoProducto
as
begin 
	declare @codigo varchar(6),
			@sgt int
			set @sgt = (select substring(max(idProducto), 4, 3) + 1 from TProducto)
				if(@sgt is null)
					set @codigo ='PRO001'
				else
					set @codigo = 'PRO' + right('000' + cast(@sgt as varchar), 3)
				select @codigo as codigo
end
--==========================================================================
-- Listar
--==========================================================================
create procedure uspListarProducto
as
begin
	select idProducto, denominacion, cantidad, preciounitario, stockinicial, stockactual  from TProducto 
end
--==========================================================================
-- Buscar en Producto
--==========================================================================
create procedure uspBuscarProducto
	@campo varchar(50),
	@contenido varchar(50)
as
begin
	declare @buscar nvarchar(200);
	set @buscar = 'select idProducto, denominacion, cantidad, preciounitario, stockinicial, stockactual from TProducto where ' + quotename(@campo) + ' =  @contenido';
	exec sp_executesql @buscar, N'@contenido varchar(50)', @contenido = @contenido;
end
--==========================================================================
-- Eliminar Producto
--==========================================================================
create procedure uspEliminarProducto
	@idProducto varchar(6)
as 
begin
	if exists(select * from TProducto where idProducto = @idProducto)
	begin
		delete from TProducto where idProducto = @idProducto
		select coderror = 1, mensaje = 'Producto eliminado'
	end
	else
		select coderror = 0, mensaje = 'Producto no eliminado'
end



