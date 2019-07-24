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

    createVault({ commit, dispatch }, payload) {
      api.post('vaults', payload)
        .then(res => {
          commit("getVaults")
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
    }
  }
})
