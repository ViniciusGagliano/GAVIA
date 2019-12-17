
IF OBJECT_ID('fin.UP_CLIENTE_CADASTRAR', 'P') IS NOT NULL
	DROP PROCEDURE fin.UP_CLIENTE_CADASTRAR;
GO

CREATE PROCEDURE fin.UP_CLIENTE_CADASTRAR (
	@NOME VARCHAR(100)
	, @NUM_DOCUMENTO VARCHAR(14) = NULL
	, @SEGURADORA_ID INT
)
AS
SET NOCOUNT ON;

IF ISNULL(@NOME, '') <> ''
	INSERT INTO fin.CLIENTE (NOME, NUM_DOCUMENTO, SEGURADORA_ID) SELECT LTRIM(RTRIM(@NOME)), @NUM_DOCUMENTO, @SEGURADORA_ID;
GO