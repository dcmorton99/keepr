import Vue from 'vue'
import Vuex from 'vuex'
import Axios from 'axios'
import router from './router'
import AuthService from './AuthService'

Vue.use(Vuex)

let baseUrl = location.host.includes('localhost') ? '//localhost:5000/' : '/'

let api = Axios.create({
  baseURL: baseUrl + "api/",
  timeout: 3000,
  withCredentials: true
})

export default new Vuex.Store({
  state: {
    user: {},
    vaults: [],
    vault: {},
    keeps: [],
    userKeeps: [],
    vaultKeeps: [],
    keep: {}
    //make sure to blow away vaults at logout
  },
  mutations: {
    setUser(state, user) {
      state.user = user
    },
    resetState(state) {
      //clear the entire state object of user data
      state.user = {}
      state.vaults = []
      state.vault = {}
      state.keeps = []
      state.userKeeps = []
      state.vaultKeeps = []
      state.keep = {}
    },

    setVaults(state, data) {
      state.vaults = data
    },

    setVault(state, data) {
      state.vault = data
    },

    setPublicKeeps(state, data) {
      state.keeps = data
    },
    setUserKeeps(state, data) {
      state.userKeeps = data
    },
    setVaultKeeps(state, data) {
      state.vaultKeeps = data
    }
  },

  actions: {

    async register({ commit, dispatch }, creds) {
      try {
        let user = await AuthService.Register(creds)
        commit('setUser', user)
        router.push({ name: "home" })
      } catch (e) {
        console.warn(e.message)
      }
    },
    async login({ commit, dispatch }, creds) {
      try {
        let user = await AuthService.Login(creds)
        commit('setUser', user)
        router.push({ name: "home" })
      } catch (e) {
        console.warn(e.message)
      }
    },
    async logout({ commit, dispatch }) {
      try {
        let success = await AuthService.Logout()
        if (!success) { }
        commit('resetState')
        router.push({ name: "login" })
      } catch (e) {
        console.warn(e.message)
      }
    },

    async getVaults({ commit, dispatch }) {
      try {
        let res = await api.get('vaults')
        commit('setVaults', res.data)
        console.log(res)
      } catch (error) { console.log(error) }
    },

    async getVault({ commit, dispatch }, id) {
      try {
        let res = await api.get('vaults/' + id)
        commit('setVault', res.data)
        console.log(res)
        router.push({ name: 'vault', params: { id: id } })
      } catch (error) { console.log(error) }
    },

    createVault({ commit, dispatch }, payload) {
      api.post('vaults', payload)
        .then(res => {
          dispatch("getVaults")
        })
    },
    deleteVault({ commit, dispatch }, id) {
      api.delete('vaults/' + id)
        .then(res => {
          dispatch('getVaults')
        })
    },

    getPublicKeeps({ commit, dispatch }) {
      api.get('keeps')
        .then(res => {
          commit('setPublicKeeps', res.data)
        })
    },
    async getUserKeeps({ commit, dispatch }) {
      try {
        let res = await api.get('keeps/user')
        commit('setUserKeeps', res.data)
      } catch (error) { console.log(error) }
    },
    createKeep({ commit, dispatch }, payload) {
      api.post('keeps', payload)
        .then(res => {
          commit('getUserKeeps')
        })
    },
    deleteKeep({ commit, dispatch }, id) {
      api.delete('keeps/' + id)
        .then(res => {
          dispatch('getUserKeeps')
        })
    },
    updateKeep({ commit, dispatch }, payload) {
      api.put('keeps/' + payload.id, payload)
        .then(res => {
          dispatch('getPublicKeeps')
        })
    },

    async getVaultKeeps({ commit, dispatch }, vaultId) {
      try {
        let res = await api.get('vaultkeeps/' + vaultId)
        commit('setVaultKeeps', res.data)
        console.log(res)
      } catch (error) { console.log(error) }
    },

    addKeepToVault({ commit, dispatch }, data) {
      api.post('vaultkeeps', data)
        .then(res => {
          commit('getVaultKeeps', data.vaultId)
        })
    },
    deleteVaultKeep({ commit, dispatch }, payload) {
      api.put('vaultkeeps/', payload)
        .then(res => {
          dispatch('getVaultKeeps', payload.vaultId)
        })
    }
  }
})
