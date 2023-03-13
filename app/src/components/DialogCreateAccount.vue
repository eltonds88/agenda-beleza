<template>
    <v-dialog
        v-model="open"
        persistent
        max-width="600px"
    >
        <v-card>
            <v-card-title>
                <div class="text-center">
                    <img src="@/assets/agendabeleza.png" />
                    cadastro
                </div>
                
                <v-col cols="12" class="text-h5 text-center">
                    <p class="text-h5 text-center">
                        Configure seu perfil 
                    </p>
                </v-col>
            </v-card-title>

            <v-card-text>
            <v-container>

                <div v-if="step === 1">
                    <v-row>
                        <v-form ref="form" v-model="valid">
                        <v-container>
                            <v-row>
                                <v-col cols="12">
                                    <v-text-field
                                    v-model="model.nome"
                                    :rules="[
                                        () => !!model.nome || 'Campo obrigatório'
                                    ]"
                                    :error-messages="errorMessages"
                                    label="Nome*"
                                    required
                                    ></v-text-field>
                                </v-col>
                                <v-col
                                    cols="12"
                                >
                                    <v-text-field
                                    v-model="model.sobrenome"
                                    label="Sobrenome"
                                    required
                                    ></v-text-field>
                                </v-col>
                                
                                <v-col
                                    cols="12"
                                >
                                    <v-text-field
                                    v-model="model.datanascimento"
                                    label="Data Nascimento"
                                    required
                                    ></v-text-field>
                                </v-col>
                                
                                <v-col
                                    cols="12"
                                >
                                    <v-text-field
                                    v-model="model.telefone"
                                    label="Telefone"
                                    required
                                    ></v-text-field>
                                </v-col>
                                

                            </v-row>
                        </v-container>
                    </v-form>
                    <small>*campos obrigatórios</small>
                    </v-row>
                </div>
                <div v-if="step === 2">
                    <v-row>
                        <v-form ref="form" v-model="valid">
                            <v-container>
                                <v-row>
                                    <v-col cols="8">
                                        <v-text-field
                                        v-model="model.endereco"
                                        :rules="[
                                            () => !!model.endereco || 'Campo obrigatório'
                                        ]"
                                        :error-messages="errorMessages"
                                        label="Endereço completo*"
                                        required
                                        ></v-text-field>
                                    </v-col>
                                    <v-col cols="4">
                                        <v-text-field
                                        v-model="model.numero"
                                        :rules="[
                                            () => !!model.numero || 'Campo obrigatório'
                                        ]"
                                        :error-messages="errorMessages"
                                        label="Número*"
                                        required
                                        ></v-text-field>
                                    </v-col>
                                    <v-col
                                        cols="12"
                                    >
                                        <v-text-field
                                        v-model="model.complemento"
                                        label="Complemento"
                                        ></v-text-field>
                                    </v-col>
                                    <v-col cols="5">
                                        <v-text-field
                                        v-model="model.cidade"
                                        :rules="[
                                            () => !!model.cidade || 'Campo obrigatório',
                                        ]"
                                        :error-messages="errorMessages"
                                        label="Cidade*"
                                        required
                                        ></v-text-field>
                                    </v-col>
                                    <v-col cols="5">
                                        <v-text-field
                                        v-model="model.bairro"
                                        :rules="[
                                            () => !!model.bairro || 'Campo obrigatório',
                                        ]"
                                        :error-messages="errorMessages"
                                        label="Bairro*"
                                        required
                                        ></v-text-field>
                                    </v-col>
                                    <v-col cols="2">
                                        <v-text-field
                                        v-model="model.uf"
                                        :rules="[
                                            () => !!model.uf || 'Campo obrigatório'
                                        ]"
                                        :error-messages="errorMessages"
                                        label="UF*"
                                        required
                                        ></v-text-field>
                                    </v-col>

                                </v-row>
                            </v-container>
                        </v-form>
                        <small>*campos obrigatórios</small>
                    </v-row>
                </div>
                <div v-if="step === 3">
                    <v-row>
                        <v-form ref="form" v-model="valid">
                            <v-container>
                                <v-row>
                                    <v-col cols="12">
                                        <v-text-field
                                        v-model="model.email"
                                        :rules="[
                                            () => !!model.email || 'Campo obrigatório',
                                            () => /.+@.+\..+/.test(model.email) || 'E-mail deve ser válido'
                                        ]"
                                        :error-messages="errorMessages"
                                        label="Email*"
                                        required
                                        ></v-text-field>
                                    </v-col>                                    
                                    
                                    <v-col cols="12">
                                        <v-text-field
                                        v-model="model.senha"
                                        :rules="[() => !!model.senha || 'Campo obrigatório']"
                                        label="Senha*"
                                        type="password"
                                        required
                                        ></v-text-field>
                                    </v-col>
                                    <v-col cols="12">
                                        <v-text-field
                                        v-model="model.confirmarSenha"
                                        :rules="[
                                            () => !!model.confirmarSenha || 'Campo obrigatório',
                                            () => checkPassword() || 'A confirmação da senha deve ser igual à senha'
                                        ]"
                                        label="Confirmação de Senha*"
                                        type="password"
                                        required
                                        ></v-text-field>
                                    </v-col>

                                </v-row>
                            </v-container>
                        </v-form>
                        <small>*campos obrigatórios</small>
                    </v-row>
                </div>
            </v-container>
            
            </v-card-text>

            <v-card-actions>
                <v-spacer></v-spacer>
                
                <v-btn
                    color="blue darken-1"
                    text
                    @click="close()"
                >
                    Fechar
                </v-btn>
                <v-btn
                    v-if="step === 1 || step === 2"
                    color="blue darken-1"
                    text
                    @click="cadastrar()"
                >
                    Continuar
                </v-btn>
                <v-btn
                    v-if="step === 3"
                    color="blue darken-1"
                    text
                    @click="cadastrar()"
                >
                    Cadastrar
                </v-btn>
            </v-card-actions>
        </v-card>
    </v-dialog>
            
