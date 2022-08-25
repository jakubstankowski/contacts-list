import Vue from "vue";
import VueRouter from "vue-router";

Vue.use(VueRouter);

const routes = [
  {
    path: "/",
    name: "Contacts",
    component: () => import("../views/contacts/Contacts.vue"),
  },
  {
    path: "/contact/:id",
    name: "Contacts Details",
    component: () => import("../views/contacts/ContactsDetails.vue"),
  },
  {
    path: "/login",
    name: "Login",
    component: () => import("../views/authentication/Login.vue"),
  },
  {
    path: "/register",
    name: "Register",
    component: () => import("../views/authentication/Register.vue"),
  },
];

const router = new VueRouter({
  routes,
});

export default router;
