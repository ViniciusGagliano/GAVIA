const urlGlobal = `https://localhost:44318/basico/centroscustos`;
const axiosSettings = {
    headers: { 'Content-Type': 'application/x-www-form-urlencoded', "Access-Control-Allow-Origin": true, },
    withCredentials: false,
};

const centroCustoVue = new Vue({
    el: '#centroCustoVue',
    data() {
        return {
            id: 0,
            nome: '',
            arrayCentroCusto: []
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
        PreencherCampos(id) {
            this.id = id;
            let centroCusto = this.arrayCentroCusto.filter(s => s.Id === id);
            this.nome = centroCusto.Nome;
        },
        async Cadastrar() {
            $.LoadingOverlay('show');

            axios.post(`${urlGlobal}`, `Nome=${this.nome}`, axiosSettings).then(_ => {
                Swal.fire('Sucesso', 'Cadastro realizado com sucesso', 'success');
                this.Carregar();
            }).catch(error => {
                Swal.fire('Erro', 'Algo inesperado ocorreu', 'error');
                console.log(error);
            }).finally(_ => $.LoadingOverlay('hide'));

            // await $.ajax({
            //     type: 'POST',
            //     crossDomain: true,
            //     url: `${urlGlobal}`,
            //     data: {
            //         Nome: this.nome
            //     }
            // }).done(_ => {
            //     Swal.fire('Sucesso', 'Cadastro realizado com sucesso', 'success');
            //     this.Carregar();
            // }).error(error => {
            //     Swal.fire('Erro', 'Algo inesperado ocorreu', 'error');
            //     console.log(error);
            // }).always(_ => $.LoadingOverlay('hide'));
        },
        async Editar() {
            $.LoadingOverlay('show');
            await axios.put(`${urlGlobal}/${this.id}`, {
                Nome: this.nome
            }, axiosSettings).then(_ => {
                Swal.fire('Sucesso', 'Dados alterado com sucesso', 'success');
                this.Carregar();
            }).catch(error => {
                Swal.fire('Erro', 'Algo inesperado ocorreu', 'error');
                console.log(error);
            }).finally(_ => { $.LoadingOverlay('hide') });
        },
        async Excluir(id) {
            Swal.fire({
                title: 'Deseja excluir esse centro de custo?',
                text: `Essa operação não poderá ser desfeita`,
                icon: `warning`,
                showCancelButton: true,
            }).then(result => {
                if (result.value) {
                    $.LoadingOverlay('show');
                    axios.delete(`${urlGlobal}/${id}`, {
                        withCredentials: true
                    }).then(_ => {
                        Swal.fire('Sucesso', 'Centro de custo excluído com sucesso', 'success');
                        this.Carregar();
                    }).catch(error => {
                        Swal.fire('Erro', 'Algo inesperado ocorreu', 'error');
                        console.log(error);
                    }).finally(_ => { $.LoadingOverlay('hide') });
                }
            })
        },
        Carregar() {
            axios.get(`${urlGlobal}`, axiosSettings).then(response => {
                if (!response.data) {
                    Swal.fire('Nenhum resultado encontrado', '', 'warning');
                    return false;
                }

                this.arrayCentroCusto = response.data['ativos'];
            }).catch(error => {
                console.log(error);
            });
        },
    },
});