import axios from "axios";
import errorParser from "@/utils/error-parser";

function initialState() {
  return {
    contacts: [],
    contact: "",
  };
}

export default {
  state: initialState(),
  getters: {
    CONTACTS: (state) => {
      return state.contacts;
    },
    CONTACT: (state) => {
      return state.contact;
    },
  },
  mutations: {
    SET_CONTACTS(state, payload) {
      state.contacts = payload;
    },
    SET_CONTACT(state, payload) {
      state.contact = payload;
    },
    NEW_CAR(state, car) {
      state.cars.unshift(car);
    },
    REMOVE_CAR(state, id) {
      state.cars = state.cars.filter((car) => car._id !== id);
    },
    RESET(state) {
      const s = initialState();
      Object.keys(s).forEach((key) => {
        state[key] = s[key];
      });
    },
  },
  actions: {
    GET_CONTACTS: () => {
      return new Promise((resolve, reject) => {
        axios
          .get(`Contacts/GettAllContacts`)
          .then(({ data }) => {
            console.log("data: ", data);
            //context.commit("SET_CONTACTS", data.cars);
            resolve(data);
          })
          .catch((error) => {
            reject(errorParser.parse(error));
          });
      });
    },
    GET_CAR: (context, payload) => {
      return new Promise((resolve, reject) => {
        axios
          .get(`cars/${payload.carId}`)
          .then(({ data }) => {
            context.commit("SET_CAR", data.car);
            resolve(data);
          })
          .catch((error) => {
            reject(errorParser.parse(error));
          });
      });
    },
    UPDATE_CAR: (context, payload) => {
      return new Promise((resolve, reject) => {
        axios
          .put(`cars/${payload.carId}`, payload.form)
          .then(({ data }) => {
            context.commit("SET_CAR", data.car);
            resolve(data);
          })
          .catch((error) => {
            reject(errorParser.parse(error));
          });
      });
    },
    DELETE_CAR: (context, payload) => {
      return new Promise((resolve, reject) => {
        axios
          .delete(`cars/${payload.carId}`)
          .then(({ data }) => {
            context.commit("REMOVE_CAR", payload.carId);
            resolve(data);
          })
          .catch((error) => {
            reject(errorParser.parse(error));
          });
      });
    },
    ADD_CAR: (context, payload) => {
      return new Promise((resolve, reject) => {
        axios
          .post(`users/${payload.userId}/cars`, payload.form)
          .then(({ data }) => {
            context.commit("NEW_CAR", data.car);
            resolve(data);
          })
          .catch((error) => {
            reject(errorParser.parse(error));
          });
      });
    },
    RESET_CAR: (context) => {
      context.commit("RESET", "car");
    },
    RESET_CARS: (context) => {
      context.commit("RESET", "cars");
    },
  },
};
