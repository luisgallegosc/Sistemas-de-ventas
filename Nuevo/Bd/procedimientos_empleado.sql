use BDVenta

-- Procedimientos
--==========================================================================
-- Insertar
--==========================================================================
create procedure uspInsertarEmpleado
	@idempleado varchar(6),
	@nombre varchar(50),
	@dni varchar(8),
	@email varchar(50),
	@direccion varchar(50),
	@telefono varchar(9),
	@cargo varchar(20),
	@foto image,
	@fechanacimiento date
as
begin
	if exists(select * from TEmpleado where  idempleado = @idempleado)
		begin
			select coderror = 0, mensaje = 'Ya se encuentra el empleado'
		end 
	else
		begin
			insert into TEmpleado(idempleado, nombre, dni, email, direccion, telefono, cargo, foto, fechanacimiento)
			values(@idempleado, @nombre, @dni, @email, @direccion, @telefono, @cargo, @foto, @fechanacimiento)
			select coderror = 1, mensaje = 'Empleado registrado'
		end
end
--==========================================================================
-- Actualizar
--==========================================================================
create procedure uspActualizarEmpleado
	@idempleado varchar(6),
	@nombre varchar(50),
	@dni varchar(8),
	@email varchar(50),
	@direccion varchar(50),
	@telefono varchar(9),
	@cargo varchar(20),
	@foto image,
	@fechanacimiento date
as
begin
	if exists(select * from TEmpleado where  idempleado = @idempleado)
		begin
			update TEmpleado 
			set nombre = @nombre,
				email = @email, 
				direccion = @direccion,
				telefono = @telefono,
				cargo = @cargo,
				foto = @foto,
				fechanacimiento = @fechanacimiento
			where idempleado = @idempleado;
			select coderror = 1, mensaje = 'Empleado actualizado';
		end 
	else
		begin
			select coderror = 0, mensaje = 'No se pudo actualizar'
		end
end
--==========================================================================
-- Generar codigo
--==========================================================================
create procedure uspGenerarCodigoEmpleado
as
begin 
	declare @codigo varchar(6),
			@sgt int
			set @sgt = (select substring(max(idempleado), 4, 3) + 1 from TEmpleado)
				if(@sgt is null)
					set @codigo ='EMP001'
				else
					set @codigo = 'EMP' + right('000' + cast(@sgt as varchar), 3)
				select @codigo as codigo
end
--==========================================================================
-- Listar
--==========================================================================
create procedure uspListarEmpleado
as
begin
	select idempleado, nombre, dni, email, direccion, telefono, cargo, fechanacimiento  from TEmpleado where cargo != 'superadministrador'
end
--==========================================================================
-- Buscar en empleado
--==========================================================================
create procedure uspBuscarEmpleado
    @campo varchar(50),
    @contenido varchar(50)
as
begin
    declare @buscar nvarchar(200);
    set @buscar = 'SELECT idempleado, nombre, dni, email, direccion, telefono, cargo, fechanacimiento FROM TEmpleado WHERE ' + @campo + ' = @contenido AND cargo != ''superadministrador''';
    exec sp_executesql @buscar, N'@contenido varchar(50)', @contenido = @contenido;
end


create procedure uspBuscarTabla
	@tabla varchar(50),
    @campo varchar(50),
    @contenido varchar(50)
as
begin
    declare @buscar nvarchar(200);
    set @buscar = 'select * from ' + quotename(@tabla) + ' where ' + quotename(@campo) + ' =  @contenido';
	exec sp_executesql @buscar, N'@contenido varchar(50)', @contenido = @contenido;
end;
--==========================================================================
-- Eliminar empleado
--==========================================================================
create procedure uspEliminarEmpleado
	@idempleado varchar(6)
as 
begin
	if exists(select * from TEmpleado where idempleado = @idempleado)
	begin
		declare @correo varchar(50)
		set @correo = (select email from TEmpleado inner join TUsuario on TEmpleado.idempleado = TUsuario.idempleado and TEmpleado.idempleado = @idempleado)
		delete from TUsuario where usuario = @correo
		delete from TEmpleado where idempleado = @idempleado
		select coderror = 1, mensaje = 'Empleado eliminado'
	end
	else
		select coderror = 0, mensaje = 'Empleado no eliminado'
end
--==========================================================================
-- Imagen
--==========================================================================
create procedure uspImagenEmpleado
	@idempleado varchar(6)
as
begin
	if exists(select * from TEmpleado where idempleado = @idempleado)
	begin
		declare @imagen  varbinary(max)
		set @imagen = (select foto from TEmpleado where idempleado = @idempleado)
		select imagen = @imagen, coderror = 1, mensaje = 'Imagen recuperada'
	end
	else
		select imagen = null, coderror = 0, mensaje = 'Imagen no recuperada'
end

