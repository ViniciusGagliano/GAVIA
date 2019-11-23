
IF OBJECT_ID('UP_PATROCINIO_DELETAR', 'P') IS NOT NULL
	DROP PROCEDURE UP_PATROCINIO_DELETAR;
GO

CREATE PROCEDURE UP_PATROCINIO_DELETAR (
	@ID INT
)
AS
SET NOCOUNT ON;

IF @ID <> 0
	DELETE FROM PATROCINIO WHERE ID = @ID;
GO
