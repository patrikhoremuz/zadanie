<template>
    <div>
  <b-navbar toggleable="lg" type="dark" variant="info">
    <b-navbar-toggle target="nav-collapse"></b-navbar-toggle>

    <b-collapse id="nav-collapse" is-nav>
      <b-navbar-nav>
        <b-nav-item><router-link to="/current-employees" class="nav-link">Current Employees</router-link></b-nav-item>
        <b-nav-item ><router-link to="/former-employees" class="nav-link">Former Employees</router-link></b-nav-item>
        <b-nav-item ><router-link to="/roles" class="nav-link">Roles</router-link></b-nav-item>
      </b-navbar-nav>
    </b-collapse>
  </b-navbar>
</div>
</template>

<script lang="ts">
import { Component, Vue } from 'vue-property-decorator';

@Component
export default class Navigation extends Vue {
  
}
</script>