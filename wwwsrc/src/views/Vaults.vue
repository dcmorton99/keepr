<template>
  <div class="container">
    <div class="row" v-if="user.id">
      <user-keeps />
    </div>
  </div>
</template>

<script>
  import UserKeeps from '@/components/UserKeeps.vue'

  export default {
    name: 'Vaults',
    components: {
      UserKeeps
    },
    data() {
      return {}
    },
    computed: {
      user() {
        return this.$store.state.user;
      }
    }, //computed
    mounted() {
      this.$store.dispatch("getUserKeeps");
    }
  }
</script>

<style>
</style>