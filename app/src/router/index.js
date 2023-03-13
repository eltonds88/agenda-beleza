import Vue from 'vue'
import VueRouter from 'vue-router'
import LoginView from '../views/LoginView'
import CadastroClienteView from '../views/CadastroClienteView'
import HomeClienteView from '../views/HomeClienteView'
import NotFound from '../views/NotFoundView'

Vue.use(VueRouter)

const routes = [
	{
		path: '*',
		name: 'notFound',
		component: NotFound,
		meta: {
			layout: 'noheader'
		}
	},
	{
		path: '/login',
		name: 'login',
		component: LoginView,
		meta: {
			layout: 'noheader'
		}
	},

	{
		path: '/cadastrar',
		name: 'cadastrar',
		component: CadastroClienteView,
		meta: {
			layout: 'noheader'
		}
	},

	{
		path: '/cliente',
		name: 'cliente',
		component: HomeClienteView
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
		// route level code-splitting
		// this generates a separate chunk (petsAdoption.[hash].js) for this route
		// which is lazy-loaded when the route is visited.
		component: () => import(/* webpackChunkName: "petsAdoption" */ '../views/ListaServicos.vue')
	},
	{
		path: '/agendamentos',
		name: 'AgendamentosServicos',
		// route level code-splitting
		// this generates a separate chunk (petsAdoption.[hash].js) for this route
		// which is lazy-loaded when the route is visited.
		component: () => import(/* webpackChunkName: "petsAdoption" */ '../views/AgendamentosServicos.vue')
	}
	
	
]

const router = new VueRouter({
	mode: 'history',
	base: process.env.BASE_URL,
	routes 
})

export default router
