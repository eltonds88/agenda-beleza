<template>
    <v-card class="card-center pa-6">
  
      <v-card-text class="pa-6">
          <v-container>
            <v-form ref="form" v-model="valid">
                <v-row>
                  <v-col cols="12">
                      <label class="logo mr-3">AgendaBeleza</label> cadastrar
                      <h2 class="mt-6">Configure seu perfil de cliente</h2>
                  </v-col>
                </v-row>
                <div v-if="step === 1">                
                    <v-row>
                        <v-col cols="6">
                            <v-text-field
                            v-model="model.nome"
                            :rules="[
                                () => !!model.nome || 'Campo obrigatório'
                            ]"
                            :error-messages="errorMessages"
                            label="Nome*"
                            required
                            outlined
                            ></v-text-field>
                        </v-col>
                        <v-col
                            cols="6"
                        >
                            <v-text-field
                            v-model="model.cpfCnpj"
                            label="CPF/CNPJ"
                            required
                            outlined
                            ></v-text-field>
                        </v-col>
                        <v-col
                            cols="6"
                        >
                            <v-text-field
                            v-model="model.dtNascimento"
                            label="Data Nascimento"
                            type="date"
                            required
                            outlined
                            ></v-text-field>
                        </v-col>
                        
                        <v-col
                            cols="6"
                        >
                            <v-select
                                v-model="model.sexo"
                                label="Sexo"
                                :items="['Masculino', 'Feminino', 'Não informar']"
                                outlined
                            ></v-select>

                        </v-col>

                        <v-col
                            cols="6"
                        >
                            <v-text-field
                            v-model="model.telefone"
                            label="Telefone"
                            required
                            outlined
                            ></v-text-field>
                        </v-col>
                        

                    </v-row>
                </div>
              
                <div v-if="step === 2">
                    <v-row>
                        <v-form ref="form" v-model="valid">
                            <v-container>
                                <v-row>
                                    <v-col cols="8">
                                        <v-text-field
                                        v-model="model.logradouro"
                                        :rules="[
                                            () => !!model.logradouro || 'Campo obrigatório'
                                        ]"
                                        :error-messages="errorMessages"
                                        label="Endereço completo*"
                                        required
                                        outlined
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
                                        outlined
                                        ></v-text-field>
                                    </v-col>
                                    <v-col
                                        cols="6"
                                    >
                                        <v-text-field
                                        v-model="model.complemento"
                                        label="Complemento"
                                        outlined
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
                                        outlined
                                        ></v-text-field>
                                    </v-col>
                                    <v-col
                                        cols="6"
                                    >
                                        <v-text-field
                                        v-model="model.cep"
                                        :rules="[
                                            () => !!model.cep || 'Campo obrigatório',
                                        ]"
                                        label="CEP"
                                        outlined
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
                                        outlined
                                        ></v-text-field>
                                    </v-col>
                                    <v-col cols="2">
                                        <v-combobox
                                            v-model="model.uf"
                                            :rules="[
                                                () => !!model.uf || 'Campo obrigatório'
                                            ]"
                                            :error-messages="errorMessages"
                                            label="UF*"
                                            required
                                            :items="estados"
                                            :return-object="false"
                                            outlined
                                        ></v-combobox>
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
                                        outlined
                                        ></v-text-field>
                                    </v-col>                                    
                                    
                                    <v-col cols="12">
                                        <v-text-field
                                        v-model="model.senha"
                                        :rules="[() => !!model.senha || 'Campo obrigatório']"
                                        label="Senha*"
                                        type="password"
                                        required
                                        outlined
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
                                        outlined
                                        ></v-text-field>
                                    </v-col>

                                </v-row>
                            </v-container>
                        </v-form>
                        <small>*campos obrigatórios</small>
                    </v-row>
                </div>
  
                <v-row>
                    <v-col cols="12">
                        <v-btn class="w-100 btn-azul d-inline-block" 
                            color="white darken-1"
                            text
                            @click="cadastrar()"
                        >{{this.textBtnCTACadastro}}</v-btn>
                    </v-col>
                </v-row>
            </v-form>
            
          </v-container>
      </v-card-text>
  
    </v-card>
  </template>
  
  <script>
  import { trataErro } from '../services/api.js'
  import { criarContaCliente, logOff, registrarTokenUsuario } from '../services/accountService.js'
  import { estadosOptions } from '../services/listasService.js'
  export default {
    
      name: 'CadastroView',
      components: {},
      data: () => ({
        estados: estadosOptions,
        step: 1,
        errorMessages: [],
        tipo: '',
        valid: false,
        model: {
            logradouro: '',
            numero: '',
            complemento: '',
            bairro: '',
            cidade: '',
            uf: '',
            cep: '',
            nome: '',
            email: '',
            senha: '',
            telefone: '',
            cpfCnpj: null,
            sexo: null,
            dtNascimento: null,
            confirmarSenha: ''
        }
      }),
      computed: {
        textBtnCTACadastro () {
            return this.step === 3 ? 'Cadastrar' : 'Continuar'
        }
      },
      created() {
        logOff();
      },
      methods: {
        checkPassword() {
            if (this.model.senha != '' && this.model.confirmarSenha != '') {
                return this.model.senha === this.model.confirmarSenha;
            }
            return true;
        },
        cadastrar() {
            this.$refs.form.validate()
            
            if(this.valid) {
                let isCadastrar = this.textBtnCTACadastro === 'Cadastrar';
                this.step === 3 ? null : this.step += 1
                if (isCadastrar) {
                    criarContaCliente(this.model).then(({data}) => {
                        registrarTokenUsuario(data)
                        this.$toasted.success('Usuário criado com sucesso')
                        this.$root.$emit('loggedOn', data);
                        this.model.logradouro = '',
                        this.model.numero = '',
                        this.model.complemento = '',
                        this.model.bairro = '',
                        this.model.cidade = '',
                        this.model.uf = '',
                        this.model.cep = '',
                        this.model.nome = '',
                        this.model.email = '',
                        this.model.senha = '',
                        this.model.telefone = '',
                        this.model.cpfCnpj = '',
                        this.model.sexo = '',
                        this.model.dtNascimento = ''
                        this.$router.push({name: 'cliente'})

                    }).catch(error => {
                        trataErro(this, error)
                    })
                    return
                } else {
                    this.$refs.form.resetValidation()
                }

            }
        }
      }
  }
  </script>
  