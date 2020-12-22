import Vue from 'vue'
import Vuex from 'vuex'
import state from './state.js'
import mutations from './mutations.js'
import actions from './actions.js'
// import getters from './getters'
Vue.use(Vuex)
const store = new Vuex.Store({
  state: state,
  mutations: mutations,
  actions: actions,
  strict: process.env.NODE_ENV !== 'production'
})

export default store
