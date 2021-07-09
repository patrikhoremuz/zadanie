<template>
  <b-container>
    <b-row align-v="start" class="mt-2">
      <b-col><b-button variant="success" to="/edit-employee" @click="setEmployee(true)"><font-awesome-icon icon="plus" /> Add Employee</b-button></b-col>
    </b-row>
    <EmployeesTable class="mt-2" :employees="employees" :currentEmployee="true"/>
  </b-container>
</template>

<script lang="ts">
import { Component, Vue } from 'vue-property-decorator';
import EmployeesTable from '@/components/EmployeesTable.vue'; // @ is an alias to /src
import { Employee } from '@/interfaces';
import moment from 'moment';


@Component({
  components: {
    EmployeesTable,
  },
})
export default class CurrentEmployees extends Vue {
  public newEmployee: Employee = {
        id: 0,
        firstName: '',
        lastName: '',
        address: '',
        dateOfBirth: '',
        validFrom: moment().format('YYYY-MM-DD'),
        role: 0,
        roleName: '',
        salary: 0,
        roles: [],
  };
  
  get employees(): Employee[]{
    return this.$store.state.currentEmployees;
  }
 
  mounted(): void{
      this.$store.dispatch("getCurrentEmployees");
  }

  setEmployee(editModeValue: boolean): void {
    this.$store.dispatch("setSelectedEmployee", this.newEmployee)
    this.$store.dispatch("setEmployeeEditMode", editModeValue);
  }
}
</script>