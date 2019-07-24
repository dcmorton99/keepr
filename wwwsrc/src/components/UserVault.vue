<template>
  <div class="col-4">
    <div class="card m-2" v-for="vault in vaults" :value="vault.id">
      <div class="card-body">
        <h3 class="card-title">{{vault.name}}</h3>
        <h5>{{vault.description}}</h5>
        <button type="button" class="btn btn-secondary m-2" @click="deleteVault(vault.id)"><i
            class="far fa-trash-alt"></i></button>
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
      }
    }

  }
</script>

<style>
</style>