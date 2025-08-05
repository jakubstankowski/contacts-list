<template>
  <article>
    <h1 class="display-4 text-center">Contacts List</h1>
    <h3 class="display-2 text-center mt-5">
      <a @click="$router.push('/login')">Sign-In</a> For Manage and show details
    </h3>
    <v-container class="grey lighten-5 mt-10" style="min-height: 90vh">
      <v-row no-gutters>
        <v-col
          cols="12"
          sm="6"
          v-for="(item, i) in CONTACTS"
          :key="i"
          class="pa-2"
        >
          <ContactCard :firstName="item.firstName" :lastName="item.lastName" />
        </v-col>
      </v-row>
    </v-container>
  </article>
</template>
<script>
import { mapGetters } from "vuex";
import authService from "@/services/AuthService";
import ContactCard from "../components/ContactCard.vue";

export default {
  name: "Home",
  computed: {
    ...mapGetters(["CONTACTS"]),
    authStatus() {
      return authService.getAuthData() ? true : false;
    },
  },
  created() {
    this.$store.dispatch("GET_CONTACTS");
  },
  data: () => ({}),
  components: { ContactCard },
};
</script>
