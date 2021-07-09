import Vue from 'vue'
import VueRouter, { RouteConfig } from 'vue-router'
import FormerEmployees from '../views/FormerEmployees.vue'
import EmployeeEdit from '../views/EmployeeEdit.vue'
import Roles from '../views/Roles.vue'

Vue.use(VueRouter)

const routes: Array<RouteConfig> = [
  {
    path: '/',
    redirect: '/current-employees',
  },
  {
    path: '/former-employees',
    name: 'FormerEmployees',
    component: FormerEmployees
  },
  {
    path: '/current-employees',
    name: 'CurrentEmployees',
    // route level code-splitting
    // this generates a separate chunk (about.[hash].js) for this route
    // which is lazy-loaded when the route is visited.
    component: () => import(/* webpackChunkName: "about" */ '../views/CurrentEmployees.vue')
  },
  {
    path: '/roles',
    name: 'Roles',
    component: Roles
  },
  {
    path: '/edit-employee',
    name: 'EditEmployee',
    component: EmployeeEdit
  }
]

const router = new VueRouter({
  routes
})

export default router
