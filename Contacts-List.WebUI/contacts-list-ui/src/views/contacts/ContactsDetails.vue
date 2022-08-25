<template>
  <article class="text-center">
    <v-container
      class="grey lighten-5"
      fill-height
      fluid
      style="min-height: 75vh"
    >
      <v-layout align-center justify-center>
        <v-card class="mx-auto" max-width="600">
          <v-img
            src="https://cdn.vuetifyjs.com/images/lists/1.jpg"
            height="200px"
          ></v-img>
          <v-card-title> {{ CONTACT.displayName }}</v-card-title>
          <v-card-subtitle> Category: {{ CONTACT.category }} </v-card-subtitle>
          <v-card-subtitle> Email: {{ CONTACT.email }} </v-card-subtitle>
          <v-card-subtitle>
            Phone Number: {{ CONTACT.phoneNumber }}
          </v-card-subtitle>
          <v-card-subtitle>
            Date of birth: {{ CONTACT.dateOfBirth }}
          </v-card-subtitle>
        </v-card>
      </v-layout>
    </v-container>
    <v-btn class="text-center" color="primary" @click="$router.back()"
      >BACK TO LIST</v-btn
    >
  </article>
</template>
<script>
import { mapGetters } from "vuex";

export default {
  name: "Contacts Details",
  computed: {
    ...mapGetters(["CONTACT"]),
  },
  created() {
    this.$store.dispatch("GET_CONTACT", {
      contactId: this.$route.params.id,
    });
  },
  data: () => ({
    //
  }),
};
</script>
