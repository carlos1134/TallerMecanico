CREATE PROCEDURE sp_PromedioMontoPresupuestos
    @Marca VARCHAR(100),
    @Modelo VARCHAR(100)
AS
BEGIN
    SELECT
        AVG(P.Total) AS PromedioMonto
    FROM
        Presupuesto AS P
    INNER JOIN Vehiculo AS V ON P.IdVehiculo = V.Id
    WHERE
        V.Marca = @Marca
        AND V.Modelo = @Modelo
END
