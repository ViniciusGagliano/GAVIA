
IF OBJECT_ID('UP_TIPO_COBERTURA_CADASTRAR', 'P') IS NOT NULL
	DROP PROCEDURE UP_TIPO_COBERTURA_CADASTRAR;
GO

CREATE PROCEDURE UP_TIPO_COBERTURA_CADASTRAR (
	@NOME VARCHAR(100)
	, @GRUPO VARCHAR(100)
)
AS
SET NOCOUNT ON;

INSERT	INTO TIPO_COBERTURA (NOME, GRUPO) 
SELECT	@NOME, @GRUPO
;
GO
