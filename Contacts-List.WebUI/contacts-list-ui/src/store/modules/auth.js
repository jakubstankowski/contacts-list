import axios from "axios";
import errorParser from "@/utils/error-parser";

export default {
  actions: {
    LOGIN: (payload) => {
      return new Promise((resolve, reject) => {
        axios
          .post("/Account/Login", payload)
          .then(({ data }) => {
            resolve(data);
          })
          .catch((error) => {
            console.log(errorParser.parse(error));
            reject(errorParser.parse(error));
          });
      });
    },
    REGISTER: (payload) => {
      return new Promise((resolve, reject) => {
        axios
          .post("/Account/register", payload)
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
