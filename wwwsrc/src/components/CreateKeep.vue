<template>
  <div class="col">
    <div class="card" id="create-keep">
      <h4>Create New Keeps</h4>
      <form @submit.prevent="createKeep">
        <input class="m-1" type="text" v-model="newKeep.name" placeholder="name">
        <input class="m-1" type="text" v-model="newKeep.description" placeholder="description">
        <br />
        <textarea class="m-1" type="text" v-model="newKeep.img" placeholder="img url"></textarea>
        <br />
        <button class="btn btn-info m-2" type="submit">+Keep</button>
      </form>
    </div>
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
          img: "",
          isPrivate: true,


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
  #create-keep {
    background-color: lightgray;
  }
</style>