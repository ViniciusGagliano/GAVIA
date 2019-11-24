
IF OBJECT_ID('UP_EMISSOR_ATUALIZAR', 'P') IS NOT NULL
	DROP PROCEDURE UP_EMISSOR_ATUALIZAR;
GO

CREATE PROCEDURE UP_EMISSOR_ATUALIZAR (
	@ID INT
	, @NOME VARCHAR(50) = NULL
)
AS
SET NOCOUNT ON;

UPDATE	EMISSOR
SET		NOME = ISNULL(NULLIF(@NOME, ''), NOME)
WHERE	ID = @ID
;
GO