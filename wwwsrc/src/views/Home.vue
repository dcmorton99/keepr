<template>
  <div class="container-fluid home">
    <div class="row">
      <div class="col-12">
        <h1>Welcome Home {{user.username}}</h1>
        <button class="btn btn-info" v-if="user.id" @click="logout">logout</button>
        <router-link v-else :to="{name: 'login'}">Login</router-link>
      </div>
      <router-link :to="{name: 'vaults'}">Go to Vaults</router-link>
      <div class="row">
        <public-keeps />
      </div>
    </div>
  </div>
</template>

<script>
  import PublicKeeps from '@/components/PublicKeeps.vue'


  export default {
    name: "home",
    components: {
      PublicKeeps
    },

    computed: {
      user() {
        return this.$store.state.user;
      }
    },

    methods: {
      logout() {
        this.$store.dispatch("logout");
      }
    }, //methods

    mounted() {
      this.$store.dispatch("getPublicKeeps");

    }, //mounted


  };
</script>