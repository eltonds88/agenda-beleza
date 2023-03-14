<template>
    <v-card class="card-center pa-6">
  
      <v-card-text class="pa-6">
          <v-container>
            <v-form ref="form" v-model="valid">
                <v-row>
                  <v-col cols="12">
                      <label class="logo mr-3">AgendaBeleza</label> cadastrar
                      <h2 class="mt-6">Configure seu perfil de provedor de serviços</h2>
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
                            v-model="model.telefone"
                            label="Telefone"
                            required
                            outlined
                            ></v-text-field>
                        </v-col>

                        <v-col
                            cols="12"
                        >
                            <v-textarea
                            v-model="model.descricao"
                            label="Descrição do seu negócio e serviços para os clientes.*"
                            rows="4"
                            :rules="[
                                () => !!model.descricao || 'Campo obrigatório'
                            ]"
                            :error-messages="errorMessages"
                            required
                            outlined
                            ></v-textarea>
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
                            <v-col cols="12">
                                <v-text-field
                                    v-model="model.facebook"
                                    required>
                                    <template v-slot:prepend>
                                        https://facebook.com/
                                    </template>
                                </v-text-field>
                            </v-col>
                            <v-col cols="12">
                                <v-text-field
                                    v-model="model.instagram"
                                    required>
                                    <template v-slot:prepend>
                                        https://instagram.com/
                                    </template>
                                </v-text-field>
                            </v-col>
                            <v-col cols="12">
                                <v-text-field
                                    v-model="model.twitter"
                                    required>
                                    <template v-slot:prepend>
                                        https://twitter.com/
                                    </template>
                                </v-text-field>
                            </v-col>
                            <v-col cols="12">
                                <v-text-field
                                    v-model="model.whatsapp"
                                    placeholder="WhatsApp"
                                    required>
                                    <template v-slot:prepend>
                                        +55
                                    </template>
                                </v-text-field>
                            </v-col>
                        </v-form>
                    </v-row>
                </div>

                <div v-if="step === 4">
                    <v-row>
                        <v-form ref="form" v-model="valid">
                            <v-container>
                                <v-row v-for="(ele, idx) in model.servicos" :key="`servico${idx}`">
                                    <v-col cols="6">
                                        <v-combobox
                                            v-model="model.servicos[idx].tipoSelected"
                                            :rules="[
                                                () => !!model.servicos[idx].tipoServicoId || 'Campo obrigatório'
                                            ]"
                                            :error-messages="errorMessages"
                                            label="Tipo Serviço*"
                                            required
                                            :items="tiposServicos"
                                            item-text="title"
                                            item-title="title"
                                            @change="() => { model.servicos[idx].tipoServicoId = model.servicos[idx].tipoSelected.value }"
                                        ></v-combobox>
                                    </v-col>
                                    <v-col cols="4">
                                        <v-text-field
                                            v-model="model.servicos[idx].tempoMedioServico"
                                            :rules="[
                                                () => !!model.servicos[idx].tempoMedioServico || 'Campo obrigatório',
                                            ]"
                                            :error-messages="errorMessages"
                                            label="Tempo Médio Serviço*"
                                            required
                                            placeholder="HH:MM"
                                            v-mask="'XX:XX'"
                                        ></v-text-field>
                                    </v-col>
                                </v-row>
                                <v-row>
                                    <v-col>
                                        <v-btn @click="addServico()">Adicionar serviço</v-btn>
                                    </v-col>
                                </v-row>
                            </v-container>
                        </v-form>
                        <small>*campos obrigatórios</small>
                    </v-row>
                </div>

                <div v-if="step === 5">
                    <v-row>
                        <v-form ref="form" v-model="valid">
                            <v-container>
                                <v-row>
                                    <v-col cols="12">
                                        <table>
                                            <table>
                                                <thead>
                                                    <tr>
                                                        <th>
                                                            Fechado
                                                        </th>
                                                        <th>
                                                            Dia
                                                        </th>
                                                        <th>
                                                            Início Expediente
                                                        </th>
                                                        <th>
                                                            Início Intervalo
                                                        </th>
                                                        <th>
                                                            Fim Intervalo
                                                        </th>
                                                        <th>
                                                            Fim Expediente
                                                        </th>
                                                    </tr>
                                                </thead>
                                                <tbody>
                                                    <tr v-for="(ele, idx) in model.horarios" :key="`horario${idx}`">
                                                        <td>
                                                            <v-checkbox v-model="ele.fechado"></v-checkbox>
                                                        </td>
                                                        <td>
                                                            {{ getDia(ele.diaSemana) }}
                                                        </td>
                                                        <td>
                                                            <v-text-field
                                                                v-model="ele.expedienteInicio"
                                                                :rules="[
                                                                    () => { if (ele.fechado) { return true; } return !!ele.expedienteInicio || 'Campo obrigatório' },
                                                                ]"
                                                                :error-messages="errorMessages"
                                                                required
                                                                placeholder="HH:MM"
                                                                v-mask="'XX:XX'"
                                                                :disabled="ele.fechado"
                                                            ></v-text-field>
                                                        </td>
                                                        <td>
                                                            <v-text-field
                                                                v-model="ele.intervaloInicio"
                                                                :error-messages="errorMessages"
                                                                required
                                                                placeholder="HH:MM"
                                                                v-mask="'XX:XX'"
                                                                :disabled="ele.fechado"
                                                            ></v-text-field>
                                                        </td>
                                                        <td>
                                                            <v-text-field
                                                                v-model="ele.intervaloFim"
                                                                :error-messages="errorMessages"
                                                                required
                                                                placeholder="HH:MM"
                                                                v-mask="'XX:XX'"
                                                                :disabled="ele.fechado"
                                                            ></v-text-field>
                                                        </td>
                                                        <td>
                                                            <v-text-field
                                                                v-model="ele.expedienteFim"
                                                                :rules="[
                                                                    () => { if (ele.fechado) { return true; } return !!ele.expedienteFim || 'Campo obrigatório' },
                                                                ]"
                                                                :error-messages="errorMessages"
                                                                required
                                                                placeholder="HH:MM"
                                                                v-mask="'XX:XX'"
                                                                :disabled="ele.fechado"
                                                            ></v-text-field>
                                                        </td>
                                                    </tr>
                                                </tbody>
                                            </table>
                                        </table>
                                    </v-col>
                                </v-row>
                            </v-container>
                        </v-form>
                        <small>*campos obrigatórios</small>
                    </v-row>
                </div>

                <div v-if="step === 6">
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
  import { criarContaFornecedor, logOff, registrarTokenUsuario } from '../services/accountService.js'
  import { estadosOptions, listaTiposServicos } from '../services/listasService.js'
  export default {
    
      name: 'CadastroView',
      components: {},
      data: () => ({
        estados: estadosOptions,
        tiposServicos: [],
        step: 1,
        errorMessages: [],
        tipo: '',
        valid: false,
        model: {
            nome: "",
            telefone: "",
            cpfCnpj: "",

            logradouro: "",
            numero: "",
            complemento: "",
            bairro: "",
            cidade: "",
            uf: "",
            cep: "",

            descricao: "",

            instagram: "",
            facebook: "",
            twitter: "",
            whatsapp: "",
            
            servicos: [
                { tipoServicoId: null, tempoMedioServico: null, tipoSelected: null }
            ],
            horarios: [
                { diaSemana: 1, fechado: false, expedienteInicio: null, intervaloInicio: null, intervaloFim: null, expedienteFim: null },
                { diaSemana: 2, fechado: false, expedienteInicio: null, intervaloInicio: null, intervaloFim: null, expedienteFim: null },
                { diaSemana: 3, fechado: false, expedienteInicio: null, intervaloInicio: null, intervaloFim: null, expedienteFim: null },
                { diaSemana: 4, fechado: false, expedienteInicio: null, intervaloInicio: null, intervaloFim: null, expedienteFim: null },
                { diaSemana: 5, fechado: false, expedienteInicio: null, intervaloInicio: null, intervaloFim: null, expedienteFim: null },
                { diaSemana: 6, fechado: true, expedienteInicio: null, intervaloInicio: null, intervaloFim: null, expedienteFim: null },
                { diaSemana: 7, fechado: true, expedienteInicio: null, intervaloInicio: null, intervaloFim: null, expedienteFim: null },
            ],

            email: "",
            senha: "",
            confirmarSenha: ''
        }
      }),
      computed: {
        textBtnCTACadastro () {
            return this.step === 6 ? 'Cadastrar' : 'Continuar'
        }
      },
      created() {
        logOff();
        listaTiposServicos().then(({data}) => {
            data.forEach(element => {
				this.tiposServicos.push({
					value: element.id,
					title: element.nome
				})
			});
        })
      },
      methods: {
        getTextTipoOpcao(value) {
            if (value) {
                return this.tiposServicos.filter(m => m.value == value)[0].text
            }
            return null
        },
        getDia(dia) {
            switch (dia) {
                case 1:
                return 'Segunda';
                case 2:
                return 'Terça';
                case 3:
                return 'Quarta';
                case 4:
                return 'Quinta';
                case 5:
                return 'Sexta';
                case 6:
                return 'Sábado';
                case 7:
                return 'Domingo';
            }
        },
        addServico() {
            this.model.servicos.push({ tipoServicoId: null, tempoMedioServico: null })
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
                let isCadastrar = this.textBtnCTACadastro === 'Cadastrar';
                this.step === 6 ? null : this.step += 1
                if (isCadastrar) {
                    criarContaFornecedor(this.model).then(({data}) => {
                        registrarTokenUsuario(data)
                        this.$toasted.success('Usuário criado com sucesso')
                        this.$root.$emit('loggedOn', data);
                        this.$router.push({name: 'fornecedor'})

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
  