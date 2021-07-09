<template>
  <div id="employees-table">
    <div></div>
     <b-table small :fields="fields" :items="employees" responsive="sm">

      <template #cell(fullName)="data">
        <b-link to="/edit-employee" v-on:click="selectEmployeeForEdit(data.item, false)">{{ data.item.firstName }} {{ data.item.lastName}}</b-link>
      </template>
      <!-- A virtual column -->
      <template #cell(role)="data">
        {{ data.item.roleName}}
      </template>

      <template #cell(validTo)="data">
        {{ data.item.validTo | formatDate}}
      </template>

      <template #head(edit)="">
        <span class="text-info"></span>
      </template>
      <!-- A virtual composite column -->
      <template #cell(edit)="data">
        <b-button size="sm" variant="warning" to="/edit-employee" v-on:click="selectEmployeeForEdit(data.item, true)"><font-awesome-icon icon="user-edit" /> Edit</b-button>
      </template>
      <template #head(delete)="">
        <span class="text-info"></span>
      </template>
      <!-- A virtual composite column -->
      <template #cell(delete)="data">
        <b-button size="sm" variant="danger" v-on:click="showMsgBoxOne(data.item.id)"><font-awesome-icon icon="user-times" /> Delete</b-button>
      </template>

      <template #head(permaDelete)="">
        <span class="text-info"></span>
      </template>
      <!-- A virtual composite column -->
      <template #cell(permaDelete)="data">
        <b-button size="sm" variant="danger" v-on:click="permanentDeleteEmployee(data.item.id)"><font-awesome-icon icon="user-times" /> Delete</b-button>
      </template>
    </b-table>
  </div>
</template>

<script lang="ts">
import moment from 'moment';
import { Component, Prop, Vue } from 'vue-property-decorator';
import { Employee } from '../interfaces'

@Component({
  components: {
  },
  filters: {
    formatDate(value: moment.Moment | string): string{
      return moment(value).format('YYYY-MM-DD')
    }
  }
})
export default class EmployeesTable extends Vue {

  @Prop({ type: Array, required: true })
        employees!: Employee[];

  @Prop() currentEmployee!: boolean;

  public fields = [
    'fullName',
    'role',
    'edit',
    'delete',
  ]

  mounted(): void{
    if(!this.currentEmployee){
      this.fields = [
        'fullName',
        'role',
        'validTo',
        'permaDelete'
      ];
    }
  }

  selectEmployeeForEdit(employee: Employee, editMode: boolean): void{
      this.$store.dispatch("setEmployeeEditMode", editMode);
      this.$store.dispatch("setSelectedEmployee", employee);
  }

  permanentDeleteEmployee(id: number): void{
    this.$store.dispatch("deleteEmployee", id); 
  }

  showMsgBoxOne(id: number): void {
    this.$bvModal.msgBoxConfirm('Do you want to archive selected employee?', {okTitle: 'Archive',
          cancelTitle: 'Delete',
          okVariant: 'success',
          cancelVariant: 'danger',
          noCloseOnBackdrop: true})
      .then((value: boolean) => {
        if(value){
          this.$store.dispatch("archiveEmployee", id);        
        }
        else{
          this.permanentDeleteEmployee(id);  
        }
      })
  }
}


</script>

<style scoped lang="scss">

</style>
