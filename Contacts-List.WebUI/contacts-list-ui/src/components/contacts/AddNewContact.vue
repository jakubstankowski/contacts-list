<template lang="html">
  <v-card>
    <v-toolbar dark color="primary">
      <v-toolbar-title>
        <span class="font-weight-light"> Add New Car </span>
      </v-toolbar-title>
      <v-spacer />
      <v-btn @click="closeDialog" icon dark>
        <v-icon>mdi-close</v-icon>
      </v-btn>
    </v-toolbar>
    <v-container>
      <v-form ref="form" v-model="carForm.valid">
        <v-row class="mx-2">
          <v-col cols="12" sm="6" md="6">
            <v-text-field
              v-model="carForm.brand"
              ref="brand"
              label="Brand"
              required
              :rules="carFormOptions.brandRules"
            />
          </v-col>
          <v-col cols="12" sm="6" md="6">
            <v-text-field
              v-model="carForm.model"
              ref="model"
              label="Model"
              required
              :rules="carFormOptions.modelRules"
            />
          </v-col>
          <v-col cols="12" sm="6" md="6">
            <v-text-field
              v-model="carForm.year"
              ref="year"
              label="Year"
              type="number"
              required
              :rules="carFormOptions.yearRules"
            />
          </v-col>
          <v-col cols="12" sm="6" md="6">
            <v-select
              v-model="carForm.status"
              :items="['transport', 'services', 'sale']"
              label="Status"
              required
              :rules="carFormOptions.statusRules"
            />
          </v-col>
          <v-col cols="12" sm="6" md="6">
            <v-text-field
              v-model="carForm.buyPrice"
              ref="year"
              label="Buy Price"
              required
              type="number"
              :rules="carFormOptions.buyPriceRules"
            />
          </v-col>
          <v-col cols="12" sm="6" md="6">
            <v-menu
              ref="datePicker"
              v-model="datePicker"
              :close-on-content-click="false"
              :return-value.sync="carForm.date"
              transition="scale-transition"
              offset-y
              min-width="290px"
            >
              <template v-slot:activator="{ on }">
                <v-text-field
                  v-model="carForm.date"
                  label="Buy Date"
                  required
                  readonly
                  v-on="on"
                />
              </template>
              <v-date-picker
                color="primary"
                v-model="carForm.date"
                locale="pl"
                no-title
                scrollable
              >
                <v-spacer />
                <v-btn text color="primary" @click="datePicker = false"
                  >Cancel</v-btn
                >
                <v-btn
                  text
                  color="primary"
                  @click="$refs.datePicker.save(carForm.date)"
                  >OK</v-btn
                >
              </v-date-picker>
            </v-menu>
          </v-col>
          <v-col cols="12" sm="6" md="6">
            <v-text-field
              v-model="carForm.actuallSellPrice"
              ref="year"
              type="number"
              label="Actuall Sell Price (optional)"
            />
          </v-col>
          <v-col cols="12" sm="6" md="6">
            <v-text-field
              v-model="carForm.imageUrl"
              type="text"
              label="Image Url (optional)"
            />
          </v-col>
        </v-row>
      </v-form>
    </v-container>

    <v-card-actions>
      <v-spacer />
      <v-btn text color="secondary" @click="closeDialog">Cancel </v-btn>
      <v-btn
        :disabled="!carForm.valid"
        @click="addNewCar"
        color="secondary"
        text
      >
        Add
      </v-btn>
    </v-card-actions>
  </v-card>
</template>

<script lang="js">
import authService from "@/services/AuthService";

const form = {
    brand: '',
    model: '',
    year: '',
    status: '',
    buyPrice: '',
    actuallSellPrice: '',
    date: new Date().toISOString().substr(0, 10),
    imageUrl: ''
};
export default {

    name: 'create-new-car',
    props: {},
    data() {
        return {
            datePicker: false,
            carFormOptions: {
                brandRules: [
                    v => !!v || 'Brand is required',
                ],
                modelRules: [
                    v => !!v || 'Model is required',
                ],
                yearRules: [
                    v => !!v || 'Year is required',
                ],
                buyPriceRules: [
                    v => !!v || 'Buy Prices is required',
                ],
                statusRules: [
                    v => !!v || 'Status is required',
                ]
            },
            carForm: Object.assign({}, form),
        }
    },
    methods: {
        addNewCar() {
            this.$store.dispatch("ADD_CAR", {userId: authService.getUserId(), form: this.carForm})
                .then(() => {
                    this.closeDialog();
                })

        },
        closeDialog() {
            this.$emit('closeDialog', 'createCar');
            this.resetForm();
        },
        resetForm() {
            this.$refs.form.reset();
        },
    },
}
</script>

<style scoped lang="scss">
.card-title {
  color: white;
}
</style>
