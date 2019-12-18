const urlGlobal = `https://localhost:44318/basico`;

const importacaoVue = new Vue({
    el: '#importacaoVue',
    data: {
        seguradora: 0,
        tipoArquivo: 1,
        arrayImportacao: [],
        arquivo: null,
    },
    beforeCreate() { $.LoadingOverlay('show') },
    async created() {
        await this.Carregar();
        await this.CarregarSeguradora();
    },
    mounted() {
        $('#modalImportacao').on('hidden.bs.modal', () => { this.LimparCampos(); })
        $.LoadingOverlay('hide');
    },
    methods: {
        OpenModal() { $('#modalImportacao').modal('show'); },
        LimparCampos() {
            this.seguradora = 0;
            this.tipoArquivo = 1;
            this.arquivo = null;
            $('#arqSeguradora').val('');
        },
        async ValidarCampos() {
            if (!parseInt(this.seguradora)) {
                swal.fire('Atenção', `O campo seguradora deve ser preenchido`, 'warning');
                return false;
            }

            const file = document.getElementById('arqSeguradora').files;
            if (!file.length) {
                swal.fire(`Atenção`, `Selecione algum arquivo`, `warning`);
                return false;
            }

            const isValidExtension = /(\.xls)?(.xlsx)?$/;
            if (!isValidExtension.exec(file[0].name)) {
                swal.fire(`Atenção`, `Apenas arquivos de extensões .xls e .xlsx`, 'warning');
                return false;
            }

            if (!typeof file[0].name === 'string') {
                swal.fire(`Atenção`, `Nome do arquivo inválido`, 'warning');
                return false;
            }

            this.arquivo = file[0];
            await this.ImportarArquivo();
        },
        async ImportarArquivo() {
            $.LoadingOverlay('show');
            var formData = new FormData();
            formData.append(this.arquivo.name, this.arquivo);

            await axios.post(`${urlGlobal}/arquivos?seguradoraId=${this.seguradora}&antecipacao=false`, formData).then(_ => {
                Swal.fire('Sucesso', `Importação concluída`, 'success');
                this.Carregar();
                this.LimparCampos();
            }).catch(error => {
                swal.fire('Erro', `Importação falhou`, 'error');
                console.log(error);
            }).always(_ => $.LoadingOverlay('hide'));
        },
        Visualizar(id) {
            window.open(`sinistro.html?id=${id}`, '_self')
        },
        Processar(id) {
            axios.get(`${urlGlobal}/processar/${id}`).then(_ => {
                Swal.fire('Sucesso', `Processamento concluído`, 'success');
                this.arrayImportacao.filter(i => i.Id === id)[0].Processada = true;
            }).catch(error => {
                Swal.fire('Erro', `Processamento falhou`, 'error');
                console.log(error);
            });
        },
        async Excluir(id) {
            Swal.fire({
                title: 'Deseja excluir essa importação?',
                text: `Essa operação não poderá ser desfeita`,
                icon: `warning`,
                showCancelButton: true,
                cancelButtonColor: '#d33',
            }).then(result => {
                if (result.value) {
                    $.LoadingOverlay('show');

                    axios.delete(`${urlGlobal}/importacoes/${id}`).then(_ => {
                        Swal.fire('Sucesso', 'Importação excluída com sucesso', 'success');
                        this.Carregar();
                    }).catch(error => {
                        Swal.fire('Erro', 'Algo inesperado ocorreu', 'error');
                        console.log(error);
                    }).finally(_ => { $.LoadingOverlay('hide') });
                }
            })
        },
        async Carregar() {
            axios.get(`${urlGlobal}/importacoes`).then(response => {
                this.arrayImportacao = response.data["ativos"];
            }).catch(error => {
                console.log(error);
            });
        },
        async CarregarSeguradora() {
            axios.get(`${urlGlobal}/seguradoras`).then(response => {
                const seguradoras = response.data["ativos"];
                if (seguradoras.length) {
                    const ddlSeguradora = document.getElementById('ddlSeguradora');

                    for (const seguradora of seguradoras) {
                        let option = document.createElement('option');
                        option.value = seguradora.Id;
                        option.text = seguradora.Nome;
                        option.setAttribute('data-antecipacao', seguradora.Antecipacao);
                        ddlSeguradora.add(option);
                    }
                }
            }).catch(error => {
                console.log(error);
            });
        },
    },
});