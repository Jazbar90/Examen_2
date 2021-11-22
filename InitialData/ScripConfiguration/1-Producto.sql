DROP TABLE IF EXISTS #ProductoTemp

SELECT
IdProducto, NombreProducto, PrecioProducto INTO #ProductoTemp
FROM(
VALUES
(1,'',0),
(2,'',0),
(3,'',0)
)AS TEMP (IdProducto, NombreProducto, PrecioProducto)

-----ACTUALIZAR DATOS TABLA-----
UPDATE P SET
	P.NombreProducto = TM.NombreProducto,
	P.PrecioProducto = TM.PrecioProducto
FROM dbo.Producto P
INNER JOIN #ProductoTemp TM
	ON P.IdProducto = TM.IdProducto

----INSERTAR DATOS TABLA----
SET IDENTITY_INSERT dbo.Producto ON

INSERT INTO dbo.Producto (
	IdProducto, NombreProducto, PrecioProducto)
SELECT
	IdProducto, NombreProducto, PrecioProducto 
FROM #ProductoTemp

EXCEPT
SELECT
IdProducto, NombreProducto, PrecioProducto
FROM dbo.Producto

SET IDENTITY_INSERT dbo.Producto OFF

GO