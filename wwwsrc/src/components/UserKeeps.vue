<template>
  <div class="col">
    <div class="card m-2" v-for="keep in userKeeps" :value="keep.id">
      <img :src="keep.img" class="card-img-top">
      <div class="card-body">
        <h3 class="card-title">{{keep.name}}</h3>
        <h5>{{keep.description}}</h5>
        <i class="far fa-eye m-1"> {{keep.views}} </i>
        <i class="fas fa-bullhorn m-1"> {{keep.shares}} </i>
        <i class="far fa-hdd m-1"> {{keep.keeps}} </i>
        <button type="button" class="btn btn-secondary m-2" @click="deleteKeep(keep.id)"><i
            class="far fa-trash-alt"></i></button>
      </div>
    </div>
  </div>

</template>

<script>
  export default {
    name: 'UserKeeps',
    data() {
      return {}
    }, //data
    computed: {
      userKeeps() {
        return this.$store.state.userKeeps
      }
    }, //computed
    mounted() {
      this.$store.dispatch("getUserKeeps")
    }, //mounted
    methods: {
      deleteKeep(id) {
        this.$store.dispatch("deleteKeep", id)
      }
    }

  }
</script>

<style>
</style>