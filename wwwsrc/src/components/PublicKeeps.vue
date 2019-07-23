<template>
  <div class="row">
    <div class="col-3">
      <div class="card" v-for="keep in keeps" :value="keep.id">
        <img :src="keep.img" class="card-img-top">
        <div class="card-body">
          <h3 class="card-title">{{keep.name}}</h3>
          <h5>{{keep.description}}</h5>
          <i class="far fa-eye"> {{keep.views}}</i>
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