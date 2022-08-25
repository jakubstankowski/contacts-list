<template>
  <v-app-bar app color="primary" dark>
    <v-toolbar-title @click="$router.push('/')">Contacts List</v-toolbar-title>
    <v-spacer></v-spacer>
    <v-btn text>
      <span class="mr-2" @click="$router.push('/login')">Login</span>
    </v-btn>
    <v-btn text>
      <span class="mr-2" @click="$router.push('/register')">Register</span>
    </v-btn>
  </v-app-bar>
</template>

<script>
export default {
  name: "AppBar",

  data: () => ({
    //
  }),
};
</script>
