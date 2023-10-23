CREATE PROCEDURE dbo.MassiveCharge
AS
BEGIN
    -- Crear una tabla temporal que contendrá los Repuestos con sus precios
    CREATE TABLE #TMP_REPUESTO (Nombre VARCHAR(100), Precio DECIMAL(18, 6));

    -- Insertar registros en la tabla temporal
    INSERT INTO #TMP_REPUESTO (Nombre, Precio)
    VALUES
        ('B356963821', 17.61),
        ('B881468337', 40.88),
        -- Agrega los demás registros aquí...

    -- Declarar variables para acumular el valor del mismo Repuesto
    DECLARE @RepuestoNombre VARCHAR(100);
    DECLARE @AcumuladorPrecio DECIMAL(18, 6);

    -- Crear una tabla definitiva de Repuestos si no existe
    IF NOT EXISTS (SELECT 1 FROM sys.objects WHERE name = 'Repuesto' AND type = 'U')
    BEGIN
        CREATE TABLE Repuesto (
            Nombre VARCHAR(100) PRIMARY KEY,
            PrecioTotal DECIMAL(18, 6)
        );
    END;

    -- Cursor para recorrer los registros en la tabla temporal
    DECLARE @Cursor CURSOR;

    -- Variables para almacenar el nombre del Repuesto y su precio
    DECLARE @NombreRepuesto VARCHAR(100);
    DECLARE @PrecioRepuesto DECIMAL(18, 6);

    -- Inicializar el cursor
    SET @Cursor = CURSOR FOR
    SELECT Nombre, Precio FROM #TMP_REPUESTO;

    OPEN @Cursor;

    -- Recorrer los registros en la tabla temporal
    FETCH NEXT FROM @Cursor INTO @NombreRepuesto, @PrecioRepuesto;

    WHILE @@FETCH_STATUS = 0
    BEGIN
        -- Comprobar si el precio del Repuesto es menor a $20
        IF @PrecioRepuesto < 20
        BEGIN
            -- Insertar o actualizar el Repuesto en la tabla definitiva
            INSERT INTO Repuesto (Nombre, PrecioTotal)
            VALUES (@NombreRepuesto, @PrecioRepuesto)
            ON DUPLICATE KEY UPDATE PrecioTotal = PrecioTotal + @PrecioRepuesto;
        END
        ELSE
        BEGIN
            -- Si el precio es mayor o igual a $20, reportar en un Query de salida
            PRINT 'Repuesto no insertado: ' + @NombreRepuesto;
        END

        -- Recorrer al siguiente registro
        FETCH NEXT FROM @Cursor INTO @NombreRepuesto, @PrecioRepuesto;
    END

    -- Cerrar y desalojar el cursor
    CLOSE @Cursor;
    DEALLOCATE @Cursor;

    -- Eliminar la tabla temporal
    DROP TABLE #TMP_REPUESTO;
END
