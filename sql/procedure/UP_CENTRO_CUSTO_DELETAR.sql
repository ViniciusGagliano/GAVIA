
IF OBJECT_ID('UP_CENTRO_CUSTO_DELETAR', 'P') IS NOT NULL
	DROP PROCEDURE UP_CENTRO_CUSTO_DELETAR;
GO

CREATE PROCEDURE UP_CENTRO_CUSTO_DELETAR (
	@ID INT
)
AS
SET NOCOUNT ON;

UPDATE	CENTRO_CUSTO SET ATIVO = 0 WHERE ID = @ID
;
GO
