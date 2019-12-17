
IF OBJECT_ID('fin.UP_FORNECEDOR_BUSCAR', 'P') IS NOT NULL
	DROP PROCEDURE fin.UP_FORNECEDOR_BUSCAR;
GO

CREATE PROCEDURE fin.UP_FORNECEDOR_BUSCAR (
	@ID INT = NULL
	, @NOME VARCHAR(100) = NULL
	, @ATIVO BIT = 1
	, @CNPJ VARCHAR(14) = NULL
)
AS
SET NOCOUNT ON;

SELECT	ID AS ID
		, NOME AS NOME
		, ATIVO AS ATIVO
		, dbo.UF_FORMATAR_CPF_CNPJ(CNPJ) AS CNPJ
FROM	fin.FORNECEDOR
WHERE	ID = ISNULL(@ID, ID)
		AND ATIVO = ISNULL(@ATIVO, ATIVO)
		AND NOME = ISNULL(@NOME, NOME)
		AND CNPJ = ISNULL(@CNPJ, CNPJ)
;
GO
