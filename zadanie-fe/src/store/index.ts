import Vue from "vue";
import Vuex, {StoreOptions} from 'vuex'
import { RootState } from "./types"
import axios from "axios"
import { Employee } from "@/interfaces";
import moment from "moment"

Vue.use(Vuex);

const baseUrl = 'http://localhost:2396/';

const store: StoreOptions<RootState> = {
    state: {
      currentEmployees: [],
      formerEmployees: [],
      roles:[],
      selectedEmployee: {
        id: 0,
        firstName: '',
        lastName: '',
        address: '',
        dateOfBirth: '',
        validFrom: moment().format('YYYY-MM-DD'),
        role: 0,
        salary: 0,
        roleName: '',
        roles: [],
    },
    employeeEditMode: false
    },
    actions: {
      getCurrentEmployees(){
        axios.get(baseUrl + 'employee/current')
            .then(response => {
              this.commit('SET_CURRENT', response.data)
            })
      },
      getFormerEmployees(){
        axios.get(baseUrl + 'employee/former')
            .then(response => {
              this.commit('SET_FORMER', response.data)
            })
      },
      getRoles(){
        axios.get(baseUrl + 'role')
            .then(response => {
              this.commit('SET_ROLES', response.data)
            })
      },
      deleteEmployee(store,id: number){
        axios.delete(baseUrl + 'employee/'+ id).then(() => {
          this.dispatch('getCurrentEmployees')
        })
      },
      archiveEmployee(store,id: number){
        axios.put(baseUrl + 'employee/archive/'+ id).then(() => {
          this.dispatch('getCurrentEmployees')
        })
      },
      createOrUpdateEmployee(store, employee: Employee){
        axios.post(baseUrl + 'employee', employee).then(()=>{
          this.dispatch('setSelectedEmployee', employee);
          this.dispatch('setEmployeeEditMode', false);
        })
      },
      setSelectedEmployee(store, employee: Employee){
        employee.dateOfBirth = moment(employee.dateOfBirth).format('YYYY-MM-DD');
        employee.validFrom = moment(employee.validFrom).format('YYYY-MM-DD');
        this.commit('SET_SELECTED_EMPLOYEE', employee);
      },
      removeRole(store, roleId: number){
        axios.delete(baseUrl + 'role/' + roleId).then(() => {
          this.dispatch('getRoles')
        })
      },
      createRole(store, roleName:string){
        axios.post(baseUrl + 'role/' + roleName).then(() => {
          this.dispatch('getRoles')
        })
      },
      setEmployeeEditMode(store, value: boolean){
        this.commit('SET_EMPLOYEE_EDITMODE', value)
      }
    },
    mutations: {
      SET_CURRENT(state, currentEmployees){
        state.currentEmployees = currentEmployees
      },
      SET_FORMER(state, formerEmployees){
        state.formerEmployees = formerEmployees
      },
      SET_ROLES(state, roles){
        state.roles = roles
      },
      SET_SELECTED_EMPLOYEE(state, employee){
        state.selectedEmployee = employee
      },
      SET_EMPLOYEE_EDITMODE(state, value){
        state.employeeEditMode = value
      }
    },
    getters: {
      current: (state) => state.currentEmployees
    }
}

export default new Vuex.Store<RootState>(store);