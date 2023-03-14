<template>
    <v-container fluid>

        <v-row class="" dense>
            <v-col lg="12" >
                <v-card class="mx-auto mb-8 px-2 py-2" outlined>
                    <div>
                        <div>
                            <h2 class="mb-1">
                                {{item.nome}}
                            </h2>
                            <v-rating
                                v-model="item.classificacao"
                                hover
                                bg-color="orange-lighten-1"
                                color="orange"
                                half-increments
                                size="small"
                                >
                            </v-rating>
                            <div class="d-flex align-center">
                                <v-autocomplete
                                    v-model="value"
                                    :items="items"
                                    dense
                                    filled
                                    label="Selecione o serviço"
                                ></v-autocomplete>
                            </div>
                        </div>
                        <div class="">
                            <v-col
                                cols="12"
                                lg="6"
                            >
                                <v-menu
                                ref="menu1"
                                v-model="menu1"
                                :close-on-content-click="false"
                                transition="scale-transition"
                                offset-y
                                max-width="290px"
                                min-width="auto"
                                >
                                <template v-slot:activator="{ on, attrs }">
                                    <v-text-field
                                    v-model="dateFormatted"
                                    label="Date"
                                    persistent-hint
                                    prepend-icon="mdi-calendar"
                                    v-bind="attrs"
                                    @blur="date = parseDate(dateFormatted)"
                                    v-on="on"
                                    ></v-text-field>
                                </template>
                                <v-date-picker
                                    v-model="date"
                                    no-title
                                    @input="menu1 = false"
                                ></v-date-picker>
                                </v-menu>
                            </v-col>
                        </div>
                        <div class="mb-4">
                            <v-btn
                                class="ma-2"
                                outlined
                                color="indigo"
                                >
                                08:00
                            </v-btn>
                            <v-btn
                                class="ma-2"
                                outlined
                                color="indigo"
                                >
                                10:00
                            </v-btn>
                            <v-btn
                                class="ma-2"
                                outlined
                                color="indigo"
                                >
                                12:00
                            </v-btn>
                            <v-btn
                                class="ma-2"
                                outlined
                                color="indigo"
                                >
                                14:00
                            </v-btn>
                            <v-btn
                                class="ma-2"
                                outlined
                                color="indigo"
                                >
                                16:00
                            </v-btn>
                            <v-btn
                                class="ma-2"
                                outlined
                                color="indigo"
                                >
                                18:00
                            </v-btn>


                        </div>
                        <div class="d-flex align-center">
                            <v-btn class="d-inline-block mr-2" @click="detalhes()">Cancelar</v-btn>
                            <v-btn class="btn-azul d-inline-block" @click="detalhes()">Agendar</v-btn>
                        </div>
                    </div>
                </v-card>
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
            type: Object
        },
        isLoading: {
            type: Boolean,
            default: true
        }
    },
    data: () => ({
        item: null,
        items: ['Barbeiro', 'Salão', 'Manicure'],
		value: ['Barbeiro', 'Salão', 'Manicure'],
        dateFormatted: 'Hoje'
        
    }),
    created() {
        this.item = this.list
    },
    methods: {
        detalhes () {
            this.$router.push({name: 'DetalhesServicos', params: { filtro: this.termo }})
        }
    }
}
</script>
  