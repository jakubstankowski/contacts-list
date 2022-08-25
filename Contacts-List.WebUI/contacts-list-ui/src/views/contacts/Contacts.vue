<template>
  <article>
    <v-list>
      <v-list-item v-for="item in items" :key="item.title">
        <v-list-item-icon>
          <v-icon v-if="item.icon" color="pink"> mdi-star </v-icon>
        </v-list-item-icon>

        <v-list-item-content>
          <v-list-item-title v-text="item.title"></v-list-item-title>
        </v-list-item-content>

        <v-list-item-avatar>
          <v-img :src="item.avatar"></v-img>
        </v-list-item-avatar>
      </v-list-item>
    </v-list>
  </article>
</template>

<script>
import { mapGetters } from "vuex";

export default {
  name: "Contacts",
  ...mapGetters(["CONTACTS"]),
  created() {
    this.$store.dispatch("GET_CONTACTS");
  },
  data: () => ({
    items: [
      {
        icon: true,
        title: "Jason Oner",
        avatar: "https://cdn.vuetifyjs.com/images/lists/1.jpg",
      },
      {
        title: "Travis Howard",
        avatar: "https://cdn.vuetifyjs.com/images/lists/2.jpg",
      },
      {
        title: "Ali Connors",
        avatar: "https://cdn.vuetifyjs.com/images/lists/3.jpg",
      },
      {
        title: "Cindy Baker",
        avatar: "https://cdn.vuetifyjs.com/images/lists/4.jpg",
      },
    ],
  }),
};
</script>
