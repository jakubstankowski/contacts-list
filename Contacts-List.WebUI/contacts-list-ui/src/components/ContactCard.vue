<template>
  <v-card class="pa-2" outlined tile>
    <v-list-item>
      <v-list-item-content>
        <v-list-item-title v-text="displayName"></v-list-item-title>
      </v-list-item-content>
      <span v-if="manageIcons">
        <v-list-item-icon>
          <v-btn icon>
            <v-icon>mdi-pencil</v-icon>
          </v-btn>
        </v-list-item-icon>
        <v-list-item-icon>
          <v-btn icon @click="deleteContact()">
            <v-icon>mdi-delete</v-icon>
          </v-btn>
        </v-list-item-icon>
        <v-list-item-icon>
          <v-btn icon @click="$router.push(`/contacts/${contactId}`)">
            <v-icon>mdi-magnify</v-icon>
          </v-btn>
        </v-list-item-icon>
      </span>
      <v-list-item-avatar>
        <v-img src="https://cdn.vuetifyjs.com/images/lists/1.jpg"></v-img>
      </v-list-item-avatar>
    </v-list-item>
  </v-card>
</template>

<script>
export default {
  name: "ContactCard",
  props: {
    displayName: {
      type: String,
    },
    manageIcons: {
      type: Boolean,
      default: false,
    },
    contactId: {
      type: Number,
    },
  },
  data: () => ({
    //
  }),
  methods: {
    deleteContact() {
      this.$emit("deleteContact", this.contactId);
    },
  },
};
</script>
