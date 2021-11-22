CREATE PROCEDURE [dbo].[OrdenActualizar]
	@IdOrden int,
	@CantidadProducto int,
	@Estado varchar(50)
AS BEGIN
SET NOCOUNT ON

BEGIN TRANSACTION TRANS
	BEGIN TRY

		UPDATE dbo.Orden SET
		CantidadProducto=@CantidadProducto,
		Estado=@Estado
		WHERE
			IdOrden=@IdOrden

	COMMIT TRANSACTION TRANS
	SELECT 0 AS CodeError, '' AS MsgError

	END TRY

	BEGIN CATCH

	SELECT
		ERROR_NUMBER() AS CodeError,
		ERROR_MESSAGE() AS MsgError

	ROLLBACK TRANSACTION TRANS

	END CATCH
END
