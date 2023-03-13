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

    </v-app-bar>
            
</template>
<script>

import { getUsuarioLogado, logOff } from '../services/accountService.js'
export default {
    name: 'MenuAppComponent',
   
    data: () => ({
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
    } 
}
</script>