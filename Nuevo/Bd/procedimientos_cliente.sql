-- Procedimientos clientes
use BDVenta
--==========================================================================
-- Insertar
--==========================================================================
create procedure uspInsertarCliente
	@idcliente varchar(6),
	@nombre varchar(50),
	@tipocliente varchar(20),
	@dni varchar(8),
	@ruc varchar(31),
	@email varchar(50),
	@direccion varchar(50),
	@foto image,
	@fechanacimiento date
as
begin
	if exists(select * from TCliente where  idcliente = @idcliente)
		begin
			select coderror = 0, mensaje = 'Ya se encuentra el Cliente'
		end 
	else
		begin
			insert into TCliente(idcliente, nombre, tipocliente, dni, ruc, email, direccion, foto, fechanacimiento)
			values(@idcliente, @nombre, @tipocliente, @dni, @ruc, @email, @direccion, @foto, @fechanacimiento)
			select coderror = 1, mensaje = 'Cliente registrado'
		end
end
--==========================================================================
-- Actualizar
--==========================================================================
create procedure uspActualizarCliente
	@idcliente varchar(6),
	@nombre varchar(50),
	@tipocliente varchar(20),
	@dni varchar(8),
	@ruc varchar(31),
	@email varchar(50),
	@direccion varchar(50),
	@foto image,
	@fechanacimiento date
as
begin
	if exists(select * from TCliente where  idcliente = @idcliente)
		begin
			update TCliente 
			set nombre = @nombre, 
				tipocliente = @tipocliente,
				dni = @dni,
				ruc = @ruc,
				email = @email,
				direccion = @direccion,
				foto = @foto,
				fechanacimiento = @fechanacimiento
			where idcliente = @idcliente;
			select coderror = 1, mensaje = 'Cliente actualizado';
		end 
	else
		begin
			select coderror = 0, mensaje = 'No se pudo actualizar'
		end
end
--==========================================================================
-- Generar codigo
--==========================================================================
create procedure uspGenerarCodigoCliente
as
begin 
	declare @codigo varchar(6),
			@sgt int
			set @sgt = (select substring(max(idcliente), 4, 3) + 1 from TCliente)
				if(@sgt is null)
					set @codigo ='CLI001'
				else
					set @codigo = 'CLI' + right('000' + cast(@sgt as varchar), 3)
				select @codigo as codigo
end

-- Listar
create procedure uspListarCliente
as
begin
	select idcliente, nombre, dni, ruc, email, direccion, fechanacimiento  from TCliente 
end
--==========================================================================
-- Buscar en Cliente
--==========================================================================
create procedure uspBuscarCliente
	@campo varchar(50),
	@contenido varchar(50)
as
begin
	declare @buscar nvarchar(200);
	set @buscar = 'select idcliente, nombre, tipocliente, dni, ruc, email, direccion, fechanacimiento from TCliente where ' + quotename(@campo) + ' =  @contenido';
	exec sp_executesql @buscar, N'@contenido varchar(50)', @contenido = @contenido;
end
--==========================================================================
-- Eliminar Cliente
--==========================================================================
create procedure uspEliminarCliente
	@idCliente varchar(6)
as 
begin
	if exists(select * from TCliente where idCliente = @idCliente)
	begin
		delete from TCliente where idCliente = @idCliente
		select coderror = 1, mensaje = 'Cliente eliminado'
	end
	else
		select coderror = 0, mensaje = 'Cliente no eliminado'
end
--==========================================================================
-- Imagen cliente
--==========================================================================

create procedure uspImagenCliente
	@idcliente varchar(6)
as
begin
	if exists(select * from TCliente where idcliente = @idcliente)
	begin
		declare @imagen  varbinary(max)
		set @imagen = (select foto from TCliente where idcliente = @idcliente)
		select imagen = @imagen, coderror = 1, mensaje = 'Imagen recuperada'
	end
	else
		select imagen = null, coderror = 0, mensaje = 'Imagen no recuperada'
end
--==========================================================================
-- Recupera datos segun DNI
--==========================================================================
create procedure uspBuscarDNICliente
	@dni varchar(8)
as
begin	
	if exists(select * from TCliente where dni = @dni)
		select idcliente, nombre, email, direccion, coderror = 1, mensaje = 'Cliente encontrado' from TCliente where dni = @dni
	else
		select idcliente = '-', nombre = '-', email = '-', direccion = '-', coderror = 1, mensaje = 'Cliente encontrado' 
end
--==========================================================================
-- Recuppera datos segund RUC
--==========================================================================
create procedure uspBuscarRUCCliente
@ruc varchar(31)
as
begin 
if exists(select * from TCLiente where ruc = @ruc)
select idcliente, nombre, email, direccion, coderror = 1, mensaje = 'Cliente encontrado' from TCliente where ruc = @ruc
else
select idcliente = '-', nombre = '-', email = '-', direccion = '-', coderror = 1, mensaje = 'Cliente encontrado' 
end

