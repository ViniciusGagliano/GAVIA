<h1>GERENCIAMENTO DE ASSISTÊNCIA À VIAGEM - GAVIA</h1>

<h2>DESCRICÃO DOS PROCESSOS – CONTEXTUALIZAÇÃO</h2>

<h3>O operativo tem como objeto realizar os pagamentos de sinistros, provedores, enviar comprovantes para central,
    gerenciar as Notas de Débitos, calcular valores dos FEEs, valores de bilhetes vendidos, cotação de dólar, fazer
    remessas internacionais e gerenciar o financeiro da empresa.</h3>

<ol type="1">
    <li>
        Reembolsos
        <ol type="a">
            <li>Reembolsos importados: o operativo importa da central a relação de reembolsos a pagar para a pasta
                reembolso e os adiciona para que sua base fique atualizada;</li>
            <ol type="i">
                O operativo irá importar os arquivos da central diretamente para o sistema. Assim criando-os dentro do
                sistema.
            </ol>
            <li>Reembolsos programados: o operativo verifica se há caixa para realizar os pagamentos e as datas do
                vencimento do mesmo para fazer a programação;</li>

            <ol type="i">
                O operativo faz a verificação das datas do vencimento e programação dentro do sistema e faz o fechamento
                dos pagamentos.
            </ol>
            <li>Reembolsos cadastrados: o operativo cadastra no banco os mesmos como favorecidos na modalidade DOC, TED
                ou entre contas do mesmo banco;</li>

            <ol type="i">
                Funcionalidade da ferramenta do Bradesco.
            </ol>
            <li>Reembolsos pagos: o operativo aguarda a auditoria e a posterior autorização da diretoria para gerar os
                comprovantes de pagamentos em PDF;</li>
            <ol type="i"> O pagamento será dos reembolsos presentes no lote do fechamento.</ol>

            <li>Reembolsos salvos: o operativo salva os comprovantes na pasta comprovantes;</li>

            <ol type="i">
                Os reembolsos já pagos estarão em uma tela de histórico de pagamento.</ol>

            <li>Reembolsos enviados: o operativo envia em nome do representante os comprovantes para o cliente, para
                central e cópia para o próprio operativo;</li>

            <ol type="i"> Processo de e-mail fora do sistema.</ol>

            <li>Reembolsos faturados: o operativo aguarda o faturamento da central dos reembolsos pagos para acompanhar
                o pagamento da Nota de Débito e conciliar os valores.</li>

            <ol type="i"> Acompanhamento do status Central dentro do sistema.</ol>

        </ol>
    </li>
    <li>Notas de Débito
        <ol type="a">
            <li>Não Faturadas: operativo importa as informações da central para a base de controle das Notas de Débito
                (data da emissão);</li>

            <ol type="i"> Importação do Excel para o sistema.</ol>
            <li>Os reembolsos dentro do sistema irão ser atualizados com as informações automaticamente.</li>

            <li>Faturadas: operativo atualiza a base de controle das Notas de Débito com as informações da central (data
                do envio);</li>

            <ol type="i"> Importação do Excel para o sistema.</ol>
            <li>Os reembolsos dentro do sistema irão ser atualizados com as informações automaticamente.</li>

            <li>Pagas: o operativo recebe o aviso da seguradora que a relação de Notas de Débito foi paga no dia x;</li>

            <ol type="i"> Na área de processamento do sistema, o usuário poderá buscar e marcar a data de pagamento.
            </ol>
        </ol>
    </li>
    <li>Remessas
        <ol type="a">

            <li>Calculada: o operativo concilia os sinistros, FEEs, e outros recebíveis internacionais das faturas
                nacionais, reembolsos nacionais e pagamentos que engloba impostos, CVE, provedores etc. e a diferença
                faz a remessa;</li>

            <ol type="i"> O sistema terá uma tela de busca com filtro, onde poderá buscar e gerar em Excel essas
                informações. Além disso, os recebíveis fixos já serão calculados quando o reembolso entrar no sistema.
            </ol>

            <li>Remetida: o operativo calcula e contrata o dólar pelo MSBANK, e envia a relação dos casos
                internacionais, junto com a carta padrão do mesmo para as remessas internacionais;</li>

            <ol type="i"> A contratação do dólar não estará no sistema, mas a relação dos casos internacionais será
                gerada pelo relatório.</ol>
        </ol>
    </li>
    <li>Relatórios de auditoria
        <ol type="a">

            <li>Relatório de Notas de Débito em aberto;</li>

            <ol type="i"> Estará disponível como relatório fixo.</ol>

            <li>Relatório de reembolsos pagos e não faturados;</li>

            <ol type="i"> Estará disponível como relatório fixo.</ol>
        </ol>
    </li>
    <li>Financeiro
        <ol type="a">

            <li>Despesas: operativo cadastra todas as contas a pagar, despesas operacionais, folha de pagamento,
                impostos, conforme seu vencimento em uma planilha;</li>

            <ol type="i"> Cadastramento será feito dentro do sistema na tela de lançar despesas, com as informações
                acima, gerando um fechamento para ser autorizado.</ol>

            <li>Receitas: operativo cadastra todas as receitas a receber;</li>

            <ol type="i"> As receitas vindas dos sinistros serão lançadas automaticamente no momento que a data de
                pagamento for inserida, mas o sistema terá uma tela para lançar receitas manualmente.</ol>

            <li>Conciliação: operativo concilia as contas bancárias, despesas e receitas do grupo;</li>

            <ol type="i"> DRE do sistema.</ol>

            <li>Distribuição: operativo faz a distribuição de lucros entre as empresas do grupo;</li>

            <ol type="i"> O sistema terá uma tela para cadastrar lançamentos feitos, onde irá cadastrar essas
                distribuições.</ol>

            <li>Notas fiscais: operativo emite NF referente às comissões, FEEs, e outras receitas;</li>

            <ol type="i"> Operação fora do sistema.</ol>

            <li>Contabilidade: operativo envia para a contabilidade todos comprovantes de pagamentos de todas as
                despesas, as receitas e outras para apuração do resultado fiscal.</li>

            <ol type="i"> Operação fora do sistema.</ol>
        </ol>
    </li>
    <li>Diretoria
        <ol type="a">

            <li>Autoriza os reembolsos;</li>

            <ol type="i"> Faz o fechamento de lote dos reembolsos.</ol>

            <li>Autoriza os pagamentos das despesas em geral;</li>

            <ol type="i"> Faz o fechamento de lote das despesas.</ol>

            <li>Gerencia o financeiro e o comercial do grupo de empresas;</li>

            <ol type="i"> Visualização por dentro do sistema.</ol>
        </ol>
    </li>
