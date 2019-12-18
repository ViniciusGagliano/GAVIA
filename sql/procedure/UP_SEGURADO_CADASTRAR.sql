
IF OBJECT_ID('UP_SEGURADO_CADASTRAR', 'P') IS NOT NULL
	DROP PROCEDURE UP_SEGURADO_CADASTRAR;
GO

CREATE PROCEDURE UP_SEGURADO_CADASTRAR (
	@NOME VARCHAR(100)
	, @CPF VARCHAR(14)
	, @BANCO VARCHAR(100) = NULL
	, @AGENCIA VARCHAR(4) = NULL
	, @DIGITO_AGENCIA CHAR = NULL
	, @CONTA VARCHAR(10) = NULL
	, @DIGITO_CONTA CHAR = NULL
	, @BENEFICIARIO VARCHAR(100) = NULL
	, @CPF_BENEFICIARIO VARCHAR(14) = NULL
	, @EMAIL VARCHAR(100) = NULL
	, @CONTA_CADASTRADA BIT = NULL
)
AS
SET NOCOUNT ON;
DECLARE @VALIDACAO VARCHAR(14);
SELECT	@VALIDACAO = dbo.UF_TAMANHO_CPF_CNPJ(@CPF);

IF (SELECT COUNT(1) FROM SEGURADO WHERE CPF = @VALIDACAO) < 1
BEGIN
	INSERT	INTO SEGURADO (
		NOME, CPF, BANCO, AGENCIA, DIGITO_AGENCIA, CONTA, DIGITO_CONTA
		, BENEFICIARIO, CPF_BENEFICIARIO, EMAIL, CONTA_CADASTRADA
	)
	SELECT	@NOME, dbo.UF_TAMANHO_CPF_CNPJ(@CPF), ISNULL(@BANCO, ''), ISNULL(@AGENCIA, ''), ISNULL(@DIGITO_AGENCIA, ''), ISNULL(@CONTA, ''), ISNULL(@DIGITO_CONTA, '')
			, ISNULL(@BENEFICIARIO, ''), dbo.UF_TAMANHO_CPF_CNPJ(@CPF_BENEFICIARIO), ISNULL(@EMAIL, ''), ISNULL(@CONTA_CADASTRADA, 0)
	;
END
GO
