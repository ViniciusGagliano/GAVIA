# Sistema de Gerenciamento de Seguro de Viagem:

DESCRIÇÃO DOS PROCESSOS DA WTA BR
SANCOR – REEMBOLSOS
 - BRUNA: - OPERATIVO
1. Central envia diariamente a relação de reembolsos a pagar SANCOR via e-mail, Bruna importa os mesmos para planilha base, onde constam todas as relações de reembolsos.
  1.1 Importação do Excel para dentro do sistema.
2.	Aguarda o Fernando fazer a programação dos reembolsos a pagar do dia, conforme a disponibilidade de caixa, prazo de pagamento.
a.	Seleciona os reembolsos com os status A pagar/Liberado para pagamento e fazer os pagamentos mudando o status automaticamente para Pago.
3.	Recepciona a planilha dos reembolsos a pagar do dia e os cadastra como Doc/Ted na conta corrente como favorecidos para serem auditados e autorizados pelo Bruno. Essa função será feita com módulo de interface do Bradesco.
a.	Lançamento pelo Bradesco
4.	Após a autorização, ela salva os comprovantes de pagamentos em uma pasta de comprovantes e os remete via e-mail para a central, seguradora e os clientes.
a.	Histórico
5.	Com a relação de reembolsos pagos ela atualiza a base, lançando o dia em que foi efetuado o pagamento. A central de posse dos comprovantes gera e envia as ND (fatura) para as seguradoras. Essas recebem as Notas de Débito e enviam um aviso ao Fernando que no dia x serão pagas tantas Notas de Débito.
a.	Status
6.	Após os pagamentos das faturas (ND), ela emite as Notas Fiscais de serviços contra as seguradoras.
a.	Emite NF

BRUNA – ADMINSTRATIVO
1.	Cadastra todas as contas a pagar, conforme seu vencimento em uma planilha.
a.	CAP
2.	No respectivo dia do vencimento cadastra a despesa no banco ou gera boleto e aguarda autorização do Bruno.
a.	CAP
3.	Salva os comprovantes das despesas pagas e as lança no demonstrativo de pagamentos.
a.	CAP
4.	Envia os comprovantes para a contabilidade.
a.	PDF
5.	Faz a conciliação de todas as contas bancárias do grupo (8) com as despesas e receitas do grupo. 
a.	DRE

FERNANDO – OPERATIVO
1.	Atualiza a base das Notas de Débito com as informações da central, se foi faturada e da seguradora, se foi paga ou quando será paga.
a.	Atualização de status por importação em Excel
2.	Faz a programação dos reembolsos diários de acordo com o prazo de pagamento, nunca superior a 30 dias da data do pagamento ou diariamente conforme o recebido dos relatórios.
a.	Altera os status dos reembolsos para ser realiza os pagamentos
3.	Filtra os casos internacionais para as remessas e os nacionais para pagamento.
a.	
4.	Faz pagamento dos nacionais
a.	
5.	Calcula valores do FEE o que é da central e o que é da WTA
a.	Cálculo automático do FEE por regra
6.	Faz a cotação e contratação do dólar com o MSBANK
a.	
7.	Faz as remessas internacionais para a central, discriminando o que é reembolso internacional, faturas internacionais, FEE internacional.
a.	
8.	Envia carta padrão ao banco da remessa com a respectiva relação dos clientes.
a.	
9.	Envia comprovante da remessa para central
a.	
10.	Faz a conciliação entre as remessas internacionais e o que foi pago pela WTA
a.	
11.	Calcula os valores de bilhetes vendidos para enviar a Bruna gerar a NF
a.	
AUDITORIA
1.	Verificar se a lista de favorecidos cadastrados no banco para DOC E TED são os mesmos que constam na relação de reembolsos do dia, observando o nome, valor, data de pagamento do reembolso e se houve duplicidade de pagamentos.
a.	

