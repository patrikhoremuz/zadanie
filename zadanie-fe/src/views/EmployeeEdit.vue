<template>
<b-container>
  <b-row>
    <b-col>
      <b-form @submit="onSubmit" v-if="editMode" class="mt-3">
        <b-form-group
          id="input-group-1"
          label="First Name"
          label-for="firstname"
        >
          <b-form-input
            id="firstname"
            v-model="employee.firstName"
            required
          ></b-form-input>
        </b-form-group>

        <b-form-group
          id="input-group-2"
          label="Last Name"
          label-for="lastname"
        >
          <b-form-input
            id="lastname"
            v-model="employee.lastName"
            required
          ></b-form-input>
        </b-form-group>

        <b-form-group
          id="input-group-3"
          label="Address"
          label-for="address"
        >
          <b-form-input
            id="address"
            v-model="employee.address"
            required
          ></b-form-input>
        </b-form-group>

        <b-form-group
          id="input-group-4"
          label="Date of birth"
          label-for="dateofbirth"
        >
          <b-form-input
            id="dateofbirth"
            v-model="employee.dateOfBirth"
            type="date"
            required
          ></b-form-input>
        </b-form-group>

        <b-form-group
          id="input-group-5"
          label="Valid from"
          label-for="validfrom"
        >
          <b-form-input
            id="validfrom"
            v-model="employee.validFrom"
            type="date"
            required
          ></b-form-input>
        </b-form-group>

        <b-form-group id="input-group-6" label="Roles" label-for="role">
          <b-form-select
            id="role"
            v-model="employee.role"
            :options="roles"
            value-field="id"
            text-field="roleName"
            required
          ></b-form-select>
        </b-form-group>

        <b-form-group
          id="input-group-7"
          label="Salary"
          label-for="salary"
        >
        <b-form-input
          id="salary"
          v-model="employee.salary"
          required
        ></b-form-input>
      </b-form-group>

      <b-button type="submit" variant="primary">Submit</b-button>
    </b-form>
    <div v-if="!editMode" class="mt-3">
      <b-list-group>
        <b-list-group-item><strong>First name: </strong>{{employee.firstName}}</b-list-group-item>
        <b-list-group-item><strong>Last name: </strong>{{employee.lastName}}</b-list-group-item>
        <b-list-group-item><strong>Address: </strong>{{employee.address}}</b-list-group-item>
        <b-list-group-item><strong>Date of birth: </strong>{{employee.dateOfBirth}}</b-list-group-item>
        <b-list-group-item><strong>Valid from: </strong>{{employee.validFrom}}</b-list-group-item>
        <b-list-group-item><strong>Role: </strong>{{employee.roleName}}</b-list-group-item>
        <b-list-group-item><strong>Salary: </strong>{{employee.salary}}€</b-list-group-item>
      </b-list-group>
    </div>
    </b-col>
    <b-col>
      <b-card class="mt-3" header="Last roles">
        <b-table small :fields="fields" :items="employee.roles" responsive="sm">
          <template #cell(validFrom)="data">
            {{ data.item.validFrom | formatDate}}
          </template>

          <template #cell(validTo)="data">
            {{ data.item.validTo | formatDate}}
          </template>
        </b-table>
      </b-card>
    </b-col>
  </b-row>
</b-container>
</template>

<script lang="ts">
import { Employee, Role } from '@/interfaces';
import { Component, Vue } from 'vue-property-decorator';
import moment from "moment";

@Component({
  components: {
  },
  filters: {
    formatDate(value: moment.Moment | string): string{
      return moment(value).format('YYYY-MM-DD')
    }
  }
})
export default class EmployeeEdit extends Vue {

  get editMode(): boolean{
    return this.$store.state.employeeEditMode;
  }

  public fields = [
    'validFrom',
    'validTo',
    'roleName'
  ]
    get employee(): Employee{
      return this.$store.state.selectedEmployee;
    }

    get roles(): Role[]{
      return this.$store.state.roles;
    }

    mounted():void {
      this.$store.dispatch("getRoles");
    }

    onSubmit(): void{
        this.employee.roleName = this.roles.find(x=>x.id == this.employee.role)?.roleName || '';
        this.$store.dispatch("createOrUpdateEmployee", this.employee);
    }

}
</script>
