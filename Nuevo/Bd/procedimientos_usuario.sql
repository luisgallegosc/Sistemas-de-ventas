-- Procedimientos de usuario
use BDVenta
--==========================================================================
-- Inicio de usuario
--==========================================================================
create procedure uspEsUsuario
	@usuario varchar(50),
	@contrasena varchar(32)
as
begin
	if exists(select * from TUsuario where usuario = @usuario and contrasena = @contrasena)
	begin
		select TEmpleado.idempleado, nombre, cargo, coderror = 1, mensaje = 'Si existe' from TUsuario inner join TEmpleado on TUsuario.idempleado = TEmpleado.idempleado 
																							and TUsuario.usuario = @usuario
																							and TUsuario.contrasena = @contrasena
																							and TUsuario.estado = 1
	end
	else
	begin
		select idempleado = 'No', nombre = 'No', cargo = 'No', coderror = 0, mensaje = 'No existe'
	end
end
--==========================================================================
-- Eliminar usuario
--==========================================================================
create procedure uspEliminarUsuario
		@usuario varchar(50)
as
begin
	if exists(select * from TUsuario where usuario = @usuario)
	begin
		delete from TUsuario where usuario = @usuario
		select coderror = 1, mensaje = 'Usuario eliminado'
	end
	else
		select coderror = 0, mensaje = 'Usuario no eliminado'
end
--==========================================================================
-- Actualizar contraseña
--==========================================================================
create procedure uspActualizarContrasenaUsuario
	@usuario varchar(50),
	@contrasena varchar(32)
as
begin
	if exists(select * from TUsuario where usuario = @usuario)
	begin
		update TUsuario
		set contrasena = @contrasena
		where usuario = @usuario
		select coderror = 1, mensaje = 'Usuario actualizado'
	end
	else
		select coderror = 0, mensaje = 'Usuario no actualizado'
end
--==========================================================================
-- Cambiar estado de usuario
--==========================================================================
create procedure uspCambiarEstadoUsuario
	@usuario varchar(50)
as
begin
	if exists(select * from TUsuario where usuario = @usuario)
	begin
		declare @estadoactual bit
		set @estadoactual = (select estado FROM TUsuario WHERE usuario = @usuario)
		update TUsuario
		set estado = case @estadoactual when 0 then 1
										when 1 then 0
						end
		where usuario = @usuario
		select coderror = 1, mensaje = 'Usuario actualizado'
	end
	else
		select coderror = 0, mensaje = 'Usuario no actualizado'
end

-- Listar usuario
create procedure uspListarUsuario
as
begin 
	select * from TUsuario
end
--==========================================================================
-- IdEmpleado con usuario
--==========================================================================
create procedure uspIdempleadoUsuario
	@usuario varchar(50)
as
begin
	if exists(select * from TUsuario where usuario = @usuario)
	begin
		select TEmpleado.idempleado, coderror = 1, mensaje = 'Si existe' from TUsuario inner join TEmpleado on TUsuario.idempleado = TEmpleado.idempleado 
																							and TUsuario.usuario = @usuario
																							and TUsuario.estado = 1
	end
	else
	begin
		select idempleado = 'No', coderror = 0, mensaje = 'No existe'
	end
end
--==========================================================================
-- Nombre con usuario
--==========================================================================
create procedure uspNombreempleadoUsuario
	@usuario varchar(50)
as
begin
	if exists(select * from TUsuario where usuario = @usuario)
	begin
		select nombre, coderror = 1, mensaje = 'Si existe' from TUsuario inner join TEmpleado on TUsuario.idempleado = TEmpleado.idempleado 
																							and TUsuario.usuario = @usuario
																							and TUsuario.estado = 1
	end
	else
	begin
		select nombre = 'No', coderror = 0, mensaje = 'No existe'
	end
end

--==========================================================================
-- obtener foto
--==========================================================================
delete procedure upsObtenerFotoUsuarioPorCorreo
CREATE PROCEDURE uspObtenerFotoUsuarioPorCorreo
    @correo varchar(50),
    @foto image OUTPUT
AS
BEGIN
    SELECT @foto = foto FROM TEmpleado WHERE email = @correo AND foto IS NOT NULL;
END

