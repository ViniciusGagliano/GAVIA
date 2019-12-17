
IF OBJECT_ID('fin.UP_CENTRO_CUSTO_BUSCAR', 'P') IS NOT NULL
	DROP PROCEDURE fin.UP_CENTRO_CUSTO_BUSCAR;
GO

CREATE PROCEDURE fin.UP_CENTRO_CUSTO_BUSCAR (
	@ID INT = NULL
	, @NOME VARCHAR(100) = NULL
	, @ATIVO BIT = 1
)
AS
SET NOCOUNT ON;

SELECT	CC.ID AS ID
		, CC.NOME AS NOME
		, CC.ATIVO AS ATIVO
FROM	fin.CENTRO_CUSTO CC
WHERE	CC.ID = ISNULL(@ID, CC.ID)
		AND CC.ATIVO = ISNULL(@ATIVO, CC.ATIVO)
		AND CC.NOME = ISNULL(@NOME, CC.NOME)
;
GO
