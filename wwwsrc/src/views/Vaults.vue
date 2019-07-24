<template>
  <div class="container">
    <div class="row">
      <div class="col">
        <form @submit.prevent="createVault">
          <input class="m-1" type="text" v-model="newVault.name" placeholder="name">
          <input class="m-1" type="text" v-model="newVault.description" placeholder="description">
          <button class="btn btn-info m-2" type="submit">+Vault</button>
        </form>
      </div>
    </div>
    <div class="row" v-if="user.id">
      <user-vault />
    </div>
  </div>
</template>

<script>
  import UserVault from '@/components/UserVault.vue'


  export default {
    name: 'Vaults',
    components: {
      UserVault
    },
    data() {
      return {
        newVault: {
          name: "",
          description: ""
        }
      }
    },
    computed: {
      user() {
        return this.$store.state.user;

      }
    }, //computed
    mounted() {
      this.$store.dispatch("getVaults");

    },//mounted
    methods: {
      createVault() {
        this.$store.dispatch("createVault", this.newVault)
      }
    }//methods
  }
</script>

<style>
</style>