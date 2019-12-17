const urlGlobal = `https://localhost:44318/basico/contasbancarias`;

$(document).ready(_ => {
    $('#saldo').mask('999.999.999,99', { reverse: true });
});

const contaBancariaVue = new Vue({
    el: '#contaBancariaVue',
    data() {
        return {
            id: 0,
            nome: '',
            banco: ``,
            agencia: ``,
            digitoAgencia: '',
            conta: '',
            digitoConta: '',
            saldo: 0,
            arrayContaBancaria: []
        }
    },
    beforeCreate() { $.LoadingOverlay('show'); },
    async created() {
        await this.Carregar();
    },
    mounted() { $.LoadingOverlay('hide'); },
    methods: {
        ApenasNumeros(event) {
            if (!/\d/.test(event.key)) { return event.preventDefault(); }
        },
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
            this.banco = ``;
            this.agencia = ``;
            this.digitoAgencia = '';
            this.conta = '';
            this.digitoConta = '';
            this.saldo = 0;
        },
        PreencherCampos(id) {
            this.id = id;
            let contaBancaria = this.arrayContaBancaria.filter(s => s.Id === id)[0];
            this.nome = contaBancaria.Nome;
            this.banco = contaBancaria.Banco;
            this.agencia = contaBancaria.Agencia;
            this.digitoAgencia = contaBancaria.DigitoAgencia;
            this.conta = contaBancaria.Conta;
            this.digitoConta = contaBancaria.DigitoConta;
            this.saldo = contaBancaria.Saldo;
        },
        async Cadastrar() {
            $.LoadingOverlay('show');
            let Saldo = this.saldo.split('.').join('').split(',').join('.');

            await axios.post(urlGlobal, {
                Nome: this.nome,
                Banco: this.banco,
                Agencia: this.agencia,
                DigitoAgencia: this.digitoAgencia,
                Conta: this.conta,
                DigitoConta: this.digitoConta,
                Saldo
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
            let Saldo = this.saldo.split('.').join('').split(',').join('.');

            await axios.put(`${urlGlobal}/${this.id}`, {
                Nome: this.nome,
                Banco: this.banco,
                Agencia: this.agencia,
                DigitoAgencia: this.digitoAgencia,
                Conta: this.conta,
                DigitoConta: this.digitoConta,
                Saldo
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
                title: 'Deseja excluir essa conta bancárias?',
                text: `Essa operação não poderá ser desfeita`,
                icon: `warning`,
                showCancelButton: true,
                cancelButtonColor: '#d33',
            }).then(result => {
                if (result.value) {
                    $.LoadingOverlay('show');
                    axios.delete(`${urlGlobal}/${id}`).then(_ => {
                        Swal.fire('Sucesso', 'Conta bancária excluído com sucesso', 'success');
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
            await axios.get(`${urlGlobal}`).then(response => {
                this.arrayContaBancaria = response.data['ativos'];
            }).catch(error => {
                console.log(error);
            });
        },
    },
});