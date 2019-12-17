const urlGlobal = `https://localhost:44318/basico`;

const patrocinioVue = new Vue({
    el: '#patrocinioVue',
    data() {
        return {
            id: 0,
            seguradora: 0,
            representante: 0,
            arrayPatrocinio: []
        }
    },
    beforeCreate() { $.LoadingOverlay('show'); },
    async created() {
        await this.Carregar();
        await this.CarregarSeguradora();
        await this.CarregarRepresentante();
    },
    mounted() { $.LoadingOverlay('hide'); },
    methods: {
        ValidarDados() {
            if (!this.seguradora || !this.representante) {
                Swal.fire('Atenção', `O campo seguradora e representante são obrigatórios`, 'warning');
                return false;
            }

            (this.id) ? this.Editar() : this.Cadastrar();
        },
        LimparCampos() {
            this.id = 0;
            this.seguradora = 0;
            this.representante = 0;
        },
        PreencherCampos(id) {
            this.id = id;
            let patrocinio = this.arrayPatrocinio.filter(s => s.Id === id)[0];
            this.seguradora = patrocinio.Seguradora.Id;
            this.representante = patrocinio.Representante.Id;
        },
        async Cadastrar() {
            $.LoadingOverlay('show');

            await axios.post(`${urlGlobal}/patrocinios`, {
                SeguradoraId: this.seguradora,
                RepresentanteId: this.representante,
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

            await axios.put(`${urlGlobal}/patrocinios/${this.id}`, {
                SeguradoraId: this.seguradora,
                RepresentanteId: this.representante,
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
                title: 'Deseja excluir esse patrocínio?',
                text: `Essa operação não poderá ser desfeita`,
                icon: `warning`,
                showCancelButton: true,
                cancelButtonColor: '#d33',
            }).then(result => {
                if (result.value) {
                    $.LoadingOverlay('show');

                    axios.delete(`${urlGlobal}/patrocinios/${id}`).then(_ => {
                        Swal.fire('Sucesso', 'Patrocínio excluído com sucesso', 'success');
                        this.Carregar();
                    }).catch(error => {
                        Swal.fire('Erro', 'Algo inesperado ocorreu', 'error');
                        console.log(error);
                    }).finally(_ => { $.LoadingOverlay('hide') });
                }
            })
        },
        async Carregar() {
            await axios.get(`${urlGlobal}/patrocinios`).then(response => {
                this.arrayPatrocinio = response.data;
            }).catch(error => {
                console.log(error);
            });
        },
        async CarregarSeguradora() {
            await axios.get(`${urlGlobal}/seguradoras`).then(response => {
                const seguradoras = response.data["ativos"];
                if (seguradoras.length) {
                    let ddlSeguradora = document.getElementById('ddlSeguradora');

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