const urlGlobal = `https://localhost:44318/basico`;

const categoriaVue = new Vue({
    el: '#categoriaVue',
    data() {
        return {
            id: 0,
            nome: '',
            tipoLancamento: 0,
            arrayCategoria: []
        }
    },
    beforeCreate() { $.LoadingOverlay('show'); },
    async created() {
        await this.CarregarTipoLancamento();
        await this.Carregar();
    },
    mounted() { $.LoadingOverlay('hide'); },
    methods: {
        ValidarDados() {
            if (!this.nome || !this.tipoLancamento) {
                Swal.fire('Atenção', `O campo nome e tipo de lançamento são obrigatórios`, 'warning');
                return false;
            }

            (this.id) ? this.Editar() : this.Cadastrar();
        },
        LimparCampos() {
            this.id = 0;
            this.nome = '';
            this.tipoLancamento = 0;
        },
        PreencherCampos(id) {
            this.id = id;
            let categoria = this.arrayCategoria.filter(s => s.Id === id)[0];
            this.nome = categoria.Nome;
            this.tipoLancamento = categoria.TipoLancamento.Id;
        },
        async Cadastrar() {
            $.LoadingOverlay('show');

            await axios.post(`${urlGlobal}//categorias`, {
                Nome: this.nome,
                TipoLancamentoId: this.tipoLancamento
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

            await axios.put(`${urlGlobal}/categorias/${this.id}`, {
                Nome: this.nome,
                TipoLancamentoId: this.tipoLancamento
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
                title: 'Deseja excluir essa categoria?',
                text: `Essa operação não poderá ser desfeita`,
                icon: `warning`,
                showCancelButton: true,
                cancelButtonColor: '#d33',
            }).then(result => {
                if (result.value) {
                    $.LoadingOverlay('show');

                    axios.delete(`${urlGlobal}/categorias/${id}`).then(_ => {
                        Swal.fire('Sucesso', 'Categoria excluída com sucesso', 'success');
                        this.Carregar();
                        this.LimparCampos();
                    }).catch(error => {
                        Swal.fire('Erro', 'Algo inesperado ocorreu', 'error');
                        console.log(error);
                    }).finally(_ => { $.LoadingOverlay('hide') });
                }
            })
        },
        async CarregarTipoLancamento() {
            await axios.get(`${urlGlobal}tiposlancamentos`).then(response => {
                const tiposlancamentos = response.data;
                if (tiposlancamentos.length) {
                    ddlTipoLancamento = document.getElementById('ddlTipoLancamento');

                    for (const tipoLancamento of tiposlancamentos) {
                        let option = document.createElement('option');
                        option.value = tipoLancamento.Id;
                        option.text = tipoLancamento.Nome;
                        option.mult = tipoLancamento.Multiplicador

                        ddlTipoLancamento.add(option);
                    }
                }
            }).catch(error => {
                console.log(error);
            });
        },
        async Carregar() {
            await axios.get(`${urlGlobal}/categorias`).then(response => {
                this.arrayCategoria = response.data['ativos'];
            }).catch(error => {
                console.log(error);
            });
        },
    },
});