</ol>



<h2>OBJETIVO</h2>

O sistema Gavia tem como objetivo informatizar os processos realizados hoje pelo operativo da WTA. Este sistema contará
com diversas funcionalidades que são específicas de um dos módulos apresentados a seguir.
O modulo de importação são as funcionalidades que permitirá o usuário importar os arquivos em Excel recebidos da
Central. Além disso, o módulo terá uma tela mostrando todas as importações realizadas, distinguindo quais foram os
arquivos importados, o usuário responsável pela importação, à data que foi importada e a quantidade de registros.
Esse módulo que será responsável por criar as notas de débitos dentro do sistema, ou seja, uma cópia virtual com todas
as informações que foram importadas junto do Excel. Os valores de comissão do FEE e bilhetes vendidos serão calculados
automaticamente, visto que são valores fixos.
Essa operação será realizada importando um arquivo em Excel e selecionando a Seguradora que será vinculada com as notas
de débitos geradas pelo arquivo. Será possível importar dois tipos diferentes, o relatório que irá gerar as notas de
débito dentro do sistema e o relatório que irá faturar as notas de débitos cadastradas dentro do sistema.
O segundo módulo disponível será o de acompanhamento e processamento, nele o usuário poderá buscar diversas notas de
débitos na base a partir dos filtros disponibilizados, estes filtros serão todos presentes nos arquivos em Excel e mais
alguns outros campos exclusivos do sistema para controlar as informações.
O sistema terá uma tela de busca com filtros e ações em cima dos resultados gerados.
Para os processamentos que o módulo disponibilizará serão as alterações das informações em lote de todas as notas de
débitos buscadas, essas ações serão apenas das informações que esperam alguma modificação, por exemplo, os status da
nota de débito, inserir a data de previsão de pagamento, adicionar uma observação.
Um dos campos exclusivos do sistema é o tipo da nota de débito e o que é preciso entender que elas englobam a venda do
bilhete e os sinistros. Os sinistros englobam os reembolsos, as faturas e a comissão do FEE, e são divididos entre
nacionais e internacionais. A comissão do FEE ficará englobada nos sinistros, visto que essa comissão só ocorre se
houver um sinistro reportado.
Outro campo exclusivo do sistema é a informação status e representará a etapa na qual a nota de débito se encontra.
Esses status serão divididos em três categorias, representados pela interação que ocorre fora do sistema. A interação
com o cliente que teve um sinistro, os pagamentos da seguradora e toda a troca de informação com a central.

