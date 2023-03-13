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
			<v-row>
				<v-col cols="12">
					<v-text-field
					label="Email*"
					required
					v-model="login.email"
					></v-text-field>
				</v-col>
				<v-col cols="12">
					<v-text-field
					label="Senha*"
					type="password"
					v-model="login.senha"
					required
					></v-text-field>
				</v-col>
			</v-row>

			<v-row>
				<v-col cols="12">
					<v-btn class="w-100 btn-azul d-inline-block">Entrar</v-btn>
				</v-col>
			</v-row>

			<v-row class="mt-4">
				<v-col cols="12" align="right">
					<div class="pt-2"><a href="#">Me cadastrar como um cliente</a></div>
					<div class="pt-2"><a href="#">Me cadastrar como um provedor de serviços</a></div>
				</v-col>
			</v-row>
		</v-container>
	</v-card-text>

  </v-card>
</template>

<script>

export default {
	name: 'LoginView',
	components: {},
	data: () => ({
		login: {
			email:'',
			senha: ''
		}
	}),
	created() {
	},
	methods: {
	}
}
</script>
