<template>
  <div class="container-fluid home">
    <div class="row">
      <div class="col">
        <h1>Welcome Home {{user.username}}</h1>
        <button v-if="user.id" @click="logout">logout</button>
        <router-link v-else :to="{name: 'login'}">Login</router-link>
      </div>
      <public-keeps />
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