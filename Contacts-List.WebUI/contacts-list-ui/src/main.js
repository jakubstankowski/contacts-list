import Vue from "vue";
import App from "./App.vue";
import router from "./router";
import store from "./store";
import vuetify from "./plugins/vuetify";
import axios from "axios";
Vue.filter("date", Date);
import authService from "./services/AuthService";

Vue.config.productionTip = false;

axios.defaults.baseURL = "https://localhost:7104/api/";

router.beforeEach((to, from, next) => {
  if (to.matched.some((record) => record.meta.requiresAuth)) {
    if (!authService.getAuthData()) {
      next({
        name: "home",
      });
    } else {
      next();
    }
  } else if (to.matched.some((record) => record.meta.requiresVisitor)) {
    if (authService.getAuthData()) {
      next({
        name: "home",
      });
    } else {
      next();
    }
  } else {
    next();
  }
});

new Vue({
  router,
  store,
  vuetify,
  render: (h) => h(App),
}).$mount("#app");
