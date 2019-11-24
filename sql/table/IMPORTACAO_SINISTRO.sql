
IF OBJECT_ID('IMPORTACAO_SINISTRO', 'U') IS NULL
	CREATE TABLE IMPORTACAO_SINISTRO (
		ID INT IDENTITY(1,1) NOT NULL
		, SEGURADORA_ID INT NOT NULL
		, ANTECIPACAO BIT DEFAULT 0 NOT NULL
		, NOME_ARQUIVO VARCHAR(300) NULL
		, CAMINHO_ARQUIVO NVARCHAR(MAX) NULL
		, ATIVO BIT DEFAULT 1 NOT NULL
		, CONSTRAINT PK_IMPORTACAO_SINISTRO_ID PRIMARY KEY CLUSTERED (ID)
		, CONSTRAINT FK_IMPORTACAO_SINISTRO_SEGURADORA_ID FOREIGN KEY (SEGURADORA_ID) REFERENCES SEGURADORA (ID)
	);
GO
