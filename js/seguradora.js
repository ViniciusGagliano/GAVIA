const urlGlobal = `https://localhost:44318/basico/seguradoras`;
const axiosSettings = {
    headers: { 'Content-Type': 'application/x-www-form-urlencoded', "Access-Control-Allow-Origin": true, },
    withCredentials: false,
};

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
        ValidarDados() {
            if (!this.nome || !this.cnpj) {
                Swal.fire('Atenção', `Os campos nome e cnpj são obrigatórios`, 'warning');
                return false;
            }

            (this.id) ? this.Editar() : this.Cadastrar();
        },
        PreencherCampos(id) {
            this.id = id;
            let seguradora = this.arraySeguradora.filter(s => s.Id === id);
            this.nome = seguradora.nome;
            this.cnpj = seguradora.cnpj;
            this.antecipacao = seguradora.antecipacao;
        },
        async Cadastrar() {
            $.LoadingOverlay('show');
            // axios.post(`${urlGlobal}`, `Nome=${this.nome}&CNPJ=${this.cnpj}&Antecipacao=${this.antecipacao}`, axiosSettings).then(_ => {
            //     Swal.fire('Sucesso', 'Cadastro realizado com sucesso', 'success');
            //     this.Carregar();
            // }).catch(error => {
            //     Swal.fire('Erro', 'Algo inesperado ocorreu', 'error');
            //     console.log(error);
            // }).finally(_ => $.LoadingOverlay('hide'));
            await $.ajax({
                type: 'POST',
                crossDomain: true,
                url: `${urlGlobal}`,
                data: {
                    Nome: this.nome,
                    CNPJ: this.cnpj,
                    Antecipacao: this.antecipacao
                }
            }).done(_ => {
                Swal.fire('Sucesso', 'Cadastro realizado com sucesso', 'success');
                this.Carregar();
            }).error(error => {
                Swal.fire('Erro', 'Algo inesperado ocorreu', 'error');
                console.log(error);
            }).always(_ => $.LoadingOverlay('hide'));
        },
        async Editar() {
            $.LoadingOverlay('show');
            await axios.put(`${urlGlobal}/${this.id}`, {
                Nome: this.nome,
                CNPJ: this.cnpj,
                Antecipacao: this.antecipacao
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
                title: 'Deseja excluir essa seguradora?',
                text: `Essa operação não poderá ser desfeita`,
                icon: `warning`,
                showCancelButton: true,
            }).then(result => {
                if (result.value) {
                    $.LoadingOverlay('show');
                    axios.delete(`${urlGlobal}/${id}`, {
                        withCredentials: true
                    }).then(_ => {
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
            axios.get(`${urlGlobal}`, axiosSettings).then(response => {
                if (!response.data) {
                    Swal.fire('Nenhum resultado encontrado', '', 'warning');
                    return false;
                }

                this.arraySeguradora = response.data['ativos'];
            }).catch(error => {
                console.log(error);
            });
            // $.ajax({
            //     type: 'GET',
            //     crossDomain: true,
            //     url: `${urlGlobal}`
            // }).done(response => {
            //     console.log(response);
            // }).error(error => {
            //     console.log(error);
            // });
        },
    },
});