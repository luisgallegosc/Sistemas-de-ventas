use BDVenta
--==========================================================================
-- Insertar
--==========================================================================
create procedure uspInsertarProveedor
    @idproveedor varchar(6),
    @razonSocial varchar(50),
    @ruc varchar(11),
    @direccion varchar(50),
    @telefono varchar(9),
    @email varchar(50),
    @fechaInscripcion datetime
as
begin
    if exists(select * from TProveedor where idproveedor = @idproveedor)
        begin
            select coderror = 0, mensaje = 'Ya se encuentra el Proveedor'
        end 
    else
        begin
            insert into TProveedor(idproveedor, razonSocial, ruc, direccion, telefono, email, fechaInscripcion, estado)
            values(@idproveedor, @razonSocial, @ruc, @direccion, @telefono, @email, @fechaInscripcion, 1)
            select coderror = 1, mensaje = 'Proveedor registrado'
        end
end

--==========================================================================
-- Actualizar
--==========================================================================
create procedure uspActualizarProveedor
    @idproveedor varchar(6),
    @razonSocial varchar(50),
    @ruc varchar(11),
    @direccion varchar(50),
    @telefono varchar(9),
    @email varchar(50),
    @fechaInscripcion datetime
as
begin
    if exists(select * from TProveedor where idproveedor = @idproveedor)
        begin
            update TProveedor 
            set razonSocial = @razonSocial, 
                ruc = @ruc,
                direccion = @direccion,
                telefono = @telefono,
                email = @email,
                fechaInscripcion = @fechaInscripcion
            where idproveedor = @idproveedor;
            select coderror = 1, mensaje = 'Proveedor actualizado';
        end 
    else
        begin
            select coderror = 0, mensaje = 'No se pudo actualizar'
        end
end

--==========================================================================
-- Generar codigo
--==========================================================================
create procedure uspGenerarCodigoProveedor
as
begin 
    declare @codigo varchar(6),
            @sgt int
            set @sgt = (select substring(max(idproveedor), 4, 3) + 1 from TProveedor)
                if(@sgt is null)
                    set @codigo ='PRO001'
                else
                    set @codigo = 'PRO' + right('000' + cast(@sgt as varchar), 3)
                select @codigo as codigo
end
--==========================================================================
-- Listar
--==========================================================================
create procedure uspListarProveedor
as
begin
    select idproveedor, razonSocial, ruc, direccion, telefono, email, fechaInscripcion from TProveedor 
end

--==========================================================================
-- Buscar en Proveedor
--==========================================================================
create procedure uspBuscarProveedor
    @campo varchar(50),
    @contenido varchar(50)
as
begin
    declare @buscar nvarchar(200);
    set @buscar = 'select idproveedor, razonSocial, ruc, direccion, telefono, email, fechaInscripcion from TProveedor where ' + quotename(@campo) + ' =  @contenido';
    exec sp_executesql @buscar, N'@contenido varchar(50)', @contenido = @contenido;
end

-- Eliminar Proveedor
create procedure uspEliminarProveedor
    @idProveedor varchar(6)
as 
begin
    if exists(select * from TProveedor where idProveedor = @idProveedor)
    begin
        delete from TProveedor where idProveedor = @idProveedor
        select coderror = 1, mensaje = 'Proveedor eliminado'
    end
    else
        select coderror = 0, mensaje = 'Proveedor no eliminado'
end

alter procedure uspBuscarRUCProveedor
@ruc varchar(31)
as
begin 
if exists(select * from TProveedor where ruc = @ruc)
select idproveedor, razonSocial, email, direccion, coderror = 1, mensaje = 'provedor encontrado' from TProveedor where ruc = @ruc
else
select idproveedor = '-', razonSocial = '-', email = '-', direccion = '-', coderror = 1, mensaje = 'Proveedor encontrado' 
end