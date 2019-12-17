
IF OBJECT_ID('fin.UP_CONTA_BANCARIA_BUSCAR', 'P') IS NOT NULL
	DROP PROCEDURE fin.UP_CONTA_BANCARIA_BUSCAR;
GO

CREATE PROCEDURE fin.UP_CONTA_BANCARIA_BUSCAR (
	@ID INT = NULL
	, @NOME VARCHAR(100) = NULL
	, @ATIVO BIT = 1
	, @BANCO VARCHAR(100) = NULL
	, @AGENCIA VARCHAR(4) = NULL
	, @DIGITO_AGENCIA CHAR = NULL
	, @CONTA VARCHAR(10) = NULL
	, @DIGITO_CONTA CHAR = NULL
	, @SALDO MONEY = NULL
)
AS
SET NOCOUNT ON;

SELECT	C.ID AS ID
		, C.NOME AS NOME
		, C.ATIVO AS ATIVO
		, C.BANCO AS BANCO
		, C.AGENCIA AS AGENCIA
		, C.DIGITO_AGENCIA AS DIGITO_AGENCIA
		, CONCAT(C.AGENCIA, '-', C.DIGITO_AGENCIA) AS AGENCIA_COMPLETA
		, C.CONTA AS CONTA
		, C.DIGITO_CONTA AS DIGITO_CONTA
		, CONCAT(C.CONTA, '-', C.DIGITO_CONTA) AS CONTA_COMPLETA
		, C.SALDO AS SALDO
		, FORMAT(C.SALDO, 'C', 'pt-BR') AS SALDO_FORMATADO
FROM	fin.CONTA_BANCARIA C
WHERE	C.ID = ISNULL(@ID, C.ID)
		AND C.ATIVO = ISNULL(@ATIVO, C.ATIVO)
		AND C.NOME = ISNULL(@NOME, C.NOME)
		AND C.BANCO = ISNULL(@BANCO, C.BANCO)
		AND C.AGENCIA = ISNULL(@AGENCIA, C.AGENCIA)
		AND C.DIGITO_AGENCIA = ISNULL(@DIGITO_AGENCIA, C.DIGITO_AGENCIA)
		AND C.CONTA = ISNULL(@CONTA, C.CONTA)
		AND C.DIGITO_CONTA = ISNULL(@DIGITO_CONTA, C.DIGITO_CONTA)
		AND C.SALDO = ISNULL(@SALDO, SALDO)
;
GO