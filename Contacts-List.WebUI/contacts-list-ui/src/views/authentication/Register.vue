<template>
  <v-container fill-height fluid style="min-height: 90vh">
    <v-layout align-center justify-center>
      <v-flex xs12 sm8 md4>
        <v-card class="elevation-12">
          <v-toolbar>
            <v-toolbar-title>
              <span class="v-card-header"> Register to Manage Contacts </span>
            </v-toolbar-title>
            <v-spacer />
          </v-toolbar>
          <v-card-text>
            <v-form v-model="form.valid" :lazy-validation="form.lazy">
              <v-text-field
                v-model="form.email"
                ref="email"
                prepend-icon="mdi-account"
                label="Email"
                required
              />
              <v-text-field
                autocomplete
                type="password"
                v-model="form.password"
                ref="password"
                prepend-icon="mdi-lock"
                label="Password"
                counter
                required
              />
            </v-form>
          </v-card-text>
          <v-divider class="mt-5" />
          <v-card-actions>
            <v-spacer />
            <v-btn
              :disabled="!form.valid"
              @click="register"
              align-center
              justify-center
              color="general"
              >Register
            </v-btn>
          </v-card-actions>
          <v-snackbar :top="true"> </v-snackbar>
        </v-card>
      </v-flex>
      <Snackbar
        v-bind:color="snackbar.color"
        v-bind:message="snackbar.message"
        v-bind:status="snackbar.status"
      />
    </v-layout>
  </v-container>
</template>
<script lang="ts">
import Vue from "vue";
import Snackbar from "@/components/layout/Snackbar.vue";
import { snackbarMixin } from "@/mixins/snackbarMixin";

export default Vue.extend({
  mixins: [snackbarMixin],
  components: { Snackbar },
  name: "Register",
  data: () => ({
    dialog: false,
    form: {
      valid: true,
      lazy: false,
      email: "",
      password: "",
      emailRules: [
        (v) => !!v || "E-mail is required",
        (v) => /.+@.+\..+/.test(v) || "E-mail must be valid",
      ],
      passwordRules: [
        (v) => !!v || "Password is required",
        (v) =>
          (v && v.length >= 6) ||
          "Password must be more, or equal than 6 characters",
      ],
    },
  }),
  methods: {
    register() {
      this.$store
        .dispatch("REGISTER", {
          email: this.form.email,
          password: this.form.password,
        })
        .then((res) => {
          this.showAndHiddenSnackbar({
            status: true,
            message: res.message,
            color: "primary",
          });
          setTimeout(() => {
            this.$router.push({ name: "login" });
          }, 1000);
        })
        .catch((err) => {
          console.log("err", err);
          this.showAndHiddenSnackbar({
            status: true,
            message: err,
            color: "error",
          });
        });
    },
  },
});
</script>
<style type="text/css" scoped></style>
