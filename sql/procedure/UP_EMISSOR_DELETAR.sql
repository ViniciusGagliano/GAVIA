
IF OBJECT_ID('UP_EMISSOR_DELETAR', 'P') IS NOT NULL
	DROP PROCEDURE UP_EMISSOR_DELETAR;
GO

CREATE PROCEDURE UP_EMISSOR_DELETAR (
	@ID INT
)
AS
SET NOCOUNT ON;

UPDATE EMISSOR SET ATIVO = 0 WHERE ID = @ID
;
GO
