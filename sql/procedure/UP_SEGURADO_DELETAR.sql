
IF OBJECT_ID('UP_SEGURADO_DELETAR', 'P') IS NOT NULL
	DROP PROCEDURE UP_SEGURADO_DELETAR;
GO

CREATE PROCEDURE UP_SEGURADO_DELETAR (
	@ID INT
)
AS
SET NOCOUNT ON;

UPDATE SEGURADO SET ATIVO = 0 WHERE ID = @ID
;
GO