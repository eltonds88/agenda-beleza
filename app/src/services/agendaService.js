import { apiFormData, api } from './api.js'

export const criarPet = (formData) => {
    return apiFormData.post(`api/pets`, formData)
}


export const buscarServicos = (filtro) => {
    return api.get(`api/pets/buscar-pets?filtro=${filtro}`)
}
