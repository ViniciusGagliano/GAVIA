
IF OBJECT_ID('UP_TIPO_MOEDA_ATUALIZAR', 'P') IS NOT NULL
	DROP PROCEDURE UP_TIPO_MOEDA_ATUALIZAR;
GO

CREATE PROCEDURE UP_TIPO_MOEDA_ATUALIZAR (
	@ID INT = NULL
	, @NOME VARCHAR(100) = NULL
	, @ABREVIACAO VARCHAR(5) = NULL
)
AS
SET NOCOUNT ON;

UPDATE	TIPO_MOEDA
SET		NOME = ISNULL(NULLIF(@NOME, ''), NOME)
		, NOME_ABREVIADO = ISNULL(NULLIF(@ABREVIACAO, ''), NOME_ABREVIADO)
WHERE	ID = @ID
;
GO