A categoria status “cliente” estão relacionada com os pedidos de pagamentos sobre os sinistros vindo da central. Os
status que foram levantados no momento são: cancelado, para os sinistros que não devem ser pagos; não pago, para os
sinistros que não foram pagos; autorizado, para os sinistros que ainda não foram pagos, mas já estão com o pagamento
agendado ou já foram autorizados para o pagamento do dia; pago, para os sinistros que já foram pagos aos clientes.
A categoria status “central” estão relacionados com a situação da nota de débito vindo da central WTA. Os status que
foram levantados no momento são: sem comprovante, para as notas de débito que ainda não tiveram seus comprovantes
gerados, geralmente usados para os sinistros que foram pagos; não faturada, para as notas de débito com os comprovantes
gerados e enviados para Central, mas ainda sem fatura gerada; faturado, para as notas de débito que já tiveram suas
faturas geradas; remetido, para as remessas internacionais que já foram enviadas para central via MSBANK.
A categoria status “seguradora” estão relacionados com os pagamentos das seguradoras. Os status levantados no momento
são: não pago, para as notas de débito que ainda não tiveram pagamento; pago, para as notas de débito que já tiveram o
pagamento.
Com esses status o usuário poderá buscar, filtrar e interagir com as notas de débito no momento desejável, segregar as
atividades dos funcionários para cada um dos status específico, e dar flexibilidade para lidar com os diferentes
processos de cada seguradoras.
Com as informações do tipo da nota de debito e status é possível controlar toda a operação de assistência a viagens,
incluindo os processos que o operativo realiza para cada seguradora, ou seja, o sistema é flexível o suficiente para
controlar a operação onde é esperado o pagamento da seguradora e depois o pagamento ao cliente e o caso onde primeiro é
pago o cliente e depois ocorre o pagamento da mesma.
O terceiro módulo é o de relatório que tem como principal objetivo exportar os dados de dentro do sistema em uma
planilha em Excel para que o usuário possa compartilhar as informações de dentro do sistema. Esse módulo estará presente
em todas as áreas de busca do sistema, assim como em uma tela separada que será os relatórios fixos. Desta forma o
usuário pode gerar um relatório mais personalizado a partir da busca que ele fizer.
Os relatórios fixos que já estará presente no sistema são os “Reembolsos pagos sem emissão nota de débito” e “Nota de
débito em aberto”. Estes foram selecionados, pois foram levantados como os mais importantes para o operativo da WTA.
O último módulo do sistema é o financeiro ou CAP, com o objetivo de gerenciar as receitas e despesas do operativo da
WTA. Esse módulo irá cadastrar receitas automaticamente, referentes aos FEEs, bilhetes vendidos e valores de dólares
contratados, mas o usuário poderá cadastrar as despesas e outras receitas.
No módulo terá telas distintas para que o usuário possa cadastrar e alterar: os fornecedores; centro de custo; tipos de
lançamentos; clientes; categorias. Telas de novos lançamentos e buscas também estarão disponíveis, assim como a opção de
criar uma agenda financeira e DRE.