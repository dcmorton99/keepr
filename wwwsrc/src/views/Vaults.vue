<template>
  <div class="container">
    <div class="row">
      <div class="col-12">
        <h1>Welcome to Your Dashboard {{user.username}}</h1>
        <router-link :to="{name: 'home'}"><button class="btn btn-secondary m-2">Go Home</button>
        </router-link>
      </div>
      <div class="col">
        <h4>Create a New Vault: </h4>
        <form @submit.prevent="createVault">
          <input class="m-1" type="text" v-model="newVault.name" placeholder="name">
          <input class="m-1" type="text" v-model="newVault.description" placeholder="description">
          <button class="btn btn-info m-2" type="submit">+Vault</button>
        </form>
      </div>
    </div>

    <div class="row">
      <user-vault />
    </div>
    <div class="row">
      <create-keep />
      <div class="col-12">
        <h2>My Keeps</h2>
      </div>
    </div>
    <div class="row">
      <user-keeps v-for="keep in userKeeps" :value="keep.id" :myKeeps="keep" />
    </div>
  </div>
</template>

<script>
  import UserVault from '@/components/UserVault.vue'
  import CreateKeep from '@/components/CreateKeep.vue'
  import UserKeeps from '@/components/UserKeeps.vue'


  export default {
    name: 'Vaults',
    components: {
      UserVault,
      CreateKeep,
      UserKeeps
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
      },
      userKeeps() {
        return this.$store.state.userKeeps;
      }
    }, //computed
    mounted() {
      this.$store.dispatch("getVaults");
      this.$store.dispatch("getUserKeeps")
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