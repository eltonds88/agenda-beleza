import { api } from './api.js'

export const buscarServicos = (filtro) => {
    return api.get(`api/pets/buscar-pets?filtro=${filtro}`)
}
