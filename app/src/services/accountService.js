import { api } from './api.js'

export const registrarTokenUsuario = (response) => {
    localStorage.setItem("user", JSON.stringify(response))
}

export const getUsuarioLogado = () => {
    let user = localStorage.getItem('user');
    if (user != null) {
        return JSON.parse(user)
    }
    return null;
}

export const logOff = () => {
    localStorage.removeItem('user')
}

export const fazerLogin = (email, senha) => {
    return api.post('api/account/login', { email, senha })
}

export const criarContaCliente = (model) =>  {
    return api.post('api/account/criar-cliente', model)
}

export const criarContaFornecedor = (model) =>  {
    return api.post('api/account/criar-fornecedor', model)
}
