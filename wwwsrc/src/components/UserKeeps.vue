<template>
  <div class="row">
    <div class="col" v-for="keep in userKeeps" :value="keep.id">
      <div class="card m-2">
        <div class="card-body">
          <img :src="keep.img" class="card-img-top">
          <h3 class="card-title">{{keep.name}}</h3>
          <h5>{{keep.description}}</h5>
          <i class="far fa-eye m-1"> {{keep.views}} </i>
          <i class="fas fa-bullhorn m-1"> {{keep.shares}} </i>
          <i class="far fa-hdd m-1"> {{keep.keeps}} </i>
          <button v-show="keep.isPrivate == true" type="button" class="btn btn-secondary m-2"
            @click="deleteKeep(keep.id)"><i class="far fa-trash-alt"></i></button>
          <form @submit.prevent="addToVault(keep.id)">
            <select v-model="selected">
              <option disabled value>Add to a Vault</option>
              <option v-for="vault in vaults" :value="vault.id">{{vault.name}}
              </option>
            </select>
            <button class="btn-sm btn-info m-2" type="submit">Submit</button>
            <button class="btn btn-warning" @click="goPublic(keep.isPrivate == false)">Go public baby!</button>
          </form>
        </div>
      </div>
    </div>
  </div>

</template>

<script>
  export default {
    name: 'UserKeeps',
    data() {
      return {
        selected: ""
        // isPrivate = true,
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
    mounted() {
      this.$store.dispatch("getUserKeeps")
      this.$store.dispatch("getVaults")
    }, //mounted
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
      goPublic() {
        this.$store.dispatch("keepGoesPublic")
      }
    }

  }
</script>

<style>
</style>