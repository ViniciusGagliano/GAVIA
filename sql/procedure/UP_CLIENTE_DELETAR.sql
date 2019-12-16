
IF OBJECT_ID('fin.UP_CLIENTE_DELETAR', 'P') IS NOT NULL
	DROP PROCEDURE fin.UP_CLIENTE_DELETAR;
GO

CREATE PROCEDURE fin.UP_CLIENTE_DELETAR (
	@ID INT
)
AS
SET NOCOUNT ON;

UPDATE fin.CLIENTE SET ATIVO = 0 WHERE ID = @ID
;
GO
