<template>
  <v-card class="card-center pa-6">

	<v-card-text class="pa-6">
		<v-container>
			<v-row>
				<v-col cols="12">
					<label class="logo mr-3">AgendaBeleza</label> login
					<h2 class="mt-6">Bem vindo de volta!</h2>
				</v-col>
			</v-row>
			<v-form ref="form" v-model="valid">
				<v-row>
					<v-col cols="12">
						<v-text-field
						label="Email*"
						required
						v-model="login.email"
						:rules="[
							() => !!login.email || 'Campo obrigatório',
							() => /.+@.+\..+/.test(login.email) || 'E-mail deve ser válido'
						]"
						></v-text-field>
					</v-col>
					<v-col cols="12">
						<v-text-field
						label="Senha*"
						type="password"
						v-model="login.senha"
						required
						:rules="[() => !!login.senha || 'Campo obrigatório']"
						></v-text-field>
					</v-col>
				</v-row>

				<v-row>
					<v-col cols="12">
						<v-btn class="w-100 btn-azul d-inline-block" @click="entrar()">Entrar</v-btn>
					</v-col>
				</v-row>
			</v-form>
			

			<v-row class="mt-4">
				<v-col cols="12" align="right">
					<div class="pt-2"><a @click="goTo()">Me cadastrar como um cliente</a></div>
					<div class="pt-2"><a @click="goTo()">Me cadastrar como um provedor de serviços</a></div>
				</v-col>
			</v-row>
		</v-container>
	</v-card-text>

  </v-card>
</template>

<script>

import { fazerLogin, logOff, registrarTokenUsuario } from '@/services/accountService'
import { trataErro } from '@/services/api'
import { TIPO_CLIENTE } from '@/router'

export default {
	name: 'LoginView',
	components: {},
	data: () => ({
		valid: false,
		login: {
			email:'',
			senha: ''
		}
	}),
	created() {
		logOff()
	},
	methods: {
		entrar() {
			this.$refs.form.validate()
            if(this.valid) {
				fazerLogin(this.login.email, this.login.senha)
				.then(({data}) => {
					registrarTokenUsuario(data);
					if (data.role == TIPO_CLIENTE) {
						this.$router.push({name: 'cliente'})
					} 
				})
				.catch((err) => {
					trataErro(this, err)
				})
			}
		},
		goTo() {
			this.$router.push('cadastrar-cliente')
		}
	}
}
</script>
