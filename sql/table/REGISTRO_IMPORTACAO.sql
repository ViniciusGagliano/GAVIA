
IF OBJECT_ID('REGISTRO', 'U') IS NULL
	CREATE TABLE REGISTRO (
		ID INT IDENTITY(1,1) NOT NULL
		, IMPORTACAO_ID INT NOT NULL
		, ATIVO BIT NOT NULL DEFAULT 1
		, NUMERO_SINISTRO VARCHAR(25) NULL
		, CIA VARCHAR(50) NULL
		, CLIENTE VARCHAR(50) NULL
		, PROCESSO VARCHAR(50) NULL
		, BILHETE VARCHAR(25) NULL
		, VOUCHER VARCHAR(50) NULL
		, DATA_EMISSAO_VOUCHER DATE NULL
		, INICIO_VIGENCIA DATE NULL
		, FIM_VIGENCIA DATE NULL
		, REFERENCIA VARCHAR(20) NULL
		, DATA_ATENDIMENTO DATE NULL
		, DATA_OCORRENCIA DATE NULL
		, NOME_SEGURADO VARCHAR(100) NULL
		, TIPO_DOCUMENTO VARCHAR(20) NULL
		, DOCUMENTO VARCHAR(14) NULL
		, NOME_PRODUTO VARCHAR(20) NULL
		, CODIGO_PRODUTO VARCHAR(5) NULL
		, COBERTURA_RECLAMADA VARCHAR(200) NULL
		, CODIGO_COBERTURA VARCHAR(10) NULL
		, CAUSA VARCHAR(500) NULL
		, CODIGO_CAUSA VARCHAR(10) NULL
		, DESCRI�AO_EVENTO VARCHAR(500) NULL
		, TIPO_PEDIDO VARCHAR(20) NULL
		, CAPITAL_SEGURADO MONEY NULL
		, VALOR_MOEDA_ORIGINAL MONEY NULL
		, TIPO_MOEDA VARCHAR(3) NULL
		, VALOR_FATURA_US MONEY NULL
		, DESCONTO_US MONEY NULL
		, TAXAS_DESCONTO MONEY NULL
		, VALOR_FINAL_US MONEY NULL
		, FEE MONEY NULL
		, TIPO_MOEDA_FEE VARCHAR(3) NULL
		, FEE_BANCARIO_RS MONEY NULL
		, FEE_BANCARIO_REEMBOLSO_RS MONEY NULL
		, VALOR_ND_US MONEY NULL
		, VALOR_ND_RS MONEY NULL
		, TAXA_CAMBIO FLOAT NULL
		, NUMERO_ND VARCHAR(25) NULL
		, DATA_EMISSAO_ND DATE NULL
		, DATA_PAGAMENTO_SINISTRO DATE NULL
		, STATUS_PGTO VARCHAR(10) NULL
		, PRAZO_PAGAMENTO DATE NULL
		, NOME_BANCO VARCHAR(100) NULL
		, TIPO_CONTA VARCHAR(20) NULL
		, NUMERO_AGENCIA VARCHAR(4) NULL
		, DIGITO_AGENCIA VARCHAR(1) NULL
		, NUMERO_CONTA VARCHAR(10) NULL
		, DIGITO_CONTA VARCHAR(1) NULL
		, NOME_BENEFICIARIO VARCHAR(100) NULL
		, DOCUMENTO_BENEFICIARIO VARCHAR(14) NULL
		, EMAIL_CONTATO VARCHAR(100) NULL
		, PRATICANDO_ESPORTE VARCHAR(5) NULL
		, DATA_ENVIO DATE NULL
		, CONSTRAINT PK_REGISTRO_ID PRIMARY KEY CLUSTERED (ID)
	);
GO