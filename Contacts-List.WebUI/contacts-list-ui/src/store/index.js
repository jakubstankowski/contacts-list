import Vue from "vue";
import Vuex from "vuex";
import Auth from "./modules/auth.js";
import Contacts from "./modules/contacts.js";
import Category from "./modules/category.js";

Vue.use(Vuex);

export default new Vuex.Store({
  state: {},
  mutations: {},
  actions: {},
  modules: {
    auth: Auth,
    contacts: Contacts,
    category: Category,
  },
});
