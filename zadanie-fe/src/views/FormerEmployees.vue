<template>
  <b-container>
    <EmployeesTable class="mt-2" :employees="employees" :currentEmployee="false"/>
  </b-container>
</template>

<script lang="ts">
import { Component, Vue } from 'vue-property-decorator';
import EmployeesTable from '@/components/EmployeesTable.vue'; // @ is an alias to /src
import { Employee } from '@/interfaces';

@Component({
  components: {
    EmployeesTable,
  },
})
export default class FormerEmployees extends Vue {
  get employees(): Employee[]{
    return this.$store.state.formerEmployees;
  }
  mounted(): void{
      this.$store.dispatch("getFormerEmployees");
  }
}
</script>
