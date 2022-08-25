<template>
  <v-app>
    <AppBar />
    <v-main>
      <v-container>
        <router-view />
      </v-container>
    </v-main>
  </v-app>
</template>

<script>
import AppBar from "./components/layout/AppBar.vue";
export default {
  name: "App",
  data: () => ({
    //
  }),
  components: { AppBar },
};
</script>
