
IF OBJECT_ID('UP_LANCAMENTO_BUSCAR', 'P') IS NOT NULL
	DROP PROCEDURE UP_LANCAMENTO_BUSCAR;
GO

CREATE PROCEDURE UP_LANCAMENTO_BUSCAR (
	@ID INT = NULL
	, @DESCRICAO VARCHAR(100) = NULL
	, @ATIVO BIT = 1
	, @FORNCEDOR_ID INT = NULL
	, @CATEGORIA_ID INT = NULL
	, @CENTRO_CUSTO_ID INT = NULL
	, @CUSTO_FIXO BIT = NULL
	, @VALOR MONEY = NULL
	, @DATA_LANCAMENTO SMALLDATETIME = NULL
)
AS
SET NOCOUNT ON;

SELECT	L.ID AS ID
		, L.DESCRICAO AS DESCRICAO
		, L.ATIVO AS ATIVO
		, L.FORNCEDOR_ID AS FORNCEDOR_ID
		, L.CATEGORIA_ID AS CATEGORIA_ID
		, L.CENTRO_CUSTO_ID AS CENTRO_CUSTO_ID
		, L.CUSTO_FIXO AS CUSTO_FIXO
		, L.VALOR AS VALOR
		, L.DATA_LANCAMENTO AS DATA_LANCAMENTO
FROM	LANCAMENTO L
WHERE	L.ID = ISNULL(NULLIF(@ID, 0), L.ID)
		AND L.ATIVO = ISNULL(@ATIVO, L.ATIVO)
		AND L.DESCRICAO = ISNULL(NULLIF(@DESCRICAO, ''), L.DESCRICAO)
		AND L.FORNCEDOR_ID = ISNULL(@FORNCEDOR_ID, L.FORNCEDOR_ID)
		AND L.CATEGORIA_ID = ISNULL(@CATEGORIA_ID, L.CATEGORIA_ID)
		AND L.CENTRO_CUSTO_ID = ISNULL(@CENTRO_CUSTO_ID, L.CENTRO_CUSTO_ID)
		AND L.CUSTO_FIXO = ISNULL(@CUSTO_FIXO, L.CUSTO_FIXO)
		AND L.VALOR = ISNULL(@VALOR, L.VALOR)
		AND L.DATA_LANCAMENTO = ISNULL(@DATA_LANCAMENTO, L.DATA_LANCAMENTO)
;
GO
