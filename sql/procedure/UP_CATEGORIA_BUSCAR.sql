
IF OBJECT_ID('fin.UP_CATEGORIA_BUSCAR', 'P') IS NOT NULL
	DROP PROCEDURE fin.UP_CATEGORIA_BUSCAR;
GO

CREATE PROCEDURE fin.UP_CATEGORIA_BUSCAR (
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
FROM	fin.CATEGORIA C
INNER	JOIN fin.TIPO_LANCAMENTO TL
		ON TL.ID = C.TIPO_LANCAMENTO_ID
		AND TL.ID = ISNULL(@TIPO_LANCAMENTO_ID, TL.ID)
WHERE	C.ID = ISNULL(@ID, C.ID)
		AND C.ATIVO = ISNULL(@ATIVO, C.ATIVO)
		AND C.NOME = ISNULL(@NOME, C.NOME)
;
GO
