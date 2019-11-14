const acompanhamentoSinistroVue = new Vue({
    el: '#acompanhamentoSinistroVue',
    data() {
        return {
            form: {
                dtInicial: ``,
                dtFinal: ``,
                ddlData: 0,
                txtReferencia: ``,
                ddlCampanha: 0,
                ddlRepresentante: 0,
                ddlSeguradora: 0,
                ddlCobertura: 0,
                txtSegurado: ``,
                txtBeneficiario: ``,
                txtBilhete: ``,
                txtVoucher: ``,
                txtAgencia: ``,
                txtDigitoAgencia: ``,
                txtConta: ``,
                txtDigitoConta: ``,
                txtDolar: ``,
                txtReal: ``,
            }
        }
    },
});