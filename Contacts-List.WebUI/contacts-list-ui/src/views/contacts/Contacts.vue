<template>
  <article>
    <!-- Header Section -->
    <div class="text-center my-8">
      <h2 class="display-1 font-weight-bold">Welcome, <span class="text-primary">{{ userMail }}</span></h2>
      <p class="subtitle-1 text-grey mt-2">
        Manage your contacts easily — add new ones or edit existing entries.
      </p>
    </div>

    <!-- Form Section -->
    <v-container>
      <v-card class="pa-6 elevation-3 rounded-lg">
        <v-card-title class="text-h5 font-weight-bold">
          {{ isEditing ? 'Edit Contact' : 'Add New Contact' }}
        </v-card-title>
        <v-card-text>
          <v-form ref="contactForm" v-model="formValid">
            <v-row dense>
              <v-col cols="12" md="4">
                <v-text-field
                  v-model="form.firstName"
                  label="First Name"
                  outlined
                  dense
                  :rules="[v => !!v || 'First name is required']"
                />
              </v-col>
              <v-col cols="12" md="4">
                <v-text-field
                  v-model="form.lastName"
                  label="Last Name"
                  outlined
                  dense
                  :rules="[v => !!v || 'Last name is required']"
                />
              </v-col>
              <v-col cols="12" md="4">
                <v-text-field
                  v-model="form.email"
                  label="Email"
                  outlined
                  dense
                  :rules="[
                    v => !!v || 'Email is required',
                    v => /.+@.+\..+/.test(v) || 'Enter a valid email'
                  ]"
                />
              </v-col>
            </v-row>

            <v-row dense>
              <v-col cols="12" md="4">
                <v-text-field
                  v-model="form.phoneNumber"
                  label="Phone Number"
                  outlined
                  dense
                  :rules="[v => !!v || 'Phone number is required']"
                />
              </v-col>
              <v-col cols="12" md="4">
                <v-select
                  v-model="form.categoryId"
                  :items="CATEGORY"
                  item-text="name"
                  item-value="categoryId"
                  label="Category"
                  outlined
                  dense
                  :rules="[v => !!v || 'Category is required']"
                />
              </v-col>
              <v-col cols="12" md="4">
                <v-menu
                  ref="datePicker"
                  v-model="datePicker"
                  :close-on-content-click="false"
                  :return-value.sync="form.dateOfBirth"
                  transition="scale-transition"
                  offset-y
                  min-width="290px"
                >
                  <template v-slot:activator="{ on }">
                    <v-text-field
                      v-model="form.dateOfBirth"
                      label="Date of Birth"
                      outlined
                      dense
                      readonly
                      v-on="on"
                      :rules="[v => !!v || 'Date of birth is required']"
                    />
                  </template>
                  <v-date-picker
                    color="primary"
                    v-model="form.dateOfBirth"
                    scrollable
                  >
                    <v-spacer />
                    <v-btn text color="primary" @click="datePicker = false">Cancel</v-btn>
                    <v-btn text color="primary" @click="$refs.datePicker.save(form.dateOfBirth)">OK</v-btn>
                  </v-date-picker>
                </v-menu>
              </v-col>
            </v-row>

            <!-- Actions -->
            <v-row dense class="mt-4">
              <v-col cols="12" md="4">
                <v-btn
                  block
                  color="primary"
                  class="elevation-1"
                  :disabled="!formValid"
                  @click="saveForm()"
                >
                  <v-icon left>mdi-content-save</v-icon>
                  {{ isEditing ? 'Update Contact' : 'Add Contact' }}
                </v-btn>
              </v-col>

              <v-col cols="12" md="4" v-if="isEditing">
                <v-btn
                  block
                  color="secondary"
                  class="elevation-1"
                  @click="cancelEdit()"
                >
                  <v-icon left>mdi-close</v-icon>
                  Cancel Edit
                </v-btn>
              </v-col>

              <v-col cols="12" md="4">
                <v-btn
                  block
                  color="info"
                  class="elevation-1"
                  @click="getFirstContact()"
                >
                  <v-icon left>mdi-account-search</v-icon>
                  Get First Contact
                </v-btn>
              </v-col>
            </v-row>
          </v-form>
        </v-card-text>
      </v-card>
    </v-container>

    <!-- Contact List Section -->
    <v-container class="mt-10">
      <h3 class="text-h5 font-weight-bold mb-4">Your Contacts</h3>
      <v-row>
        <v-col
          cols="12"
          sm="6"
          md="4"
          v-for="(item, i) in CONTACTS"
          :key="i"
        >
          <ContactCard
            :contactId="item.contactId"
            :firstName="item.firstName"
            :lastName="item.lastName"
            manage-icons
            @deleteContact="handleDeleteContact($event)"
            @editContact="handleEditContact($event)"
          />
        </v-col>
      </v-row>
    </v-container>

    <!-- Snackbar -->
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
  phoneNumber: "",
  categoryId: null,
  dateOfBirth: new Date().toISOString().substr(0, 10),
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
    formValid: false,
    datePicker: false,
    isEditing: false,
  }),
  methods: {
    async saveForm() {
      try {
        if (this.isEditing) {
          await this.$store.dispatch("UPDATE_CONTACT", {
            form: { ...this.form },
          });

          this.showAndHiddenSnackbar({
            status: true,
            message: "Success update contact",
            color: "primary",
          });
        } else {
          await this.$store.dispatch("ADD_CONTACT", {
            form: { ...this.form },
          });

          this.showAndHiddenSnackbar({
            status: true,
            message: "Success add new contact",
            color: "primary",
          });
        }

        await this.$store.dispatch("GET_CONTACTS");
        this.resetForm();
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
    async handleEditContact(contactId) {
      try {
        // Get the contact details to populate the form
        await this.$store.dispatch("GET_CONTACT", {
          contactId: contactId,
        });
        
        const contact = this.$store.getters.CONTACT;

        console.log("contact", contact);

        if (contact) {
          this.form = {
            contactId: contact.contactId,
            firstName: contact.firstName || "",
            lastName: contact.lastName || "",
            email: contact.email || "",
            phoneNumber: contact.phoneNumber || "",
            categoryId: contact.categoryId,
            dateOfBirth: contact.dateOfBirth ? new Date(contact.dateOfBirth).toISOString().substr(0, 10) : new Date().toISOString().substr(0, 10),
          };
          this.isEditing = true;
          
          this.showAndHiddenSnackbar({
            status: true,
            message: "Contact loaded for editing",
            color: "info",
          });
        }
      } catch (err) {
        console.error("err", err);
        this.showAndHiddenSnackbar({
          status: true,
          message: "Error loading contact for edit!",
          color: "error",
        });
      }
    },
    async getFirstContact() {
      try {
        if (this.CONTACTS && this.CONTACTS.length > 0) {
          const firstContact = this.CONTACTS[0];
          await this.$store.dispatch("GET_CONTACT", {
            contactId: firstContact.contactId,
          });
          
          this.showAndHiddenSnackbar({
            status: true,
            message: `First contact: ${firstContact.firstName} ${firstContact.lastName}`,
            color: "info",
          });
          
          // Navigate to contact details
          this.$router.push(`/contacts/${firstContact.contactId}`);
        } else {
          this.showAndHiddenSnackbar({
            status: true,
            message: "No contacts available",
            color: "warning",
          });
        }
      } catch (err) {
        console.error("err", err);
        this.showAndHiddenSnackbar({
          status: true,
          message: "Error getting first contact!",
          color: "error",
        });
      }
    },
    cancelEdit() {
      this.resetForm();
    },
    resetForm() {
      this.form = { ...formShape };
      this.isEditing = false;
      this.formValid = false;
      if (this.$refs.contactForm) {
        this.$refs.contactForm.reset();
      }
    },
  },
};
</script>
