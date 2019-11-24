
IF OBJECT_ID('UP_TIPO_LANCAMENTO_ATUALIZAR', 'P') IS NOT NULL
	DROP PROCEDURE UP_TIPO_LANCAMENTO_ATUALIZAR;
GO

CREATE PROCEDURE UP_TIPO_LANCAMENTO_ATUALIZAR (
	@ID INT
	, @NOME VARCHAR(50) = NULL
	, @MULTIPLICADOR TINYINT = NULL
)
AS
SET NOCOUNT ON;

UPDATE	TIPO_LANCAMENTO
SET		NOME = ISNULL(NULLIF(@NOME, ''), NOME)
		, MULTIPLICADOR = ISNULL(@MULTIPLICADOR, MULTIPLICADOR)
WHERE	ID = @ID
;
GO
