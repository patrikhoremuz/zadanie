<template>
    <b-container>
        <b-row align-v="start" class="mt-2" v-if="!showForm">
            <b-col><b-button variant="success" @click="showForm = !showForm"><font-awesome-icon icon="plus" /> Add Role</b-button></b-col>
        </b-row>
        <b-form @submit="onSubmit" v-if="showForm">
            <b-form-group
                id="input-group-1"
                label="Role name"
                label-for="rolename"
            >
                <b-form-input
                id="rolename"
                v-model="roleName"
                required
                ></b-form-input>
            </b-form-group>

            <b-button type="submit" variant="primary">Submit</b-button>
            <b-button type="cancel" variant="danger" @click="showForm = !showForm">Cancel</b-button>
        </b-form>
        <b-table small striped hover :items="roles" :fields="fields" class="mt-2"> <!-- Optional default data cell scoped slot -->
            <template #cell(roleName)="data">
                {{data.item.roleName}}
            </template>
            <template #cell(delete)="data">
                <b-button variant="danger" v-on:click="deleteRole(data.item.id)"><font-awesome-icon icon="times" /></b-button>
            </template>
        </b-table>
    </b-container>
</template>
<script lang="ts">
import { Role } from '@/interfaces';
import { Component, Vue } from 'vue-property-decorator';

@Component
export default class Roles extends Vue {
  get roles(): Role[]{
    return this.$store.state.roles;
  }

  public roleName = '';
  public showForm = false;

  fields = [
      'roleName',
      'delete'
    ]
  mounted(): void{
      this.$store.dispatch("getRoles");
  }

  deleteRole(roleId: number): void {
      this.$store.dispatch("removeRole", roleId);
  }

  onSubmit(): void{
      this.$store.dispatch("createRole", this.roleName)
  }
}
</script>

<style lang="scss" scoped>

</style>
