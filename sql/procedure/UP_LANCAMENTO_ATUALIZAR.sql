
IF OBJECT_ID('UP_LANCAMENTO_ATUALIZAR', 'P') IS NOT NULL
	DROP PROCEDURE UP_LANCAMENTO_ATUALIZAR;
GO

CREATE PROCEDURE UP_LANCAMENTO_ATUALIZAR (
	@ID INT
	, @DESCRICAO VARCHAR(100) = NULL
	, @FORNCEDOR_ID INT = NULL
	, @CATEGORIA_ID INT = NULL
	, @CENTRO_CUSTO_ID INT = NULL
	, @CUSTO_FIXO BIT = NULL
	, @VALOR MONEY = NULL
	, @DATA_LANCAMENTO SMALLDATETIME = NULL
)
AS
SET NOCOUNT ON;

UPDATE	LANCAMENTO
SET		DESCRICAO = ISNULL(NULLIF(@DESCRICAO, ''), DESCRICAO)
		, FORNCEDOR_ID = ISNULL(@FORNCEDOR_ID, FORNCEDOR_ID)
		, CATEGORIA_ID = ISNULL(@CATEGORIA_ID, CATEGORIA_ID)
		, CENTRO_CUSTO_ID = ISNULL(@CENTRO_CUSTO_ID, CENTRO_CUSTO_ID)
		, CUSTO_FIXO = ISNULL(@CUSTO_FIXO, CUSTO_FIXO)
		, VALOR = ISNULL(@VALOR, VALOR)
		, DATA_LANCAMENTO = ISNULL(@DATA_LANCAMENTO, DATA_LANCAMENTO)
WHERE	ID = @ID
;
GO
