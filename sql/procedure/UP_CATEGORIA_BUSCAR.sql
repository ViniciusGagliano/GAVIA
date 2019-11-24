
IF OBJECT_ID('UP_CATEGORIA_BUSCAR', 'P') IS NOT NULL
	DROP PROCEDURE UP_CATEGORIA_BUSCAR;
GO

CREATE PROCEDURE UP_CATEGORIA_BUSCAR (
	@ID INT = NULL
	, @NOME VARCHAR(100) = NULL
	, @ATIVO BIT = 1
	, @TIPO_LANCAMENTO_ID INT = NULL
)
AS
SET NOCOUNT ON;

SELECT	C.ID AS ID
		, C.NOME AS NOME
		, C.ATIVO AS ATIVO
		, TL.ID AS TIPO_LANCAMENTO_ID
		, TL.NOME AS TIPO_LANCAMENTO_NOME
		, TL.MULTIPLICADOR AS MULTIPLICADOR
FROM	CATEGORIA C
INNER	JOIN TIPO_LANCAMENTO TL
		ON TL.ID = C.TIPO_LANCAMENTO_ID
		AND TL.ID = ISNULL(NULLIF(@TIPO_LANCAMENTO_ID, 0), TL.ID)
WHERE	C.ID = ISNULL(NULLIF(@ID, 0), C.ID)
		AND C.ATIVO = ISNULL(@ATIVO, C.ATIVO)
		AND C.NOME = ISNULL(NULLIF(@NOME, ''), C.NOME)
;
GO
