CREATE PROCEDURE [dbo].[ProductoObtener]
	@IdProducto int = NULL

AS BEGIN
	SET NOCOUNT ON

	SELECT 
		N.IdProducto,
		N.NombreProducto,
		N.PrecioProducto
		FROM dbo.Producto N
		WHERE
		(@IdProducto IS NULL OR IdProducto = @IdProducto)

END
