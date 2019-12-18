const urlGlobal = `https://localhost:44318/basico`;

$(document).ready(_ => {
    $('#valor').mask('#.##0,00', { reverse: true });
});

const lancamentoVue = new Vue({
    el: '#lancamentoVue',
    data() {
        return {
            id: 0,
            descricao: '',
            custoFixo: 0,
            valor: '',
            dataLancamento: '',
            cliente: 0,
            contaBancaria: 0,
            centroCusto: 0,
            categoria: 0,
            fornecedor: 0,
            arrayLancamento: []
        }
    },
    beforeCreate() { $.LoadingOverlay('show'); },
    async created() {
        await this.Carregar();
        await this.CarregarCategoria();
        await this.CarregarCentroCusto();
        await this.CarregarContaBancaria();
        await this.CarregarCliente();
        await this.CarregarFornecedor();
    },
    mounted() { $.LoadingOverlay('hide'); },
    methods: {
        ValidarDados() {
            if ([!!this.valor, !!this.dataLancamento, !!this.cliente, !!this.contaBancaria, !!this.centroCusto, !!this.categoria, !!this.fornecedor]
                .includes(false)) {
                Swal.fire('Atenção', `Verifique os campos obrigatórios`, 'warning');
                return false;
            }

            (this.id) ? this.Editar() : this.Cadastrar();
        },
        LimparCampos() {
            this.id = 0;
            this.descricao = '';
            this.custoFixo = 0;
            this.valor = '';
            this.dataLancamento = '';
            this.cliente = 0;
            this.contaBancaria = 0;
            this.centroCusto = 0;
            this.categoria = 0;
            this.fornecedor = 0;
        },
        PreencherCampos(id) {
            this.id = id;
            let lancamento = this.arrayLancamento.filter(s => s.Id === id)[0];
            this.descricao = lancamento.Descricao;
            this.custo = lancamento.CustoFixo;
            this.valor = lancamento.Valor;
            this.dataLancamento = lancamento.DataLancamento.split('T')[0];
            this.cliente = lancamento.Cliente.Id;
            this.contaBancaria = lancamento.ContaBancaria.Id;
            this.centroCusto = lancamento.CentroCusto.Id;
            this.categoria = lancamento.Categoria.Id;
            this.fornecedor = lancamento.Fornecedor.Id;
        },
        async Cadastrar() {
            $.LoadingOverlay('show');
            let Valor = this.valor.split('.').join('').split(',').join('.');

            await axios.post(`${urlGlobal}/lancamentos`, {
                Descricao: this.descricao,
                CustoFixo: this.custoFixo,
                Valor,
                DataLancamento: this.dataLancamento,
                ClienteId: this.cliente,
                ContaBancariaId: this.contaBancaria,
                CentroCustoId: this.centroCusto,
                CategoriaId: this.categoria,
                FornecedorId: this.fornecedor,
            }).then(_ => {
                Swal.fire('Sucesso', 'Cadastro realizado com sucesso', 'success');
                this.Carregar();
                this.LimparCampos();
            }).catch(error => {
                Swal.fire('Erro', 'Algo inesperado ocorreu', 'error');
                console.log(error);
            }).finally(_ => $.LoadingOverlay('hide'));
        },
        async Editar() {
            $.LoadingOverlay('show');

            let Valor = (typeof (this.valor) == 'number') ? this.valor : this.valor.split('.').join('').split(',').join('.');

            await axios.put(`${urlGlobal}/lancamentos/${this.id}`, {
                Descricao: this.descricao,
                CustoFixo: this.custoFixo,
                Valor,
                DataLancamento: this.dataLancamento,
                ClienteId: this.cliente,
                ContaBancariaId: this.contaBancaria,
                CentroCustoId: this.centroCusto,
                CategoriaId: this.categoria,
                FornecedorId: this.fornecedor,
            }).then(_ => {
                Swal.fire('Sucesso', 'Dados alterado com sucesso', 'success');
                this.Carregar();
                this.LimparCampos();
            }).catch(error => {
                Swal.fire('Erro', 'Algo inesperado ocorreu', 'error');
                console.log(error);
            }).finally(_ => { $.LoadingOverlay('hide') });
        },
        async Excluir(id) {
            Swal.fire({
                title: 'Deseja excluir esse lancamento?',
                text: `Essa operação não poderá ser desfeita`,
                icon: `warning`,
                showCancelButton: true,
                cancelButtonColor: '#d33',
            }).then(result => {
                if (result.value) {
                    $.LoadingOverlay('show');

                    axios.delete(`${urlGlobal}/lancamentos/${id}`).then(_ => {
                        Swal.fire('Sucesso', 'Lancamento excluído com sucesso', 'success');
                        this.Carregar();
                    }).catch(error => {
                        Swal.fire('Erro', 'Algo inesperado ocorreu', 'error');
                        console.log(error);
                    }).finally(_ => { $.LoadingOverlay('hide') });
                }
            })
        },
        async Carregar() {
            await axios.get(`${urlGlobal}/lancamentos`).then(response => {
                // $('#tblLancamento').DataTable().destroy();
                this.arrayLancamento = response.data['ativos'];
            }).catch(error => {
                console.log(error);
            });
            // $('#tblLancamento').DataTable();
        },
        async CarregarCliente() {
            axios.get(`${urlGlobal}/clientes`).then(response => {
                const clientes = response.data["ativos"];
                if (clientes.length) {
                    let ddlCliente = document.getElementById('ddlCliente');
                    for (const cliente of clientes) {
                        let option = document.createElement('option');
                        option.value = cliente.Id;
                        option.text = cliente.Nome;
                        ddlCliente.add(option);
                    }
                }
            }).catch(error => {
                console.log(error);
            });
        },
        async CarregarContaBancaria() {
            axios.get(`${urlGlobal}/contasbancarias`).then(response => {
                const contaBancarias = response.data["ativos"];
                if (contaBancarias.length) {
                    let ddlContaBancaria = document.getElementById('ddlContaBancaria');
                    for (const contaBancaria of contaBancarias) {
                        let option = document.createElement('option');
                        option.value = contaBancaria.Id;
                        option.text = contaBancaria.Nome;
                        ddlContaBancaria.add(option);
                    }
                }
            }).catch(error => {
                console.log(error);
            });
        },
        async CarregarCentroCusto() {
            axios.get(`${urlGlobal}/centroscustos`).then(response => {
                const centroCustos = response.data["ativos"];
                if (centroCustos.length) {
                    let ddlCentroCusto = document.getElementById('ddlCentroCusto');
                    for (const centroCusto of centroCustos) {
                        let option = document.createElement('option');
                        option.value = centroCusto.Id;
                        option.text = centroCusto.Nome;
                        ddlCentroCusto.add(option);
                    }
                }
            }).catch(error => {
                console.log(error);
            });
        },
        async CarregarCategoria() {
            axios.get(`${urlGlobal}/categorias`).then(response => {
                const categorias = response.data["ativos"];
                if (categorias.length) {
                    let ddlCategoria = document.getElementById('ddlCategoria');
                    for (const categoria of categorias) {
                        let option = document.createElement('option');
                        option.value = categoria.Id;
                        option.text = categoria.Nome;
                        ddlCategoria.add(option);
                    }
                }
            }).catch(error => {
                console.log(error);
            });
        },
        async CarregarFornecedor() {
            axios.get(`${urlGlobal}/fornecedores`).then(response => {
                const fornecedores = response.data["ativos"];
                if (fornecedores.length) {
                    let ddlFornecedor = document.getElementById('ddlFornecedor');
                    for (const fornecedor of fornecedores) {
                        let option = document.createElement('option');
                        option.value = fornecedor.Id;
                        option.text = fornecedor.Nome;
                        ddlFornecedor.add(option);
                    }
                }
            }).catch(error => {
                console.log(error);
            });
        },
    },
});