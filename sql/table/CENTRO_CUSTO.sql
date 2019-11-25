
IF OBJECT_ID('CENTRO_CUSTO', 'U') IS NULL
	CREATE TABLE CENTRO_CUSTO (
		ID INT IDENTITY(1,1) NOT NULL
		, NOME VARCHAR(100) NOT NULL
		, ATIVO BIT DEFAULT 1 NOT NULL
		, CONSTRAINT PK_CENTRO_CUSTO_ID PRIMARY KEY CLUSTERED (ID)
	);
GO