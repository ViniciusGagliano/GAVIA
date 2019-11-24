
IF OBJECT_ID('UP_IMPORTACAO_SINISTRO_DELETAR', 'P') IS NOT NULL
	DROP PROCEDURE UP_IMPORTACAO_SINISTRO_DELETAR;
GO

CREATE PROCEDURE UP_IMPORTACAO_SINISTRO_DELETAR (
	@ID INT
)
AS
SET NOCOUNT ON;

UPDATE IMPORTACAO_SINISTRO SET ATIVO = 0 WHERE ID = @ID;
GO