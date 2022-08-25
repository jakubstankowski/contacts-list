import axios from "axios";
import errorParser from "@/utils/error-parser";
import consts from "@/utils/consts.js";

export default {
  actions: {
    LOGIN: (context, payload) => {
      return new Promise((resolve, reject) => {
        axios
          .post(consts.apiUrls.auth.login, payload.form)
          .then(({ data }) => {
            resolve(data);
          })
          .catch((error) => {
            console.log(errorParser.parse(error));
            reject(errorParser.parse(error));
          });
      });
    },
    REGISTER: (context, payload) => {
      console.log("payload: ", payload);
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
  },
};
