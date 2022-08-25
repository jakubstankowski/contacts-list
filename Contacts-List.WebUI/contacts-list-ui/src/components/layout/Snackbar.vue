<template>
  <div>
    <v-snackbar :color="color" v-model="snackbarStatus">
      {{ message }}
      <v-btn color="accent" text @click="snackbar = false"> Close </v-btn>
    </v-snackbar>
  </div>
</template>

<script>
export default {
  name: "Snackbar",
  props: {
    status: {
      required: true,
    },
    message: {
      required: true,
    },
    color: {
      required: true,
    },
  },
  computed: {
    snackbarStatus() {
      return this.status;
    },
  },
  data: () => ({}),
};
</script>

<style scoped></style>
