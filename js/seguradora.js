const urlGlobal = `https://localhost:44318/basico/seguradoras`;

$(document).ready(() => {
    $('#cnpj').mask('00.000.000/0000-00', { reverse: true });
})

const seguradoraVue = new Vue({
    el: '#seguradoraVue',
    data() {
        return {
            id: 0,
            nome: '',
            cnpj: '',
            antecipacao: false,
            arraySeguradora: []
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
            if (!this.nome || !this.cnpj) {
                Swal.fire('Atenção', `Os campos nome e cnpj são obrigatórios`, 'warning');
                return false;
            }

            (this.id) ? this.Editar() : this.Cadastrar();
        },
        LimparCampos() {
            this.id = 0;
            this.nome = '';
            this.cnpj = '';
            this.antecipacao = false;
        },
        PreencherCampos(id) {
            this.id = id;
            let seguradora = this.arraySeguradora.filter(s => s.Id === id)[0];
            this.nome = seguradora.Nome;
            this.cnpj = seguradora.CNPJ;
            this.antecipacao = seguradora.Antecipacao;
        },
        async Cadastrar() {
            $.LoadingOverlay('show');
            let CNPJ = this.cnpj.split('.').join('').split('/').join('').split('-').join('');

            axios.post(`${urlGlobal}`, {
                Nome: this.nome,
                CNPJ,
                Antecipacao: this.antecipacao
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
            let CNPJ = this.cnpj.split('.').join('').split('/').join('').split('-').join('');

            await axios.put(`${urlGlobal}/${this.id}`, {
                Nome: this.nome,
                CNPJ,
                Antecipacao: this.antecipacao
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
                title: 'Deseja excluir essa seguradora?',
                text: `Essa operação não poderá ser desfeita`,
                icon: `warning`,
                showCancelButton: true,
                cancelButtonColor: '#d33',
            }).then(result => {
                if (result.value) {
                    $.LoadingOverlay('show');
                    axios.delete(`${urlGlobal}/${id}`).then(_ => {
                        Swal.fire('Sucesso', 'Seguradora excluída com sucesso', 'success');
                        this.Carregar();
                    }).catch(error => {
                        Swal.fire('Erro', 'Algo inesperado ocorreu', 'error');
                        console.log(error);
                    }).finally(_ => { $.LoadingOverlay('hide') });
                }
            })
        },
        Carregar() {
            axios.get(`${urlGlobal}`).then(response => {
                if (!response.data) {
                    Swal.fire('Nenhum resultado encontrado', '', 'warning');
                    return false;
                }
                console.log(response.data);

                this.arraySeguradora = response.data['ativos'];
            }).catch(error => {
                console.log(error);
            });
        },
    },
});