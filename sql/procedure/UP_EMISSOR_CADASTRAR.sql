
IF OBJECT_ID('UP_EMISSOR_CADASTRAR', 'P') IS NOT NULL
	DROP PROCEDURE UP_EMISSOR_CADASTRAR;
GO

CREATE PROCEDURE UP_EMISSOR_CADASTRAR (
	@NOME VARCHAR(50)
)
AS
SET NOCOUNT ON;

IF @NOME <> ''
	INSERT	INTO EMISSOR (NOME) VALUES (@NOME);
GO
