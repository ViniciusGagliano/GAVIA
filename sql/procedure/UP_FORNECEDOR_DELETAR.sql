
IF OBJECT_ID('fin.UP_FORNECEDOR_DELETAR', 'P') IS NOT NULL
	DROP PROCEDURE fin.UP_FORNECEDOR_DELETAR;
GO

CREATE PROCEDURE fin.UP_FORNECEDOR_DELETAR (
	@ID INT
)
AS
SET NOCOUNT ON;

UPDATE fin.FORNECEDOR SET ATIVO = 0 WHERE ID = @ID
;
GO
