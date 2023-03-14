<template>
    <v-container>
    <v-row class="text-center">
		<v-col cols="12">
			<h1 class="text-center font-weight-medium my-10 text-prymary" color="primary">Descubra profissionais perto de você</h1>
			<div class="d-flex">
				<v-text-field
					filled
					label="Buscar serviços"
					prepend-inner-icon="mdi-magnify"
					v-model="termo"
					@keyup.enter="pesquisar"
				></v-text-field>
				<v-btn class="d-flex ml-2 btn-azul mt-3" @click="pesquisar()">Pesquisar</v-btn>
			</div>
			
			
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
			<div class="mapouter"><div class="gmap_canvas"><iframe width="100%" height="510" id="gmap_canvas" src="https://maps.google.com/maps?q=brasil&t=&z=10&ie=UTF8&iwloc=&output=embed" frameborder="0" scrolling="no" marginheight="0" marginwidth="0"></iframe><a href="https://2yu.co">2yu</a><br></div></div>
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
