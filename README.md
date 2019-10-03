# Sistema de Gerenciamento de Seguro de Viagem:

DESCRIÇÃO DOS PROCESSOS DA WTA BR
SANCOR – REEMBOLSOS:

- BRUNA – OPERATIVO
  - Central envia diariamente a relação de reembolsos a pagar SANCOR via e-mail, Bruna importa os mesmos para planilha base, onde constam todas as relações de reembolsos.
    - Importação do Excel para dentro do sistema.
  - Aguarda o Fernando fazer a programação dos reembolsos a pagar do dia, conforme a disponibilidade de caixa, prazo de pagamento.
  - Seleciona os reembolsos com os status A pagar/Liberado para pagamento e fazer os pagamentos mudando o status automaticamente para Pago.
  - Recepciona a planilha dos reembolsos a pagar do dia e os cadastra como Doc/Ted na conta corrente como favorecidos para serem auditados e autorizados pelo Bruno. Essa função será feita com módulo de interface do Bradesco.
    - Lançamento pelo Bradesco
  - Após a autorização, ela salva os comprovantes de pagamentos em uma pasta de comprovantes e os remete via e-mail para a central, representantes(seguradora) e os clientes e muda o status dos reembolsos para enviados.
    - Histórico
  - Com a relação de reembolsos pagos ela atualiza a base, lançando o dia em que foi efetuado o pagamento. A central de posse dos comprovantes processa e gera e envia as ND (fatura) para as seguradoras. Essas recebem as Notas de Débito e enviam um aviso ao Fernando que no dia x serão pagas tantas Notas de Débito.
    - Status
  - Após os pagamentos das faturas (ND), ela emite as Notas Fiscais de serviços contra as seguradoras.
    - Emite NF

- BRUNA – ADMINSTRATIVO
  - Cadastra todas as contas a pagar, conforme seu vencimento em uma planilha.
    - CAP
  - No respectivo dia do vencimento cadastra a despesa no banco ou gera boleto e aguarda autorização do Bruno.
    - CAP
  - Salva os comprovantes das despesas pagas e as lança no demonstrativo de pagamentos.
    - CAP
  - Envia os comprovantes para a contabilidade.
    - PDF
  - Faz a conciliação de todas as contas bancárias do grupo (8) com as despesas e receitas do grupo. 
    - DRE

- FERNANDO – OPERATIVO
  - Atualiza a base das Notas de Débito com as informações da central, se foi faturada e da seguradora, se foi paga ou quando será paga.
  - Atualização de status por importação em Excel
  - Faz a programação dos reembolsos diários de acordo com o prazo de pagamento, nunca superior a 30 dias da data do pagamento ou diariamente conforme o recebido dos relatórios.
  - Altera os status dos reembolsos para ser realiza os pagamentos
  - Filtra os casos internacionais para as remessas e os nacionais para pagamento.
  - Faz pagamento dos nacionais
  - Calcula valores do FEE o que é da central e o que é da WTA
  - Cálculo automático do FEE por regra
  - Faz a cotação e contratação do dólar com o MSBANK
  - Faz as remessas internacionais para a central, discriminando o que é reembolso internacional, faturas internacionais, FEE internacional.
  - Envia carta padrão ao banco da remessa com a respectiva relação dos clientes.
  - Envia comprovante da remessa para central
  - Faz a conciliação entre as remessas internacionais e o que foi pago pela WTA
  - Calcula os valores de bilhetes vendidos e os FEEs nacionais para enviar a Bruna gerar a NF 
- AUDITORIA
  - Verificar se a lista de favorecidos cadastrados no banco para DOC E TED são os mesmos que constam na relação de reembolsos do dia, observando o nome, valor, data de pagamento do reembolso e se houve duplicidade de pagamentos.

- BRUNO
  - Autoriza os pagamentos dos reembolsos
  - Autoriza os pagamentos das despesas operacionais
  - Gerencia as contas da empresa
