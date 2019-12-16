
IF OBJECT_ID('fin.UP_CONTA_BANCARIA_ATUALIZAR', 'P') IS NOT NULL
	DROP PROCEDURE fin.UP_CONTA_BANCARIA_ATUALIZAR;
GO

CREATE PROCEDURE fin.UP_CONTA_BANCARIA_ATUALIZAR (
	@ID INT
	, @NOME VARCHAR(100) = NULL
	, @BANCO VARCHAR(100) = NULL
	, @AGENCIA VARCHAR(4) = NULL
	, @DIGITO_AGENCIA CHAR = NULL
	, @CONTA VARCHAR(10) = NULL
	, @DIGITO_CONTA CHAR = NULL
	, @SALDO MONEY = NULL
)
AS
SET NOCOUNT ON;

UPDATE	fin.CONTA_BANCARIA
SET		NOME = ISNULL(NULLIF(@NOME, ''), NOME)
		, BANCO = ISNULL(@BANCO, BANCO)
		, AGENCIA = ISNULL(@AGENCIA, AGENCIA)
		, DIGITO_AGENCIA = ISNULL(@DIGITO_AGENCIA, DIGITO_AGENCIA)
		, CONTA = ISNULL(@CONTA, CONTA)
		, DIGITO_CONTA = ISNULL(@DIGITO_CONTA, DIGITO_CONTA)
		, SALDO = ISNULL(@SALDO, SALDO)
WHERE	ID = @ID
;
GO
