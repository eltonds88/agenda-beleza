<template>
  <v-card class="card-center pa-6">

	<v-card-text class="pa-6">
		<v-container>
			<v-row>
				<v-col cols="12">
					<label class="logo mr-3">AgendaBeleza</label> 
					<h3 class="mt-6">Ops, parece que algo inesperado aconteceu!</h3>
				</v-col>
			</v-row>

			<v-row>
				<v-col cols="12">
					<v-btn @click="goToHome()" class="w-100 btn-azul d-inline-block">VOLTAR</v-btn>
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
		goToHome() {
			this.$router.push('/')
		}
	}
}
</script>
