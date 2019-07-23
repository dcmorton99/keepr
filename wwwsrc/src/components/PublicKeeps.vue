<template>
  <div class="col">
    <div class="card m-2" v-for="keep in keeps" :value="keep.id">
      <img :src="keep.img" class="card-img-top">
      <div class="card-body">
        <h3 class="card-title">{{keep.name}}</h3>
        <h5>{{keep.description}}</h5>
        <i class="far fa-eye m-1"> {{keep.views}} </i>
        <i class="fas fa-bullhorn m-1"> {{keep.shares}} </i>
        <i class="far fa-hdd m-1"> {{keep.keeps}} </i>
        <button type="button" class="btn btn-success m-2" @click="gotToKeep(keep.id)">Lookie!</button>
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
    } //computed
  }
</script>

<style>
</style>