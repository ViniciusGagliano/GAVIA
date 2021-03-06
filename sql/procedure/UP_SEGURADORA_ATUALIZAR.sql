
IF OBJECT_ID('UP_SEGURADORA_ATUALIZAR', 'P') IS NOT NULL
	DROP PROCEDURE UP_SEGURADORA_ATUALIZAR;
GO

CREATE PROCEDURE UP_SEGURADORA_ATUALIZAR (
	@ID INT
	, @NOME VARCHAR(100) = NULL
	, @CNPJ VARCHAR(14) = NULL
	, @ANTECIPACAO BIT = 0
)
AS
SET NOCOUNT ON;

UPDATE	SEGURADORA
SET		NOME = ISNULL(NULLIF(LTRIM(RTRIM(@NOME)), ''), NOME)
		, CNPJ = RIGHT(CONCAT('00000000000000', ISNULL(NULLIF(@CNPJ, ''), CNPJ)), 14)
		, ANTECIPACAO = ISNULL(NULLIF(@ANTECIPACAO, 0), ANTECIPACAO)
WHERE	ID = @ID
;
GO
