
IF OBJECT_ID('UP_CENTRO_CUSTO_CADASTRAR', 'P') IS NOT NULL
	DROP PROCEDURE UP_CENTRO_CUSTO_CADASTRAR;
GO

CREATE PROCEDURE UP_CENTRO_CUSTO_CADASTRAR (
	@NOME VARCHAR(100)
)
AS
SET NOCOUNT ON;

IF ISNULL(@NOME, '') <> ''
	INSERT INTO CENTRO_CUSTO (NOME) SELECT TRIM(@NOME);
GO