
IF OBJECT_ID('imp.UP_IMPORTACAO_CADASTRAR', 'P') IS NOT NULL
	DROP PROCEDURE imp.UP_IMPORTACAO_CADASTRAR;
GO

CREATE PROCEDURE imp.UP_IMPORTACAO_CADASTRAR (
	@SEGURADORA_ID INT
	, @ANTECIPACAO BIT = 0
	, @NOME_ARQUIVO VARCHAR(300)
	, @CAMINHO_ARQUIVO NVARCHAR(MAX) = NULL
)
AS
SET NOCOUNT ON;

IF (ISNULL(@SEGURADORA_ID, 0) <> 0 AND ISNULL(@NOME_ARQUIVO, '') <> '')
BEGIN
	INSERT	INTO imp.IMPORTACAO (SEGURADORA_ID, ANTECIPACAO, NOME_ARQUIVO, CAMINHO_ARQUIVO)
	SELECT	@SEGURADORA_ID, ISNULL(@ANTECIPACAO, 0), @NOME_ARQUIVO, @CAMINHO_ARQUIVO;
END
GO
