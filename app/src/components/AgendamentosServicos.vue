<template>
    <v-container fluid>

        <v-row class="" dense>
            <v-col lg="12"  v-for="item in list" :key="item.id">
                <v-card class="mx-auto mb-8" outlined>
                    <v-list-item three-line>
                        <v-list-item-content>
                            <div class="text-h5 mb-1">
                                {{item.nomeServico}}
                                <v-chip
                                    class="ma-2"
                                    color="green"
                                    text-color="white"
                                    >
                                    {{item.status}}
                                </v-chip>
                            </div>
                            <v-list-item-subtitle>{{item.classificacao}}</v-list-item-subtitle>
                            
                            <v-list-item-subtitle>{{item.descricao}}</v-list-item-subtitle>
                            <v-list-item-subtitle>{{item.telefone}}</v-list-item-subtitle>
                            
                        </v-list-item-content>

                        
                    </v-list-item>

                    <v-card-actions>
                        <v-btn v-if="habilitaEditar" color="red lighten-2" text
                            @click="$router.push({name: 'petEdit', params: { id: item.id }})">
                            EDITAR
                        </v-btn>
                        <v-spacer></v-spacer>
                        
                    </v-card-actions>
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
        // list: {
        //     type: Array
        // },
        isLoading: {
            type: Boolean,
            default: true
        }
    },
    data: () => ({
        list: [
            {
                nomeServico: 'Barbeiro 1',
                classificacao: 4,
                descricao: 'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Morbi sollicitudin gravida arcu, id dignissim lectus dignissim sed. ',
                telefone: '(21) 98902-9854',
                status: 'Pendente'
            },
            {
                nomeServico: 'Barbeiro 2',
                classificacao: 2,
                descricao: 'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Morbi sollicitudin gravida arcu, id dignissim lectus dignissim sed. ',
                telefone: '(21) 98902-9854',
                status: 'Pendente'
            },
            {
                nomeServico: 'Barbeiro 3',
                classificacao: 3,
                descricao: 'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Morbi sollicitudin gravida arcu, id dignissim lectus dignissim sed. ',
                telefone: '(21) 98902-9854',
                status: 'Pendente'
            },
            {
                nomeServico: 'Barbeiro 4',
                classificacao: 5,
                descricao: 'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Morbi sollicitudin gravida arcu, id dignissim lectus dignissim sed. ',
                telefone: '(21) 98902-9854',
                status: 'Pendente'
            }
        ]
        
    }),
    methods: {
        
    }
}
</script>
  