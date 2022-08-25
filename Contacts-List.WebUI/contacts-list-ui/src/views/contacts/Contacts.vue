<template>
  <article>
    <h1 class="display-4 text-center">Contacts List</h1>
    <h3 class="display-2 text-center mt-5">
      <a @click="$router.push('/login')">Sign-In</a> For Manage
    </h3>
    <v-container class="grey lighten-5 mt-10" style="min-height: 90vh">
      <v-row no-gutters>
        <v-col
          cols="12"
          sm="4"
          v-for="(item, i) in CONTACTS"
          :key="i"
          class="pa-2"
        >
          <v-card class="pa-2" outlined tile>
            <v-list-item>
              <v-list-item-content>
                <v-list-item-title
                  v-text="item.displayName"
                ></v-list-item-title>
              </v-list-item-content>

              <v-list-item-avatar>
                <v-img
                  src="https://cdn.vuetifyjs.com/images/lists/1.jpg"
                ></v-img>
              </v-list-item-avatar> </v-list-item
          ></v-card>
        </v-col>
      </v-row>
    </v-container>
  </article>
</template>
<script>
import { mapGetters } from "vuex";

export default {
  name: "Contacts",
  computed: {
    ...mapGetters(["CONTACTS"]),
  },
  created() {
    this.$store.dispatch("GET_CONTACTS");
  },
  data: () => ({}),
};
</script>
