
IF OBJECT_ID('UP_SEGURADO_BUSCAR', 'P') IS NOT NULL
	DROP PROCEDURE UP_SEGURADO_BUSCAR;
GO

CREATE PROCEDURE UP_SEGURADO_BUSCAR (
	@ID INT = NULL
	, @NOME VARCHAR(100) = NULL
	, @CPF VARCHAR(14) = NULL
	, @BANCO VARCHAR(100) = NULL
	, @AGENCIA VARCHAR(4) = NULL
	, @DIGITO_AGENCIA CHAR = NULL
	, @CONTA VARCHAR(10) = NULL
	, @DIGITO_CONTA CHAR = NULL
	, @BENEFICIARIO VARCHAR(100) = NULL
	, @CPF_BENEFICIARIO VARCHAR(14) = NULL
	, @EMAIL VARCHAR(100) = NULL
	, @CONTA_CADASTRADA BIT = NULL
	, @ATIVO BIT = 1
)
AS
SET NOCOUNT ON;

SELECT	*
INTO	#SEGURADO
FROM	SEGURADO S
WHERE	S.ID = ISNULL(NULLIF(@ID, 0), ID)
		AND S.ATIVO = ISNULL(@ATIVO, S.ATIVO)
		AND S.CONTA_CADASTRADA = ISNULL(@CONTA_CADASTRADA, S.CONTA_CADASTRADA)
		AND S.NOME = ISNULL(NULLIF(@NOME, ''), S.NOME)
		AND S.CPF = ISNULL(NULLIF(@CPF, ''), S.CPF)
		AND S.BANCO = ISNULL(@BANCO, S.BANCO)
		AND S.AGENCIA = ISNULL(@AGENCIA, S.AGENCIA)
		AND S.DIGITO_AGENCIA = ISNULL(@DIGITO_AGENCIA, S.DIGITO_AGENCIA)
		AND S.CONTA = ISNULL(@CONTA, S.CONTA)
		AND S.DIGITO_CONTA = ISNULL(@DIGITO_CONTA, S.DIGITO_CONTA)
		AND S.BENEFICIARIO = ISNULL(@BENEFICIARIO, S.BENEFICIARIO)
		AND S.CPF_BENEFICIARIO = ISNULL(@CPF_BENEFICIARIO, S.CPF_BENEFICIARIO)
		AND S.EMAIL = ISNULL(@EMAIL, S.EMAIL)
;

SELECT	S.ID AS ID
		, S.NOME AS NOME
		, dbo.UF_FORMATAR_CPF_CNPJ(S.CPF) AS CPF
		, ISNULL(S.BANCO, '') AS BANCO
		, ISNULL(S.AGENCIA, '') AS AGENCIA
		, S.DIGITO_AGENCIA AS DIGITO_AGENCIA
		, CONCAT(ISNULL(S.AGENCIA, ''), '-', ISNULL(S.DIGITO_AGENCIA, '')) AS AGENCIA_COMPLETA
		, ISNULL(S.CONTA, '') AS CONTA
		, ISNULL(S.DIGITO_CONTA, '') AS DIGITO_CONTA
		, CONCAT(ISNULL(S.CONTA, ''), '-', ISNULL(S.DIGITO_CONTA, '')) AS CONTA_COMPLETA
		, ISNULL(S.BENEFICIARIO, '') AS BENEFICIARIO
		, ISNULL(S.CPF_BENEFICIARIO, '') AS CPF_BENEFICIARIO
		, ISNULL(S.EMAIL, '') AS EMAIL
		, ISNULL(S.CONTA_CADASTRADA, 0) AS CONTA_CADASTRADA
		, S.ATIVO AS ATIVO
FROM #SEGURADO S
;

DROP TABLE #SEGURADO;
GO
