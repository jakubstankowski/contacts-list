import Vue from "vue";
import VueRouter from "vue-router";

Vue.use(VueRouter);

const routes = [
  {
    path: "/",
    name: "home",
    component: () => import("../views/Home.vue"),
  },
  {
    path: "/contacts",
    name: "contacts",
    component: () => import("../views/contacts/Contacts.vue"),
    meta: {
      requiresAuth: true,
    },
  },
  {
    path: "/contacts/:id",
    name: "contacts details",
    component: () => import("../views/contacts/ContactsDetails.vue"),
    meta: {
      requiresAuth: true,
    },
  },
  {
    path: "/login",
    name: "login",
    component: () => import("../views/authentication/Login.vue"),
  },
  {
    path: "/register",
    name: "register",
    component: () => import("../views/authentication/Register.vue"),
  },
];

const router = new VueRouter({
  routes,
});

export default router;
