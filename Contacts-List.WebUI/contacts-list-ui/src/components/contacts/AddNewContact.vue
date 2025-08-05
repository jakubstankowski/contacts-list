<template lang="html">
  <v-card>
    <v-toolbar dark color="primary">
      <v-toolbar-title>
        <span class="font-weight-light"> Add New Contact </span>
      </v-toolbar-title>
      <v-spacer />
      <v-btn @click="closeDialog" icon dark>
        <v-icon>mdi-close</v-icon>
      </v-btn>
    </v-toolbar>
    <v-container>
      <v-form ref="form" v-model="contactForm.valid">
        <v-row class="mx-2">
          <v-col cols="12" sm="6" md="6">
            <v-text-field
              v-model="contactForm.firstName"
              ref="firstName"
              label="First Name"
              required
              :rules="contactFormOptions.firstNameRules"
            />
          </v-col>
          <v-col cols="12" sm="6" md="6">
            <v-text-field
              v-model="contactForm.lastName"
              ref="lastName"
              label="Last Name"
              required
              :rules="contactFormOptions.lastNameRules"
            />
          </v-col>
          <v-col cols="12" sm="6" md="6">
            <v-text-field
              v-model="contactForm.email"
              ref="email"
              label="Email"
              type="email"
              required
              :rules="contactFormOptions.emailRules"
            />
          </v-col>
          <v-col cols="12" sm="6" md="6">
            <v-text-field
              v-model="contactForm.phoneNumber"
              ref="phoneNumber"
              label="Phone Number"
              required
              :rules="contactFormOptions.phoneNumberRules"
            />
          </v-col>
          <v-col cols="12" sm="6" md="6">
            <v-select
              v-model="contactForm.categoryId"
              :items="categories"
              item-text="name"
              item-value="categoryId"
              label="Category"
              required
              :rules="contactFormOptions.categoryRules"
            />
          </v-col>
          <v-col cols="12" sm="6" md="6">
            <v-menu
              ref="datePicker"
              v-model="datePicker"
              :close-on-content-click="false"
              :return-value.sync="contactForm.dateOfBirth"
              transition="scale-transition"
              offset-y
              min-width="290px"
            >
              <template v-slot:activator="{ on }">
                <v-text-field
                  v-model="contactForm.dateOfBirth"
                  label="Date of Birth"
                  required
                  readonly
                  v-on="on"
                  :rules="contactFormOptions.dateOfBirthRules"
                />
              </template>
              <v-date-picker
                color="primary"
                v-model="contactForm.dateOfBirth"
                no-title
                scrollable
              >
                <v-spacer />
                <v-btn text color="primary" @click="datePicker = false">
                  Cancel
                </v-btn>
                <v-btn
                  text
                  color="primary"
                  @click="$refs.datePicker.save(contactForm.dateOfBirth)"
                >
                  OK
                </v-btn>
              </v-date-picker>
            </v-menu>
          </v-col>
        </v-row>
      </v-form>
    </v-container>

    <v-card-actions>
      <v-spacer />
      <v-btn text color="secondary" @click="closeDialog">Cancel </v-btn>
      <v-btn
        :disabled="!contactForm.valid"
        @click="addNewContact"
        color="secondary"
        text
      >
        Add
      </v-btn>
    </v-card-actions>
  </v-card>
</template>

<script lang="js">
import { mapGetters } from "vuex";

const form = {
    contactId: 0,
    firstName: '',
    lastName: '',
    email: '',
    phoneNumber: '',
    categoryId: null,
    dateOfBirth: new Date().toISOString().substr(0, 10)
};

export default {
    name: 'add-new-contact',
    props: {},
    computed: {
        ...mapGetters(["CATEGORY"]),
        categories() {
            return this.CATEGORY || [];
        }
    },
    data() {
        return {
            datePicker: false,
            contactFormOptions: {
                firstNameRules: [
                    v => !!v || 'First name is required',
                ],
                lastNameRules: [
                    v => !!v || 'Last name is required',
                ],
                emailRules: [
                    v => !!v || 'Email is required',
                    v => /.+@.+\..+/.test(v) || 'Email must be valid'
                ],
                phoneNumberRules: [
                    v => !!v || 'Phone number is required',
                ],
                categoryRules: [
                    v => !!v || 'Category is required',
                ],
                dateOfBirthRules: [
                    v => !!v || 'Date of birth is required',
                ]
            },
            contactForm: Object.assign({}, form),
        }
    },
    methods: {
        addNewContact() {
            this.$store.dispatch("ADD_CONTACT", { form: this.contactForm })
                .then(() => {
                    this.closeDialog();
                    this.$store.dispatch("GET_CONTACTS");
                })
                .catch((error) => {
                    console.error("Error adding contact:", error);
                });
        },
        closeDialog() {
            this.$emit('closeDialog', 'createContact');
            this.resetForm();
        },
        resetForm() {
            this.contactForm = Object.assign({}, form);
            if (this.$refs.form) {
                this.$refs.form.reset();
            }
        },
    },
}
</script>

<style scoped lang="scss">
.card-title {
  color: white;
}
</style>
