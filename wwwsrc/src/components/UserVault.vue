<template>
  <div class="col-4">
    <div class="card m-2" v-for="vault in vaults" :value="vault.id">
      <div class="card-body">
        <h3 class="card-title">{{vault.name}}</h3>
        <h5>{{vault.description}}</h5>

      </div>
    </div>
  </div>

</template>

<script>
  export default {
    name: 'UserVaults',
    data() {
      return {}
    }, //data
    computed: {
      user() {
        return this.$store.state.user
      },
      vaults() {
        return this.$store.state.vaults
      }
    }, //computed

  }
</script>

<style>
</style>