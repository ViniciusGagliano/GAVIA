
IF OBJECT_ID('UP_CAP_CLIENTE_ATUALIZAR', 'P') IS NOT NULL
	DROP PROCEDURE UP_CAP_CLIENTE_ATUALIZAR;
GO

CREATE PROCEDURE UP_CAP_CLIENTE_ATUALIZAR (
	@ID INT
	, @NOME VARCHAR(100) = NULL
	, @SEGURADORA_ID INT = NULL
)
AS
SET NOCOUNT ON;

UPDATE	CAP_CLIENTE
SET		NOME = ISNULL(NULLIF(@NOME, ''), NOME)
		, SEGURADORA_ID = ISNULL(NULLIF(@SEGURADORA_ID, 0), SEGURADORA_ID)
WHERE	ID = @ID
;
GO
