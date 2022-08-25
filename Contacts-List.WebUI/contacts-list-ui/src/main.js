import Vue from "vue";
import App from "./App.vue";
import router from "./router";
import store from "./store";
import vuetify from "./plugins/vuetify";
import axios from "axios";
Vue.filter("date", Date);

Vue.config.productionTip = false;

axios.defaults.baseURL = "https://localhost:7104/api/";

new Vue({
  router,
  store,
  vuetify,
  render: (h) => h(App),
}).$mount("#app");
