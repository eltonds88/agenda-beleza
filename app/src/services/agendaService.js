import { api } from './api.js'

export const buscarServicos = () => {
    return api.get('api/cliente/home')
}
