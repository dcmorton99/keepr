<template>
  <div class="row">
    <div class="col m-4" v-for="keep in keeps" :value="keep.id">
      <div class="card m-2" id="publickeeps">
        <div class="card-body">
          <h3 class="card-title">{{keep.name}}</h3>
          <img :src="keep.img" class="card-img-top">
          <h5>{{keep.description}}</h5>
          <i class="far fa-eye m-1"> {{keep.views}} </i>
          <i class="fas fa-bullhorn m-1"> {{keep.shares}} </i>
          <i class="far fa-hdd m-1"> {{keep.keeps}} </i>
          <button type="button" class="btn btn-success m-2" @click="gotToKeep(keep.id)">Lookie!</button>
          <form @submit.prevent="addToVault(keep.id)">
            <select v-model="selected">
              <option disabled value>Add to a Vault</option>
              <option v-for="vault in vaults" :value="vault.id">{{vault.name}}
              </option>
            </select>
            <button type="submit">Submit</button>

          </form>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
  export default {
    name: 'PublicKeeps',
    data() {
      return {
        selected: ""
      }
    }, //data
    computed: {
      keeps() {
        return this.$store.state.keeps
      },
      vaults() {
        return this.$store.state.vaults
      }
    }, //computed
    methods: {
      addToVault(payload) {
        let data = {
          vaultId: this.selected,
          keepId: payload
        }
        this.$store.dispatch("addKeepToVault", data)
      },
    }, //methods
  }
</script>

<style>
  #publickeeps {
    background-color: lightgrey;
  }
</style>