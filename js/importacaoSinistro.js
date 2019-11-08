const importacaoSinistroVue = new Vue({
    el: '#importacaoSinistroVue',
    data: {
        seguradora: 0,
        tipoArquivo: 1,
        arrayImportacao: []
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
        ValidarCampos() {
            if (!parseInt(this.seguradora)) {
                swal.fire('Atenção', `O campo seguradora deve ser preenchido`, 'warning');
                return false;
            }
            console.log($('#arqSeguradora').val());

            this.ImportarArquivo();
        },
        CarregarImportacao() { },
        ImportarArquivo() { }
    },
});