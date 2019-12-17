const urlGlobal = `https://localhost:44318/basico`;

const clienteVue = new Vue({
    el: '#clienteVue',
    data() {
        return {
            id: 0,
            nome: '',
            seguradoraId: 0,
            arrayCliente: []
        }
    },
    beforeCreate() { $.LoadingOverlay('show'); },
    async created() {
        await this.Carregar();
        await this.CarregarSeguradoras();
    },
    mounted() { $.LoadingOverlay('hide'); },
    methods: {
        ValidarDados() {
            if (!this.nome) {
                Swal.fire('Atenção', `O campo nome é obrigatório`, 'warning');
                return false;
            }

            (this.id) ? this.Editar() : this.Cadastrar();
        },
        LimparCampos() {
            this.id = 0;
            this.nome = ``;
            this.seguradoraId = 0;
        },
        PreencherCampos(id) {
            this.id = id;
            let cliente = this.arrayCliente.filter(s => s.Id === id)[0];
            this.nome = cliente.Nome;
            this.seguradoraId = cliente.Seguradora.Id;
        },
        async Cadastrar() {
            $.LoadingOverlay('show');

            await axios.post(`${urlGlobal}/clientes`, {
                Nome: this.nome,
                SeguradoraId: this.seguradoraId
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

            await axios.put(`${urlGlobal}/clientes/${this.id}`, {
                Nome: this.nome,
                SeguradoraId: this.seguradoraId
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
                title: 'Deseja excluir esse cliente?',
                text: `Essa operação não poderá ser desfeita`,
                icon: `warning`,
                showCancelButton: true,
                cancelButtonColor: '#d33',
            }).then(result => {
                if (result.value) {
                    $.LoadingOverlay('show');

                    axios.delete(`${urlGlobal}/clientes/${id}`).then(_ => {
                        Swal.fire('Sucesso', 'Cliente excluído com sucesso', 'success');
                        this.Carregar();
                        this.LimparCampos();
                    }).catch(error => {
                        Swal.fire('Erro', 'Algo inesperado ocorreu', 'error');
                        console.log(error);
                    }).finally(_ => { $.LoadingOverlay('hide') });
                }
            })
        },
        async Carregar() {
            await axios.get(`${urlGlobal}/clientes`).then(response => {
                this.arrayCliente = response.data['ativos'];
            }).catch(error => {
                console.log(error);
            });
        },
        async CarregarSeguradoras() {
            await axios.get(`${urlGlobal}/seguradoras`).then(response => {
                const seguradoras = response.data['ativos'];
                if (seguradoras.length) {
                    const ddlSeguradora = document.getElementById('ddlSeguradora');

                    for (const seguradora of seguradoras) {
                        let option = document.createElement('option');
                        option.value = seguradora.Id;
                        option.text = seguradora.Nome;

                        ddlSeguradora.add(option);
                    }
                }
            }).catch(error => {
                console.log(error);
            });
        },
    },
});