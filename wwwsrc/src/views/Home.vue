<template>
  <div class="container-fluid home">
    <div class="row">
      <div class="col-12">
        <h1>Welcome to Keepr {{user.username}}</h1>
        <button class="btn btn-info" v-if="user.id" @click="logout">logout</button>
        <router-link v-else :to="{name: 'login'}"><button class="btn btn-warning m-2">Login</button></router-link>
        <router-link :to="{name: 'vaults'}"><button class="btn btn-warning m-2" v-if="user.id">Go to Dashboard</button>
        </router-link>
      </div>
      <div class="row">
        <public-keeps v-for="keep in keeps" :value="keep.id" :publicKeeps="keep" />
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
      },

      keeps() {
        return this.$store.state.keeps;
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