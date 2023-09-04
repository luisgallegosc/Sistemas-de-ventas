CREATE PROCEDURE uspObtenerIdComprobanteVentaCompraPorID
    @idcomprobante INT,
    @idcomprobante_output INT OUTPUT,
    @tipocomprobante_output VARCHAR(20) OUTPUT
AS
BEGIN
    DECLARE @coderror INT;
    DECLARE @mensaje VARCHAR(20);

    IF EXISTS (SELECT * FROM TComprobante WHERE idcomprobante = @idcomprobante)
    BEGIN
        IF EXISTS (SELECT * FROM TComprobante WHERE idcomprobante = @idcomprobante AND idproveedor IS NULL)
        BEGIN
            SET @coderror = 0;
            SET @mensaje = 'Venta';
        END
        ELSE IF EXISTS (SELECT * FROM TComprobante WHERE idcomprobante = @idcomprobante AND idcliente IS NULL)
        BEGIN
            SET @coderror = 0;
            SET @mensaje = 'Compra';
        END
    END
    ELSE
    BEGIN
        SET @coderror = 1;
        SET @mensaje = 'No existe';
    END;

    SET @idcomprobante_output = @idcomprobante;
    SET @tipocomprobante_output = @mensaje;
END;


CREATE PROCEDURE uspCalcularVentasPorDia
    @FechaVenta DATE
AS
BEGIN
    SELECT SUM(monto) AS TotalVentas
    FROM TComprobante
    WHERE fechaemision >= @FechaVenta AND fechaemision < DATEADD(DAY, 1, @FechaVenta);
END;
