CREATE PROCEDURE [dbo].[OrdenInsertar]
	@CantidadProducto int,
	@Estado varchar(50)
AS BEGIN
SET NOCOUNT ON

BEGIN TRANSACTION TRANS
	BEGIN TRY

		INSERT INTO dbo.Orden
		(CantidadProducto,
		 Estado
		)
		VALUES
		(
		 @CantidadProducto,
		 @Estado
		)

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
