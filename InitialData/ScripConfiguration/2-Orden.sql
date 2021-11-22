DROP TABLE IF EXISTS #OrdenTemp

SELECT
IdOrden, IdProducto, CantidadProducto, Estado INTO #OrdenTemp
FROM(
VALUES
(1,1,1,'PENDIENTE'),
(2,2,2,'LISTA'),
(3,3,3,'ENTREGADA')
)AS TEMP (IdOrden, IdProducto, CantidadProducto, Estado)

-----ACTUALIZAR DATOS TABLA-----
UPDATE O SET
	O.CantidadProducto = TM.CantidadProducto,
	O.Estado = TM.Estado
FROM dbo.Orden O
INNER JOIN #OrdenTemp TM
	ON O.IdOrden = TM.IdOrden

----INSERTAR DATOS TABLA----
SET IDENTITY_INSERT dbo.Orden ON

INSERT INTO dbo.Orden (
	IdOrden,IdProducto,CantidadProducto,Estado)
SELECT
	IdOrden, IdProducto,CantidadProducto,Estado 
FROM #OrdenTemp

EXCEPT
SELECT
IdOrden, IdProducto,CantidadProducto,Estado
FROM dbo.Orden

SET IDENTITY_INSERT dbo.Orden OFF

GO