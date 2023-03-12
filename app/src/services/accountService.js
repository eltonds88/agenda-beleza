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


export const marcarPerfilCompleto = () => {
    let userJson = localStorage.getItem('user');
    if (userJson != null) {
        var user = JSON.parse(userJson);
        user.cadastroCompleto = true;
        localStorage.setItem("user", JSON.stringify(user))
    }
}
