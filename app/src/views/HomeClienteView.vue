<template>
    <v-container>
    <v-row class="text-center">
		<v-col cols="12">
			<h1 class="text-center font-weight-medium my-10 text-prymary" color="primary">Descubra profissionais perto de você</h1>
			<v-text-field
				filled
				label="Buscar serviços"
				prepend-inner-icon="mdi-magnify"
				v-model="termo"
				@keyup.enter="pesquisar"
			></v-text-field>
		</v-col>		
    </v-row>
    <v-row dense>
		<v-col cols="12">
			<v-select
				v-model="value"
				:items="items"
				chips

				multiple
			></v-select>
		</v-col>
		
    </v-row>
	<v-row>
		<v-col cols="12">
			MAPS
		</v-col>
	</v-row>
  </v-container>
</template>

<script>
// import { getUsuarioLogado } from '../services/accountService.js'
export default {
	name: 'HomeView',
	components: {},
	data: () => ({
		termo: '',
		items: ['Barbeiro', 'Salão', 'Manicure'],
		value: ['Barbeiro', 'Salão', 'Manicure']
	}),
	created() {
		// var user = getUsuarioLogado();
		// if (user != null && user.role == 'INSTITUICAO') {
		// 	this.$router.push({path: '/pets-instituicao'})
		// }
	},
	methods: {
		pesquisar() {
			this.$router.push({name: 'ListaServicos', params: { filtro: this.termo }})
		}
	}
}
</script>
