<template>
  <v-app-bar app color="primary" dark>
    <v-toolbar-title @click="$router.push('/')">Contacts List</v-toolbar-title>
    <v-spacer></v-spacer>
    <span v-if="!AUTH_STATUS">
      <v-btn text>
        <span class="mr-2" @click="$router.push('/login')">Login</span>
      </v-btn>
      <v-btn text>
        <span class="mr-2" @click="$router.push('/register')">Register</span>
      </v-btn>
    </span>
    <span v-else>
      <v-btn text>
        <span class="mr-2" @click="logout()">Logout</span>
      </v-btn>
    </span>
  </v-app-bar>
</template>

<script>
import authService from "@/services/AuthService";
import { mapGetters } from "vuex";

export default {
  name: "AppBar",
  data: () => ({
    authStatus: false,
  }),
  computed: {
    ...mapGetters(["AUTH_STATUS"]),
  },
  methods: {
    logout() {
      this.$store.dispatch("LOGOUT");
      authService.clearAuthData();
      this.$router.push("/");
    },
  },
};
</script>
