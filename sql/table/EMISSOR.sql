
IF OBJECT_ID('EMISSOR', 'U') IS NULL
	CREATE TABLE EMISSOR (
		ID INT IDENTITY(1,1) NOT NULL
		, NOME VARCHAR(50) NOT NULL
		, ATIVO BIT NOT NULL DEFAULT 1
		, CONSTRAINT PK_EMISSOR_ID PRIMARY KEY CLUSTERED (ID)
	);
GO
