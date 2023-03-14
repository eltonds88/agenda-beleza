<template>
    <v-container fluid>

        <v-row class="" dense>
            <v-col lg="12"  v-for="item in list" :key="item.id">
                <v-card class="mx-auto mb-8 px-2 py-2" outlined>
                    <div class="d-flex flex-row justify-space-between">
                        <div style="width: 30%;">
                            <div class="text-h5 mb-1">
                                {{item.nome}}
                            </div>
                            <v-rating
                                v-model="item.classificacao"
                                hover
                                bg-color="orange-lighten-1"
                                color="orange"
                                half-increments
                                size="small"
                                >
                            </v-rating>
                            <div>
                                {{item.endereco}}
                            </div>
                            <div>
                                {{item.telefone}}
                            </div>
                        </div>
                        <div class="d-flex align-center" style="width: 50%;">
                            {{item.descricao}}
                        </div>
                        <div class="d-flex align-center">
                            <v-btn class="w-100 grey-darken-3 d-inline-block" @click="detalhes(item)">Detalhes</v-btn>
                        </div>
                    </div>
                </v-card>
            </v-col>

            <v-col v-if="isLoading" lg="12" xs="12">
                <h5>Carregando informações...</h5>
            </v-col>

            <v-col v-if="!isLoading && list.length == 0" lg="12" xs="12">
                <h5>Nenhum pet para listar</h5>
            </v-col>
        </v-row>
    </v-container>
</template>
  
<script>
export default {
    name: 'ListaAnimaisComponent',
    components: {},
    props: {
        list: {
            type: Array
        },
        isLoading: {
            type: Boolean,
            default: true
        }
    },
    data: () => ({
        item: null
        
    }),
    methods: {
        detalhes (item) {
            this.item = item
            this.$router.push({name: 'DetalhesServicos', params: { filtro: item }})
        }
    }
}
</script>
  