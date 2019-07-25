<template>
  <div class="container">
    <div class="row">
      <div class="col">
        <h4>Vault: {{vault.name}}</h4>
        <router-link :to="{name: 'home'}"><button class="btn btn-secondary m-2">Go Home</button>
        </router-link>
        <div class="card m-2" v-for="vaultkeep in vaultKeeps" :value="vaultkeep.id">
          <img :src="vaultkeep.img" class="card-img-top">
          <div class="card-body">
            <h3 class="card-title">{{vaultkeep.name}}</h3>
            <h5>{{vaultkeep.description}}</h5>
            <i class="far fa-eye m-1"> {{vaultkeep.views}} </i>
            <i class="fas fa-bullhorn m-1"> {{vaultkeep.shares}} </i>
            <i class="far fa-hdd m-1"> {{vaultkeep.keeps}} </i>
            <button type="button" class="btn btn-secondary m-2" @click="deleteFromVault(vaultkeep.id)"><i
                class="far fa-trash-alt"></i></button>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>


  export default {
    name: 'Vault',
    data() {
      return {}
    },
    computed: {
      user() {
        return this.$store.state.user
      },
      vault() {
        return this.$store.state.vault
      },
      vaultId() {
        return this.$route.params.id
      },
      vaultKeeps() {
        return this.$store.state.vaultKeeps
      }
    },//computed
    mounted() {
      if (!this.vault.id) {
        this.$store.dispatch('getVault', this.vaultId)
      }
      this.$store.dispatch('getVaultKeeps', this.vaultId)
    },//mounted
    methods: {
      deleteFromVault(id) {
        let data = {
          vaultId: this.vaultId,
          keepId: id
        }
        this.$store.dispatch('deleteVaultKeep', data)
      }
    }
  }

</script>

<style>
</style>