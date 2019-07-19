import Vue from 'vue'
import App from './App.vue'
import router from './router'
import store from './store'
import AuthService from "./AuthService"

//Vue.config.productionTip = false

async function init() {
  let user = await AuthService.Authenticate() //when init first fires up, try to go get a user, user await auth service
  if (user) { store.commit("setUser", user) } //
  new Vue({
    router,
    store,
    render: h => h(App)
  }).$mount('#app')
}
init()

