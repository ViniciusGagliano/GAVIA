
IF OBJECT_ID('UP_IMPORTACAO_SINISTRO_ATUALIZAR', 'P') IS NOT NULL
	DROP PROCEDURE UP_IMPORTACAO_SINISTRO_ATUALIZAR;
GO

CREATE PROCEDURE UP_IMPORTACAO_SINISTRO_ATUALIZAR (
	@ID INT
	, @SEGURADORA_ID INT = NULL
	, @NOME_ARQUIVO VARCHAR(300) = NULL
	, @CAMINHO_ARQUIVO NVARCHAR(MAX) = NULL
)
AS
SET NOCOUNT ON;

UPDATE	IMPORTACAO_SINISTRO
SET		SEGURADORA_ID = ISNULL(NULLIF(@SEGURADORA_ID, 0), SEGURADORA_ID)
		, NOME_ARQUIVO = ISNULL(NULLIF(@NOME_ARQUIVO, ''), NOME_ARQUIVO)
		, CAMINHO_ARQUIVO = ISNULL(NULLIF(@CAMINHO_ARQUIVO, ''), CAMINHO_ARQUIVO)
WHERE	ID = @ID
;
GO