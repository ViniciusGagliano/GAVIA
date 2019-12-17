const urlGlobal = `https://localhost:44318/basico/fornecedores`;

$(document).ready(_ => {
    $('#cnpj').mask('00.000.000/0000-00', { reverse: true });
});
const fornecedorVue = new Vue({
    el: '#fornecedorVue',
    data() {
        return {
            id: 0,
            nome: '',
            cnpj: '',
            arrayFornecedor: []
        }
    },
    beforeCreate() { $.LoadingOverlay('show'); },
    async created() {
        await this.Carregar();
    },
    mounted() { $.LoadingOverlay('hide'); },
    methods: {
        ValidarDados() {
            if (!this.nome) {
                Swal.fire('Atenção', `O campo nome é obrigatório`, 'warning');
                return false;
            }

            (this.id) ? this.Editar() : this.Cadastrar();
        },
        LimparCampos() {
            this.id = 0;
            this.nome = '';
            this.cnpj = '';
        },
        PreencherCampos(id) {
            this.id = id;
            let fornecedor = this.arrayFornecedor.filter(s => s.Id === id)[0];
            this.nome = fornecedor.Nome;
            this.cnpj = fornecedor.CNPJ;
        },
        async Cadastrar() {
            $.LoadingOverlay('show');
            let CNPJ = this.cnpj.split('.').join('').split('/').join('').split('-').join('');

            await axios.post(urlGlobal, {
                Nome: this.nome,
                CNPJ
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
                CNPJ
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
                title: 'Deseja excluir esse fornecedor?',
                text: `Essa operação não poderá ser desfeita`,
                icon: `warning`,
                showCancelButton: true,
                cancelButtonColor: '#d33',
            }).then(result => {
                if (result.value) {
                    $.LoadingOverlay('show');

                    axios.delete(`${urlGlobal}/${id}`).then(_ => {
                        Swal.fire('Sucesso', 'Fornecedor excluído com sucesso', 'success');
                        this.Carregar();
                    }).catch(error => {
                        Swal.fire('Erro', 'Algo inesperado ocorreu', 'error');
                        console.log(error);
                    }).finally(_ => { $.LoadingOverlay('hide') });
                }
            })
        },
        async Carregar() {
            await axios.get(`${urlGlobal}`).then(response => {
                this.arrayFornecedor = response.data['ativos'];
            }).catch(error => {
                console.log(error);
            });
        },
    },
});