import axios from "axios";
import errorParser from "@/utils/error-parser";
import consts from "@/utils/consts.js";

function initialState() {
  return {
    category: [],
  };
}

export default {
  state: initialState(),
  getters: {
    CATEGORY: (state) => {
      return state.category;
    },
  },
  mutations: {
    SET_CATEGORY(state, payload) {
      state.category = payload;
    },
  },
  actions: {
    GET_CATEGORY: (context) => {
      return new Promise((resolve, reject) => {
        axios
          .get(consts.apiUrls.category.getAllCategory)
          .then(({ data }) => {
            context.commit("SET_CATEGORY", data);
            resolve(data);
          })
          .catch((error) => {
            reject(errorParser.parse(error));
          });
      });
    },
  },
};