</template>
<script>
// import { trataErro } from '../services/api.js'
// import { criarContaTutor, criarContaRepresentante, registrarTokenUsuario } from '../services/accountService.js'
export default {
    name: 'DialogCreateAccount',
    props: {
        openDialogRegister: {
            type: Boolean,
            default: false
        }
    },
    components: { 
    },
    data() {
        return {
            step: 1,
            errorMessages: [],
            tipo: '',
            valid: false,
            model: {
                email: '',
                nome: '',
                sobrenome: '',
                celular: '',
                senha: '',
                confirmarSenha: ''
            }
        };
    },
    computed: {
        open: {
            get() {
                return this.openDialogRegister
            }
        }
    },
    methods: {
        close() {
            this.tipo = '';
            this.$emit('close');
        },
        checkPassword() {
            if (this.model.senha != '' && this.model.confirmarSenha != '') {
                return this.model.senha === this.model.confirmarSenha;
            }
            return true;
        },
        cadastrar() {
            this.$refs.form.validate()
            if(this.valid) {
                this.step += 1
                // let criar = this.tipo == 'T' ? criarContaTutor : criarContaRepresentante;
                // criar(this.model).then(({data}) => {
                //     registrarTokenUsuario(data)
                //     this.$toasted.success('Usuário criado com sucesso')
                //     this.$root.$emit('loggedOn', data);
                //     this.$emit('close');
                //     this.model.email = '';
                //     this.model.nome = '';
                //     this.model.sobrenome = '';
                //     this.model.celular = '';
                //     this.model.senha = '';
                //     this.model.confirmarSenha = '';
                //     this.tipo == ''
                // }).catch(error => {
                //     trataErro(this, error)
                // })
            }
        }
    }
}
</script>