<template>
  <div class="col">
    <form @submit.prevent="createKeep">
      <input class="m-1" type="text" v-model="newKeep.name" placeholder="name">
      <input class="m-1" type="text" v-model="newKeep.description" placeholder="description">
      <input class="m-1" type="text" v-model="newKeep.img" placeholder="img url">
      <button class="btn btn-info m-2" type="submit">+Keep</button>
    </form>
  </div>
</template>

<script>
  export default {
    name: "CreateKeep",
    data() {
      return {
        newKeep: {
          name: "",
          description: "",
          img: ""
        }
      }
    }, //data
    methods: {
      createKeep() {
        this.$store.dispatch('createKeep', this.newKeep)
      }
    }, //methods
  }
</script>

<style>
</style>