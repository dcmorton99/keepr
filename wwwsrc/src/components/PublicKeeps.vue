<template>
  <div class="row">
    <div class="col">
      <div class="card" v-for="keep in keeps" :value="keep.id">
        <img src="http://placehold.it/200x200" class="card-img-top">
        <div class="card-body">
          <h5 class="card-title">Card title</h5>
          <a href="#" class="btn btn-primary">Go somewhere</a>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
  export default {
    name: 'PublicKeeps',
    data() {
      return {}
    }, //data
    computed: {
      keeps() {
        return this.$store.state.keeps
      }
    }
  }
</script>

<style>
</style>