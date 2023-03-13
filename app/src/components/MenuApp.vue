<template>
    <v-app-bar
    app
    color="white"
    > 
        <v-row>
            <v-col 
                lg="2"
                xs="1"
            >          
            </v-col>
            <v-col cols="8">

            </v-col>
            <v-col cols="2" class="d-inline-flex">
                <v-btn
                    v-if="!isLogged"
                    class="ma-1"
                    color="grey"
                    plain
                    @click="openDialogRegister = true"
                >
                    Criar Conta
                </v-btn>
                <v-btn
                    v-if="!isLogged"
                    class="ma-1"
                    color="grey"
                    plain
                    @click="openDialogLogIn = true"
                >
                    Entrar
                </v-btn>
                <v-btn
                    v-if="isLogged"
                    class="ma-1"
                    color="grey"
                    plain
                    @click="sair()"
                >
                    Sair
                </v-btn>
            </v-col>
        </v-row>

        <dialog-entrar :openDialogLogIn="openDialogLogIn" @close="() => { openDialogLogIn = false}"></dialog-entrar>
        <dialog-create-account :openDialogRegister="openDialogRegister" @close="() => { openDialogRegister = false}"></dialog-create-account>

    </v-app-bar>
            
</template>
<script>
import DialogEntrar from './DialogEntrar.vue'
import DialogCreateAccount from './DialogCreateAccount.vue';
import { getUsuarioLogado, logOff } from '../services/accountService.js'
export default {
    name: 'MenuAppComponent',
    components: { 
        DialogEntrar,
        DialogCreateAccount
    },
    data: () => ({
        openDialogRegister: false,
        openDialogLogIn: false,
        isLogged: false,
        isPerfilPreenchido: true,
        nome: '',
        role: ''
    }),
    created() {
        var user = getUsuarioLogado();
        if (user != null) {
            this.setUserLogged(user)
        }
    },
    mounted() {
        this.$root.$on('loggedOn', (user) => {
            this.setUserLogged(user)
        })
        this.$root.$on('perfilCompleto', () => {
            this.isPerfilPreenchido = true;
        })
    },
    methods: {
        setUserLogged(data) {
            this.isLogged = true;
            this.nome = data.nome;
            this.role = data.role;
            this.isPerfilPreenchido = data.cadastroCompleto;
        },
        sair() {
            logOff();
            this.isLogged = false;
            this.nome = '';
            this.role = '';
            this.isPerfilPreenchido = true;
            if (this.$route.name != 'home') {
                this.$router.push({name: 'home'})
            }
            this.$toasted.success('Log out realizado com sucesso');
        }
    },
    destroyed() {
        this.$root.$off('loggedOn');
        this.$root.$off('perfilCompleto');
    } 
}
</script>