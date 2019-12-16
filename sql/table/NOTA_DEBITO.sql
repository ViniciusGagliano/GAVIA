
IF OBJECT_ID('NOTA_DEBITO', 'U') IS NULL
	CREATE TABLE NOTA_DEBITO (
		ID INT IDENTITY(1,1) NOT NULL
		, NOME VARCHAR(20) NOT NULL
		, ATIVO BIT NOT NULL DEFAULT 1
		, DATA_EMISSAO SMALLDATETIME NULL
		, DATA_ENVIO SMALLDATETIME NULL
		, PREVISAO_PAGAMENTO SMALLDATETIME NULL
		, DATA_PAGAMENTO SMALLDATETIME NULL
		, DATA_REPASSE_REMESSA SMALLDATETIME NULL
		, DATA_EMAIL SMALLDATETIME NULL
		, DOLAR_BANCO_CENTRAL MONEY NULL
		, OBSERVACAO VARCHAR(4000) NULL
		, CONSTRAINT PK_NOTA_DEBITO_ID PRIMARY KEY CLUSTERED (ID)
	);
GO
