import { api } from './api.js'

export const pesquisarCidades = (cidade) => {
    return api.get(`api/listas/cidades?cidade=${cidade}`)
}

export const listaTiposServicos = () => {
    return api.get(`api/listas/tipos-servicos`)
}

export const sexoOptions = [
    { text: 'Masculino', value: 'Masculino' },	
    { text: 'Feminino', value: 'Feminino' },
    { text: 'Não informar', value: 'Não informar' }
]

export const estadosOptions = [
    { text: 'AC', value: 'AC' },
    { text: 'AL', value: 'AL' },
    { text: 'AP', value: 'AP' },
    { text: 'AM', value: 'AM' },
    { text: 'BA', value: 'BA' },
    { text: 'CE', value: 'CE' },
    { text: 'DF', value: 'DF' },
    { text: 'ES', value: 'ES' },
    { text: 'GO', value: 'GO' },
    { text: 'MA', value: 'MA' },
    { text: 'MT', value: 'MT' },
    { text: 'MS', value: 'MS' },
    { text: 'MG', value: 'MG' },
    { text: 'PA', value: 'PA' },
    { text: 'PB', value: 'PB' },
    { text: 'PR', value: 'PR' },
    { text: 'PE', value: 'PE' },
    { text: 'PI', value: 'PI' },
    { text: 'RJ', value: 'RJ' },
    { text: 'RN', value: 'RN' },
    { text: 'RS', value: 'RS' },
    { text: 'RO', value: 'RO' },
    { text: 'RR', value: 'RR' },
    { text: 'SC', value: 'SC' },
    { text: 'SP', value: 'SP' },
    { text: 'SE', value: 'SE' },
    { text: 'TO', value: 'TO' }   
]