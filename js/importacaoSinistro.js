const importacaoSinistroVue = new Vue({
    el: '#importacaoSinistroVue',
    data: {
        seguradora: 0,
        tipoArquivo: 1,
        arrayImportacao: [],
        arquivo: null,
    },
    mounted() {
        $('#modalImportacao').on('hidden.bs.modal', () => { this.LimparCampos(); })
    },
    methods: {
        OpenModal() { $('#modalImportacao').modal('show'); },
        LimparCampos() {
            this.seguradora = 0;
            this.tipoArquivo = 1;
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

            $.LoadingOverlay('show');
            this.arquivo = file[0];
            try {
                await this.ImportarArquivo();
            } catch (error) {
                console.log(error.responseText);
            }
        },
        async ImportarArquivo() {
            return new Promise((resolve, reject) => {
                var formData = new FormData();
                formData.append(this.arquivo.name, this.arquivo);

                $.ajax({
                    type: 'POST',
                    url: `https://localhost:44332/importacao/insert`,
                    data: formData,
                    cache: false,
                    contentType: false,
                    processData: false,
                    done: response => {
                    }
                }).done(response => {
                    this.arquivo = null;
                    $('#arqSeguradora').val('');
                    swal.fire('Sucesso', `Importação concluída`, 'success');
                    resolve(response);
                }).catch(error => {
                    console.log(error);
                    swal.fire('Erro', `Importação falhou`, 'error');
                    reject(error);
                }).always(() => { $.LoadingOverlay('hide'); })
            });
        }
    },
});