BRUNO
1.	Autoriza os pagamentos dos reembolsos
a.	
2.	Autoriza os pagamentos das despesas operacionais
a.	
3.	Gerencia as contas da empresa
---
O sistema GPR tem como escopo automatizar os processos realizados hoje pela equipe Operacional da WTA. O sistema contará com diversas funcionalidades dividas em módulos separadas. O modulo de importação terá uma tela mostrando todas as importações realizadas, distinguindo quais foram os tipos de importações, além de mostrar qual foi o usuário responsável pela importação, a data que foi importada, quantidade de registros. Essas importações serão realizadas importando um arquivo em Excel e selecionando a Seguradora que será vinculada com os reembolsos gerados pelo arquivo. Será possível importar 3 tipos diferentes, o relatório de reembolso que irá gerar o reembolso dentro do sistema, o relatório de nota de débito que irá faturar os reembolsos cadastrados dentro do sistema e o relatório enviado pela seguradora que irá consolidar o fato que foi recebido o valor. Esse módulo que será responsável por criar os reembolsos dentro do sistema, ou seja, uma cópia virtual com todas as informações que foram importadas junto do Excel. Os valores de FEEs serão calculados automaticamente visto que a comissão é fixa.
O segundo modulo disponível será o de acompanhamento e processamento, nele o usuário poderá buscar diversos reembolsos na base a partir dos filtros disponibilizados, estes filtros serão todos presentes nos arquivos em Excel e alguns outros que o sistema terá, por exemplo Status. O sistema terá uma tela para essa busca mostrando todos os filtros e as ações de buscar dentro do sistema ou gerar essa busca em Excel. Para os processamentos que o módulo disponibilizará serão as alterações e inserções em lote de todos os reembolsos buscados, essas ações serão apenas das informações que os usuários poderão alterar, por exemplo, os status que o reembolso se encontra, inserir a data que houve uma alteração, adicionar uma observação. O status informados anterior serão usados para controlar as etapas do reembolso e serão divididos em 3 categorias diferentes, Cliente, Central e Seguradora. Os status cliente levantados no momento são: cancelado, para reembolsos que não devem ser pagos; não pago, para os reembolsos que não foram pagos; autorizado, para os reembolsos que ainda não foram pagos, mas já estão com o pagamento agendado ou já foram autorizados para o pagamento do dia; pago, para os reembolsos que já foram pagos aos clientes. Os status central levantados no momento são: sem comprovante, para os reembolsos que ainda não tiveram seus comprovantes gerados, o reembolso pode estar pago ou não; não faturada, para os reembolsos com os comprovantes gerados e enviados para Central, mas ainda sem nota de débito gerada; faturado, para os reembolsos que já tiveram suas notas de débito geradas. O status seguradora levantados no momento são: não pago, para os reembolsos que ainda não tiveram pagamento pela seguradora; pago, para os reembolsos que já tiveram pagamento pela seguradora. Com esses status o usuário poderá buscar, filtrar e interagir com os reembolsos no momento desejável, assim como segregar as atividades dos funcionários para cada um dos status específico, além de dar flexibilidade para lidar com as diferentes formas de pagamento feito pelas seguradoras.
O 3º é o modulo de relatório que tem como principal objetivo exportar os dados de dentro do sistema em uma planilha em Excel para que o usuário possa compartilhar as informações de dentro do sistema. Esse modulo estará presente no menu do sistema com as opções de relatório fixo, mas nas áreas de acompanhamento, importação e financeiro ao lado do botão de buscar estará disponível o botão para gerar arquivos Excel, desta forma se o usuário precisar de um relatório mais personalizado, ele poderá gerar selecionando os filtros da tela. Os relatórios fixos que já estará presente no sistema são os levantados como mais importante para o usuário.
O último modulo do sistema é o financeiro, com o objetivo de gerenciar as receitas e despesas do Operacional da WTA. Esse módulo irá gerar receitas automaticamente referente ao FEEs e valores de dólar adquiridos, mas o usuário irá cadastrar as despesas e outras receitas. No módulo terá telas distintas para que o usuário possa cadastrar e alterar os fornecedores, centro de custo, tipos de lançamentos, clientes e as categorias, que possa fazer novos lançamentos e buscas os antigos e criar uma agenda financeira, assim como o DRE.
