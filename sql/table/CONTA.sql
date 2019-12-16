
IF OBJECT_ID('fin.CONTA_BANCARIA', 'U') IS NULL
	CREATE TABLE fin.CONTA_BANCARIA (
		ID INT IDENTITY(1,1) NOT NULL
		, NOME VARCHAR(100) NOT NULL
		, ATIVO BIT NOT NULL DEFAULT 1
		, BANCO VARCHAR(100) NULL
		, AGENCIA VARCHAR(4) NULL
		, DIGITO_AGENCIA CHAR NULL
		, CONTA VARCHAR(10) NULL
		, DIGITO_CONTA CHAR NULL
		, SALDO MONEY NULL
		, CONSTRAINT PK_CONTA_BANCARIA_ID PRIMARY KEY CLUSTERED (ID)
	);
GO
