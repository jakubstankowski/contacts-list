import axios from "axios";
import errorParser from "@/utils/error-parser";
import consts from "@/utils/consts.js";

function initialState() {
  return {
    authStatus: false,
  };
}

export default {
  state: initialState(),
  getters: {
    AUTH_STATUS: (state) => {
      return state.authStatus;
    },
  },
  mutations: {
    SET_AUTH_STATUS(state, payload) {
      state.authStatus = payload;
    },
  },
  actions: {
    LOGIN: (context, payload) => {
      return new Promise((resolve, reject) => {
        axios
          .post(consts.apiUrls.auth.login, payload.form)
          .then(({ data }) => {
            context.commit("SET_AUTH_STATUS", true);
            resolve(data);
          })
          .catch((error) => {
            console.log(errorParser.parse(error));
            reject(errorParser.parse(error));
          });
      });
    },
    REGISTER: (context, payload) => {
      return new Promise((resolve, reject) => {
        axios
          .post(consts.apiUrls.auth.register, payload.form)
          .then(({ data }) => {
            resolve(data);
          })
          .catch((error) => {
            reject(errorParser.parse(error));
          });
      });
    },
    LOGOUT: (context) => {
      context.commit("SET_AUTH_STATUS", false);
    },
  },
};
