
IF OBJECT_ID('fin.UP_LANCAMENTO_DELETAR', 'P') IS NOT NULL
	DROP PROCEDURE fin.UP_LANCAMENTO_DELETAR;
GO

CREATE PROCEDURE fin.UP_LANCAMENTO_DELETAR (
	@ID INT
)
AS
SET NOCOUNT ON;

UPDATE fin.LANCAMENTO SET ATIVO = 0 WHERE ID = @ID
;
GO
