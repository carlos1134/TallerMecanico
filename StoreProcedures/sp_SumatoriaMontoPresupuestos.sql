CREATE PROCEDURE sp_SumatoriaMontoPresupuestos
AS
BEGIN
    SELECT
        SUM(CASE WHEN V.Tipo = 'Auto' THEN P.Total ELSE 0 END) AS SumaAutos,
        SUM(CASE WHEN V.Tipo = 'Moto' THEN P.Total ELSE 0 END) AS SumaMotos
    FROM
        Presupuesto AS P
    INNER JOIN Vehiculo AS V ON P.IdVehiculo = V.Id
END
