const urlGlobal = `https://localhost:44318/basico`;

const sinistroVue = new Vue({
    el: '#sinistroVue',
    data() {
        return {
            id: 0,
            arraySinistro: [],
            form: {
                dtInicial: ``,
                dtFinal: ``,
                tipoData: 1,
                representante: 0,
                seguradora: 0,
                cobertura: '',
                segurado: ``,
                beneficiario: ``,
                bilhete: ``,
                voucher: ``,
                dolar: ``,
                real: ``,
                referencia: ``,
                notaDebito: ``,
                importacao: ``,
            }
        }
    },
    beforeCreate() { $.LoadingOverlay('show'); },
    async created() {
        await this.CarregarSeguradora();
        await this.CarregarRepresentante();
        const importacaoId = parseInt(new URLSearchParams(window.location.search).get('importacaoId')) || 0;
        if (importacaoId) {
            this.form.importacao = importacaoId;
            this.Carregar();
        }
    },
    mounted() { $.LoadingOverlay('hide'); },
    methods: {
        LimparCampos() {
            for (const key in this.form) {
                if (this.form.hasOwnProperty(key)) {
                    this.form[key] = ``;
                }
            }
        },
        async Cadastrar() {
            $.LoadingOverlay('show');

            await axios.post(`${urlGlobal}/sinistros`, {
                Nome: this.nome
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
            await axios.put(`${urlGlobal}/sinistros/${this.id}`, {
                Nome: this.nome
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
                title: 'Deseja excluir esse emissor?',
                text: `Essa operação não poderá ser desfeita`,
                icon: `warning`,
                showCancelButton: true,
                cancelButtonColor: '#d33'
            }).then(result => {
                if (result.value) {
                    $.LoadingOverlay('show');

                    axios.delete(`${urlGlobal}/sinistros/${id}`).then(_ => {
                        Swal.fire('Sucesso', 'Emissor excluído com sucesso', 'success');
                        this.Carregar();
                    }).catch(error => {
                        Swal.fire('Erro', 'Algo inesperado ocorreu', 'error');
                        console.log(error);
                    }).finally(_ => { $.LoadingOverlay('hide') });
                }
            })
        },
        async Carregar() {
            await axios.get(`${urlGlobal}/sinistros`).then(response => {
                this.arraySinistro = response.data['ativos'];
            }).catch(error => {
                console.log(error);
            });
        },
        async CarregarSeguradora() {
            await axios.get(`${urlGlobal}/seguradoras`).then(response => {
                const seguradoras = response.data["ativos"];
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
        async CarregarRepresentante() {
            await axios.get(`${urlGlobal}/representantes`).then(response => {
                const representantes = response.data["ativos"];
                if (representantes.length) {
                    const ddlRepresentante = document.getElementById('ddlRepresentante');
                    for (const representante of representantes) {
                        let option = document.createElement('option');
                        option.value = representante.Id;
                        option.text = representante.Nome;
                        ddlRepresentante.add(option);
                    }
                }
            }).catch(error => {
                console.log(error);
            });
        },
    },
});