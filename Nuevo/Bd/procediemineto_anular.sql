alter PROCEDURE uspAnularComprobante
    @TipoComprobante VARCHAR(20),
    @TipoOperacion VARCHAR(10),
    @NumeroComprobante VARCHAR(12)
AS
BEGIN
    -- Actualizar el estado del comprobante
    UPDATE TComprobante
    SET estado = 1
    WHERE tipocomprobante = @TipoComprobante
    AND nrocomprobante = @NumeroComprobante;

    -- Actualizar el stock según la operación
    IF @TipoOperacion = 'Compra'
    BEGIN
        -- Sumar al stock actual si es una compra
        UPDATE TProducto
        SET stockactual = stockactual + (SELECT SUM(cantidad) FROM TDetalleComprobante WHERE idcomprobante = @NumeroComprobante)
        WHERE idproducto IN (
            SELECT idproducto
            FROM TDetalleComprobante
            WHERE idcomprobante = @NumeroComprobante
        );
    END
    ELSE IF @TipoOperacion = 'Venta'
    BEGIN
        -- Restar del stock actual si es una venta
        UPDATE TProducto
        SET stockactual = stockactual - (SELECT SUM(cantidad) FROM TDetalleComprobante WHERE idcomprobante = @NumeroComprobante)
        WHERE idproducto IN (
            SELECT idproducto
            FROM TDetalleComprobante
            WHERE idcomprobante = @NumeroComprobante
        );
    END;
END;

