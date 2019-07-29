<template>

  <div class="col">
    <div class="card m-2" id="publickeeps">
      <div class="card-body">
        <h3 class="card-title">{{publicKeeps.name}}</h3>
        <img :src="publicKeeps.img" class="card-img-top">
        <h5>{{publicKeeps.description}}</h5>
        <button class="btn-sm btn-secondary m-1">Views: {{publicKeeps.views}}</button>
        <button class="btn-sm btn-secondary m-1" @click="">Shares: {{publicKeeps.shares}}</button>
        <button class="btn-sm btn-secondary m-1">Keeps: {{publicKeeps.keeps}}</button>
        <form @submit.prevent="addToVault(publicKeeps.id)">
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
    name: 'PublicKeeps',
    props: ["publicKeeps"],
    data() {
      return {
        selected: ""
      }
    }, //data
    computed: {
      vaults() {
        return this.$store.state.vaults
      },
      keeps() {
        return this.$store.state.keeps
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