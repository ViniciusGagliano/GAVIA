const urlGlobal = `https://localhost:44318/basico`;
const axiosSettings = {
    headers: { 'Content-Type': 'application/x-www-form-urlencoded', "Access-Control-Allow-Origin": true, },
    withCredentials: false,
};

const importacaoVue = new Vue({
    el: '#importacaoVue',
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

            this.arquivo = file[0];
            await this.ImportarArquivo();
        },
        async ImportarArquivo() {
            $.LoadingOverlay('show');
            var formData = new FormData();
            formData.append(this.arquivo.name, this.arquivo);

            await axios.post(`${urlGlobal}/arquivos?seguradoraId=${this.seguradora}&antecipacao=false`, formData, axiosSettings).then(_ => {
                this.arquivo = null;
                $('#arqSeguradora').val('');
                Swal.fire('Sucesso', `Importação concluída`, 'success');
            }).catch(error => {
                console.log(error);
                swal.fire('Erro', `Importação falhou`, 'error');
            }).always(_ => $.LoadingOverlay('hide'));
        }
    },
});