---
O sistema GSV tem como objetivo informatizar os processos realizados hoje pela equipe Operacional da WTA. Este sistema contará com diversas funcionalidades que são específicas de um dos módulos apresentados a seguir.
O modulo de importação são as funcionalidades que permitirá o usuário importar os arquivos em Excel recebidos pela Central e Seguradora. Além disso, o módulo terá uma tela mostrando todas as importações realizadas, distinguindo quais foram os tipos de importações, qual foi o usuário responsável pela importação, a data que foi importada, quantidade de registros. 
Esse módulo que será responsável por criar as notas de débitos dentro do sistema, ou seja, uma cópia virtual com todas as informações que foram importadas junto do Excel. Os valores de comissão do FEE e bilhetes vendidos serão calculados automaticamente visto são valores fixos. 
Essas importações serão realizadas importando um arquivo em Excel e selecionando a Seguradora que será vinculada com as notas de débitos geradas pelo arquivo. Será possível importar 3 tipos diferentes, o relatório de reembolso que irá gerar as notas de débito dentro do sistema, o relatório de nota de débito que irá faturar as notas de débitos cadastradas dentro do sistema e o relatório enviado pela seguradora que irá consolidar o fato que foi recebido o valor. 
O segundo modulo disponível será o de acompanhamento e processamento, nele o usuário poderá buscar diversas notas de débitos na base a partir dos filtros disponibilizados, estes filtros serão todos presentes nos arquivos em Excel e alguns outros que o sistema terá, por exemplo, status e tipo de nota de débito. 
O sistema terá uma tela de busca com filtros e ações em cima dos resultados gerados. 
Para os processamentos que o módulo disponibilizará serão as alterações das informações em lote de todas as notas de débitos buscadas, essas ações serão apenas das informações que esperam alguma modificação, por exemplo, os status da nota de débito, inserir a data de previsão de pagamento, adicionar uma observação. 
Para esse controle é preciso entender que as notas de débitos englobam a venda do bilhete e os sinistros. Os sinistros englobam os reembolsos, as faturas e a comissão do FEE, e são divididos entre nacionais e internacionais. A comissão do FEE ficará englobada nos sinistros, visto que essa comissão só ocorrer se houver um sinistro reportado. Com isso é possível controlar toda a operação de seguro de viagem, incluindo os diferentes métodos de pagamentos das seguradoras.
O status informados anterior serão usados para controlar as etapas da nota de débito e serão divididos em 3 categorias diferentes, Cliente, Central e Seguradora. 
Os status cliente levantados no momento são: cancelado, para as notas de débito que não devem ser pagos; não pago, para os notas de débitos que não foram pagos; autorizado, para as notas de débito que ainda não foram pagos, mas já estão com o pagamento agendado ou já foram autorizados para o pagamento do dia; pago, para as notas de débito que já foram pagos aos clientes. 
Os status central levantados no momento são: sem comprovante, para as notas de débito que ainda não tiveram seus comprovantes gerados, geralmente usado para os reembolsos que foram pagos; não faturada, para as notas de débito com os comprovantes gerados e enviados para Central, mas ainda sem fatura gerada; faturado, para as notas de débito que já tiveram suas faturas geradas. 
O status seguradora levantados no momento são: não pago, para as notas de débito que ainda não tiveram pagamento pela seguradora; pago, para as notas de débito que já tiveram pagamento pela seguradora. 
Com esses status o usuário poderá buscar, filtrar e interagir com as notas de débito no momento desejável, segregar as atividades dos funcionários para cada um dos status específico, e dar flexibilidade para lidar com as diferentes formas de pagamento feito pelas seguradoras.
O 3º é o modulo de relatório que tem como principal objetivo exportar os dados de dentro do sistema em uma planilha em Excel para que o usuário possa compartilhar as informações de dentro do sistema. Esse modulo estará presente em todas as áreas de busca do sistema, assim como em uma tela separada que será os relatórios fixos. Desta forma o usuário pode gerar um relatório mais personalizado a partir da busca que ele fizer. 
Os relatórios fixos que já estará presente no sistema são os “Reembolsos pagos sem emissão nota de débito” e “nota de débito em aberto”. Estes foram selecionados, pois foram levantados como os mais importantes para o operacional da WTA.
O último modulo do sistema é o financeiro ou CAP, com o objetivo de gerenciar as receitas e despesas do Operacional da WTA. Esse módulo irá gerar receitas automaticamente referente ao FEEs, bilhetes vendidos e valores de dólar adquiridos, mas o usuário irá cadastrar as despesas e outras receitas. 
No módulo terá telas distintas para que o usuário possa cadastrar e alterar: os fornecedores; centro de custo; tipos de lançamentos; clientes; categorias. Telas de novos lançamentos e busca também estarão disponíveis, assim como a opção de criar uma agenda financeira e DRE.
