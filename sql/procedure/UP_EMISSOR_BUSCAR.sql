
IF OBJECT_ID('UP_EMISSOR_BUSCAR', 'P') IS NOT NULL
	DROP PROCEDURE UP_EMISSOR_BUSCAR;
GO

CREATE PROCEDURE UP_EMISSOR_BUSCAR (
	@ID INT = NULL
	, @NOME VARCHAR(50) = NULL
	, @ATIVO BIT = 1
)
AS
SET NOCOUNT ON;

SELECT	E.ID AS ID
		, E.NOME AS NOME
		, E.ATIVO AS ATIVO
FROM	EMISSOR E
WHERE	E.ID = ISNULL(NULLIF(@ID, 0), E.ID)
		AND E.ATIVO = ISNULL(@ATIVO, E.ATIVO)
		AND E.NOME = ISNULL(NULLIF(@NOME, ''), E.NOME)
;
GO