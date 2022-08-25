<template>
  <article>
    <h3 class="display-2 text-center mt-5">
      Welcome <a>{{ userMail }}</a>
    </h3>
    <h3 class="display-1 text-center mt-5">Add new contact, or manage exist</h3>
    <v-form>
      <v-container>
        <v-row>
          <v-col cols="12" md="4">
            <v-text-field
              v-model="form.firstName"
              label="First name"
              required
            ></v-text-field>
          </v-col>
          <v-col cols="12" md="4">
            <v-text-field
              label="Last name"
              v-model="form.lastName"
              required
            ></v-text-field>
          </v-col>

          <v-col cols="12" md="4">
            <v-text-field
              v-model="form.email"
              label="E-mail"
              required
            ></v-text-field>
          </v-col>
        </v-row>
        <v-row>
          <v-col cols="12" md="4">
            <v-text-field
              v-model="form.phoneNumber"
              label="Phone number"
              required
            ></v-text-field>
          </v-col>
          <v-col cols="12" md="4">
            <v-select
              v-model="form.categoryId"
              :items="CATEGORY"
              item-text="name"
              item-value="categoryId"
              label="Category"
            ></v-select>
          </v-col>
          <v-col cols="12" md="4">
            <v-btn
              class="w-100 mt-3"
              style="width: 100%"
              color="primary"
              @click="saveForm()"
            >
              Add new contact
            </v-btn>
          </v-col>
        </v-row>
        <v-row> </v-row>
      </v-container>
    </v-form>
    <v-container class="grey lighten-5 mt-10" style="min-height: 90vh">
      <v-row no-gutters>
        <v-col
          cols="12"
          sm="6"
          v-for="(item, i) in CONTACTS"
          :key="i"
          class="pa-2"
        >
          <ContactCard
            :contactId="item.contactId"
            :displayName="item.displayName"
            manage-icons
            @deleteContact="handleDeleteContact($event)"
          />
        </v-col>
      </v-row>
    </v-container>
    <Snackbar
      v-bind:color="snackbar.color"
      v-bind:message="snackbar.message"
      v-bind:status="snackbar.status"
    />
  </article>
</template>
<script>
import { mapGetters } from "vuex";
import ContactCard from "../../components/ContactCard.vue";
import authService from "@/services/AuthService";
import Snackbar from "@/components/layout/Snackbar.vue";
import { snackbarMixin } from "@/mixins/snackbarMixin";

const formShape = {
  contactId: 0,
  firstName: "",
  lastName: "",
  email: "",
  phoneNumber: null,
  categoryId: null,
  dateOfBirth: new Date(),
};

export default {
  name: "Contacts",
  mixins: [snackbarMixin],
  components: { Snackbar, ContactCard },
  computed: {
    ...mapGetters(["CONTACTS"]),
    ...mapGetters(["CATEGORY"]),
  },
  created() {
    this.$store.dispatch("GET_CONTACTS");
    this.$store.dispatch("GET_CATEGORY");
  },
  data: () => ({
    userMail: authService.getUserEmail(),
    form: { ...formShape },
  }),
  methods: {
    async saveForm() {
      try {
        await this.$store.dispatch("ADD_CONTACT", {
          form: { ...this.form },
        });

        this.showAndHiddenSnackbar({
          status: true,
          message: "Success add new contact",
          color: "primary",
        });

        await this.$store.dispatch("GET_CONTACTS");

        this.form = { ...formShape };
      } catch (err) {
        console.error("err", err);
        this.showAndHiddenSnackbar({
          status: true,
          message: "Error!",
          color: "error",
        });
      }
    },
    async handleDeleteContact(contactId) {
      try {
        await this.$store.dispatch("DELETE_CONTACT", {
          contactId: contactId,
        });

        this.showAndHiddenSnackbar({
          status: true,
          message: "Success delete contact",
          color: "primary",
        });

        await this.$store.dispatch("GET_CONTACTS");
      } catch (err) {
        console.error("err", err);
        this.showAndHiddenSnackbar({
          status: true,
          message: "Error!",
          color: "error",
        });
      }
    },
  },
};
</script>
