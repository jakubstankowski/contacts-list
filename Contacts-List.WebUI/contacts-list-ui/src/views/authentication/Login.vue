<template>
  <v-container fill-height fluid style="min-height: 90vh">
    <v-layout align-center justify-center>
      <v-flex xs12 sm8 md4>
        <v-card class="elevation-5">
          <v-toolbar>
            <v-toolbar-title>
              <span class="v-card-header"> Login to Manage Contacts </span>
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
                v-model="form.password"
                ref="password"
                prepend-icon="mdi-lock"
                type="password"
                label="Password"
                counter
                required
              />
            </v-form>
          </v-card-text>
          <v-divider class="mt-5" />
          <v-card-actions>
            <v-spacer />
            <v-btn align-center justify-center color="general">
              <router-link to="/register"> Register </router-link>
            </v-btn>
            <v-btn
              class="login-button"
              :disabled="!form.valid"
              @click="login"
              align-center
              justify-center
              color="general"
            >
              Login
            </v-btn>
          </v-card-actions>
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
<script lang="js">
import Vue from 'vue';
import Snackbar from "@/components/layout/Snackbar.vue";
import {snackbarMixin} from "@/mixins/snackbarMixin";
 import authService from '@/services/AuthService';


export default Vue.extend({
    mixins: [snackbarMixin],
    name: 'Login',
    components: { Snackbar},
    data: () => ({
        dialog: false,
        form: {
            lazy: false,
            valid: true,
            emailRules: [
                v => !!v || 'E-mail is required',
                v => /.+@.+\..+/.test(v) || 'E-mail must be valid',
            ],
            passwordRules: [
                v => !!v || 'Password is required',
                v => (v && v.length >= 6) || 'Password must be more, or equal than 6 characters',
            ],
        }
    }),
    methods: {
        login() {
            this.$store.dispatch("LOGIN", {
                email: this.form.email,
                password: this.form.password
            })
                .then(res => {
                    this.showAndHiddenSnackbar(
                        {
                            status: true,
                            message: res.message,
                            color: 'primary'
                        }
                    );
                   authService.saveAccessToken(res.tokens.accessToken);
                     authService.saveRefreshToken(res.tokens.refreshToken);
                     authService.saveUserDetails(res.user);

                     setTimeout(() => {
                         this.$router.push({name: 'app'});
                     }, 1000);
                })
                .catch((err) => {
                    console.error('err', err);
                    this.showAndHiddenSnackbar(
                        {
                            status: true,
                            message: 'Authorization error!',
                            color: 'error'
                        }
                    );
                })
        },
    }
});
</script>
<style type="text/css" scoped></style>
