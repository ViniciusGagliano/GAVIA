
IF OBJECT_ID('fin.UP_TIPO_LANCAMENTO_CADASTRAR', 'P') IS NOT NULL
	DROP PROCEDURE fin.UP_TIPO_LANCAMENTO_CADASTRAR;
GO

CREATE PROCEDURE fin.UP_TIPO_LANCAMENTO_CADASTRAR (
	@NOME VARCHAR(50)
	, @MULTIPLICADOR INT = 1
)
AS
SET NOCOUNT ON;

IF ISNULL(@NOME, '') <> ''
	INSERT INTO fin.TIPO_LANCAMENTO (NOME, MULTIPLICADOR) SELECT LTRIM(RTRIM(@NOME)), ISNULL(@MULTIPLICADOR, 1);
GO
