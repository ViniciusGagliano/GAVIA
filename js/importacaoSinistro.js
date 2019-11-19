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
                let model = {
                    SeguradoraId: this.seguradora,
                    Antecipacao: this.tipoArquivo,
                    Arquivo: formData
                };

                // var settings = {
                //     "async": true,
                //     "crossDomain": true,
                //     "url": "https://localhost:44332/importacao/insert?seguradoraId=3&antecipacao=1",
                //     "method": "POST",
                //     "headers": {
                //         "seguradoraId": "3",
                //         "antecipacao": "1",
                //         "Accept": "*/*",
                //         "Cache-Control": "no-cache",
                //         "Host": "localhost:44332",
                //         "Accept-Encoding": "gzip, deflate",
                //         "Content-Length": "0",
                //         "Connection": "keep-alive",
                //         "cache-control": "no-cache"
                //     },
                //     "data": formData
                // }

                // $.ajax(settings).done(function (response) {
                //     console.log(response);
                // });
                jQuery.support.cors = true;

                $.ajax({
                    type: 'POST',
                    crossDomain: true,
                    url: `https://localhost:44332/importacao/insert?seguradoraId=${this.seguradora}&antecipacao=${this.tipoArquivo}`,
                    data: formData,
                    cache: false,
                    contentType: false,
                    processData: false
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