<template>
  <div class="col">
    <div class="card m-2" id="my-keeps">
      <div class="card-body">
        <h3 class="card-title">{{myKeeps.name}}</h3>
        <img :src="myKeeps.img" class="card-img-top">
        <h5>{{myKeeps.description}}</h5>
        <i class="far fa-eye m-1"> {{myKeeps.views}} </i>
        <i class="fas fa-bullhorn m-1"> {{myKeeps.shares}} </i>
        <i class="far fa-hdd m-1"> {{myKeeps.keeps}} </i>
        <button v-show="myKeeps.isPrivate == true" type="button" class="btn btn-secondary m-2"
          @click="deleteKeep(myKeeps.id)"><i class="far fa-trash-alt"></i></button>
        <form @submit.prevent="addToVault(myKeeps.id)">
          <select v-model="selected">
            <option disabled value>Add to a Vault</option>
            <option v-for="vault in vaults" :value="vault.id">{{vault.name}}
            </option>
          </select>
          <button class="btn-sm btn-info m-2" type="submit">Submit</button>
        </form>
      </div>
    </div>
  </div>
</template>

<script>
  export default {
    name: 'UserKeeps',
    props: ["myKeeps"],
    data() {
      return {
        selected: ""
      }
    }, //data
    computed: {
      userKeeps() {
        return this.$store.state.userKeeps
      },
      vaults() {
        return this.$store.state.vaults
      }
    }, //computed

    methods: {
      deleteKeep(id) {
        this.$store.dispatch("deleteKeep", id)
      },
      addToVault(payload) {
        let data = {
          vaultId: this.selected,
          keepId: payload
        }
        this.$store.dispatch("addKeepToVault", data)
      },
      // goPublic() {
      //   this.$store.dispatch("keepGoesPublic")
      // }
    }

  }
</script>

<style>
</style>