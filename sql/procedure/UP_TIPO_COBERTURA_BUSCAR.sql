
IF OBJECT_ID('UP_TIPO_COBERTURA_BUSCAR', 'P') IS NOT NULL
	DROP PROCEDURE UP_TIPO_COBERTURA_BUSCAR;
GO

CREATE PROCEDURE UP_TIPO_COBERTURA_BUSCAR (
	@ID INT = NULL
	, @NOME VARCHAR(100) = NULL
	, @GRUPO VARCHAR(100) = NULL
	, @ATIVO BIT = 1
)
AS
SET NOCOUNT ON;

SELECT	TC.ID AS ID
		, TC.NOME AS NOME
		, TC.GRUPO AS GRUPO
		, TC.ATIVO AS ATIVO
FROM	TIPO_COBERTURA TC
WHERE	TC.ID = ISNULL(NULLIF(@ID, 0), TC.ID)
		AND TC.ATIVO = ISNULL(@ATIVO, TC.ATIVO)
		AND TC.NOME = ISNULL(NULLIF(@NOME, ''), TC.NOME)
		AND TC.GRUPO = ISNULL(NULLIF(@GRUPO, ''), TC.GRUPO)
;
GO
