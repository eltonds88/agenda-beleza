<template>
	<v-container fluid>
		<v-row class="mx-12 my-4">
			<v-col cols="12">
				
				<v-icon>mdi-undo</v-icon>
				<router-link to="/cliente">Voltar</router-link>

			</v-col>

			<detalhes-servicos :isLoading="isLoading" :habilitaEditar="false" :habilitaAdotar="true" :list="this.$route.params.filtro">
			</detalhes-servicos>

		</v-row>
	</v-container>
</template>

<script>
import { trataErro } from '../services/api.js'
import DetalhesServicos from '../components/DetalhesServicos.vue'
import { buscarServicos } from '../services/agendaService.js'

export default {
	name: 'PetsAdoption',
	components: {
		DetalhesServicos
	},

	data: () => ({
		isLoading: false,
		termo: null,
		items: []
	}),

	created() {
		console.log(this.$route.params.filtro)
		if (this.$route.params.filtro) {
			this.termo = this.$route.params.filtro
		}
	},

	mounted() {
		
		if (this.termo != null && this.termo != '') {
			this.pesquisar();
		} else {
			this.pesquisar();
		}
	},

	methods: {
		pesquisar() {
			if (this.isLoading) {
				return
			}
			this.isLoading = true;
			this.items = [];
			buscarServicos(this.termo)
				.then(({ data }) => {
					this.items = data.itens
				})
				.catch(err => {
					trataErro(this, err)
				})
				.finally(() => {
					this.isLoading = false;
				})
		}
	}

}
</script>
