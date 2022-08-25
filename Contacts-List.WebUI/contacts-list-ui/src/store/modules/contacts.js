import axios from "axios";
import errorParser from "@/utils/error-parser";
import consts from "@/utils/consts.js";

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
    NEW_CONTACT(state, contact) {
      state.contact.unshift(contact);
    },
    REMOVE_CONTACT(state, contactId) {
      state.contact = state.contact.filter(
        (contact) => contact.contactId !== contactId
      );
    },
  },
  actions: {
    GET_CONTACTS: (context) => {
      return new Promise((resolve, reject) => {
        axios
          .get(consts.apiUrls.contacts.getAllContacts)
          .then(({ data }) => {
            context.commit("SET_CONTACTS", data);
            resolve(data);
          })
          .catch((error) => {
            reject(errorParser.parse(error));
          });
      });
    },
    GET_CONTACT: (context, payload) => {
      return new Promise((resolve, reject) => {
        axios
          .get(
            consts.apiUrls.contacts.getContactsDetailsById + payload.contactId
          )
          .then(({ data }) => {
            context.commit("SET_CONTACT", data);
            resolve(data);
          })
          .catch((error) => {
            reject(errorParser.parse(error));
          });
      });
    },
    ADD_CONTACT: (context, payload) => {
      return new Promise((resolve, reject) => {
        axios
          .post(consts.apiUrls.contacts.AddOrUpdateContact, payload.form)
          .then(({ data }) => {
            context.commit("NEW_CONTACT", payload.form);
            resolve(data);
          })
          .catch((error) => {
            reject(errorParser.parse(error));
          });
      });
    },
    UPDATE_CONTACT: (context, payload) => {
      return new Promise((resolve, reject) => {
        axios
          .post(consts.apiUrls.contacts.AddOrUpdateContact, payload.form)
          .then(({ data }) => {
            resolve(data);
          })
          .catch((error) => {
            reject(errorParser.parse(error));
          });
      });
    },
    DELETE_CONTACT: (context, payload) => {
      return new Promise((resolve, reject) => {
        axios
          .delete(consts.apiUrls.contacts.DeleteContactById + payload.contactId)
          .then(({ data }) => {
            context.commit("REMOVE_CONTACT", payload.contactId);
            resolve(data);
          })
          .catch((error) => {
            reject(errorParser.parse(error));
          });
      });
    },
  },
};
