<template>
  <div class="col">
    <div class="card m-2" v-for="vault in vaults" :value="vault.id">
      <div class="card-body">
        <h4 class="card-title">{{vault.name}}</h4>
        <h5>{{vault.description}}</h5>
        <button type="button" class="btn btn-secondary m-2" @click="deleteVault(vault.id)"><i
            class="far fa-trash-alt"></i></button>
        <button class="btn btn-info" @click="goToVault(vault.id)">Go to Vault</button>
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
    methods: {
      deleteVault(id) {
        this.$store.dispatch('deleteVault', id)
      },
      goToVault(id) {
        this.$store.dispatch('getVault', id)
      }
    }

  }
</script>

<style>
</style>