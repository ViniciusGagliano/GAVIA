
IF OBJECT_ID('SITUACAO_SINISTRO', 'U') IS NULL
	CREATE TABLE SITUACAO_SINISTRO (
		ID INT IDENTITY(1,1) NOT NULL
		, NOME VARCHAR(100) NOT NULL
		, ATIVO BIT NOT NULL DEFAULT 1
		, CONSTRAINT PK_SITUACAO_SINISTRO_ID PRIMARY KEY CLUSTERED (ID)
	);
GO
