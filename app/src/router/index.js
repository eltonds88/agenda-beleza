import Vue from 'vue'
import VueRouter from 'vue-router'
import LoginView from '../views/LoginView'
import CadastroClienteView from '../views/CadastroClienteView'
import HomeClienteView from '../views/HomeClienteView'
import NotFound from '../views/NotFoundView'
import { getUsuarioLogado } from '@/services/accountService'

//const TIPO_FORNECEDOR = "FORNECEDOR";
export const TIPO_CLIENTE = "CLIENTE";

Vue.use(VueRouter)

const routes = [
	{
		path: '*',
		name: 'notFound',
		component: NotFound,
		meta: {
			layout: 'noheader',
			requireAuth: false
		}
	},
	{
		path: '/login',
		name: 'login',
		component: LoginView,
		meta: {
			layout: 'noheader',
			requireAuth: false
		}
	},

	{
		path: '/cadastrar-cliente',
		name: 'cadastrar-cliente',
		component: CadastroClienteView,
		meta: {
			layout: 'noheader',
			requireAuth: false
		}
	},

	{
		path: '/cliente',
		name: 'cliente',
		component: HomeClienteView,
		meta: {
			requireAuth: true,
			role: TIPO_CLIENTE
		}
	},

	{
		path: '/',
		name: 'home',
		redirect: () => {
			// the function receives the target route as the argument
			// a relative location doesn't start with `/`
			// or { path: 'profile'}
			return 'login'
		}
	},
	{
		path: '/lista-servicos',
		name: 'ListaServicos',
		component: () => import(/* webpackChunkName: "ListaServicos" */ '../views/ListaServicos.vue'),
		meta: {
			requireAuth: true,
			role: TIPO_CLIENTE
		}
	},
	{
		path: '/agendamentos',
		name: 'AgendamentosServicos',
		component: () => import(/* webpackChunkName: "AgendamentosServicos" */ '../views/AgendamentosServicos.vue'),
		meta: {
			requireAuth: true,
			role: TIPO_CLIENTE
		}
	}
	
	
]

const router = new VueRouter({
	mode: 'history',
	base: process.env.BASE_URL,
	routes 
})

export default router


router.beforeEach((to, from, next) => {
	var user = getUsuarioLogado();
	//se não está logado e pagina requer autenticacao, envia para login
    if (to.meta && to.meta.requireAuth && user == null) {
		return next({ name: 'login' });
	}
	//se está logado e página requer uma role diferente do usuário, envia para o login
	if (user != null && to.meta && to.meta.role && to.meta.role != user.role) {
		return next({ name: 'login' });
	}
    next();
});
