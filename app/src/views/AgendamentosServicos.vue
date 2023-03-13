<template>
	<v-container fluid>
		<v-row class="mx-12 my-4">
			<v-col cols="12">
				<router-link to="/">Voltar</router-link>

			</v-col>

			<lista-agendamentos :isLoading="isLoading"  :list="items">
			</lista-agendamentos>

		</v-row>
	</v-container>
</template>

<script>
import { trataErro } from '../services/api.js'
import ListaAgendamentos from '../components/AgendamentosServicos.vue'
import { buscarServicos } from '../services/agendaService.js'

export default {
	name: 'AgendamentosServicos',
	components: {
		ListaAgendamentos
	},

	data: () => ({
		isLoading: false,
		termo: null,
		items: []
	}),

	created() {
		if (this.$route.params.filtro) {
			this.termo = this.$route.params.filtro
		}
	},

	mounted() {
		if (this.termo != null && this.termo != '') {
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
					this.items = data
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
