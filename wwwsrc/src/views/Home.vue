<template>
  <div class="container-fluid home">
    <div class="row">
      <div class="col-12">
        <h1>Welcome Home {{user.username}}</h1>
        <button class="btn btn-info" v-if="user.id" @click="logout">logout</button>
        <router-link v-else :to="{name: 'login'}"><button class="btn btn-warning">Login</button></router-link>
        <router-link :to="{name: 'vaults'}"><button class="btn btn-warning" v-if="user.id">Go to Vaults</button>
        </router-link>
      </div>
      <div class="row">
        <public-keeps />
      </div>
      <div class="row" v-if="user.id">
        <user-keeps />
        <create-keep />
      </div>
    </div>
  </div>
</template>

<script>
  import PublicKeeps from '@/components/PublicKeeps.vue'
  import UserKeeps from '@/components/UserKeeps.vue'
  import CreateKeep from '@/components/CreateKeep.vue'


  export default {
    name: "home",
    components: {
      PublicKeeps,
      UserKeeps,
      CreateKeep
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
      this.$store.dispatch("getUserKeeps");


    }, //mounted


  };
</script>