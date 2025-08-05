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
      state.contacts.unshift(contact);
    },
    REMOVE_CONTACT(state, contactId) {
      state.contacts = state.contacts.filter(
        (contact) => contact.contactId !== contactId
      );
    },
    UPDATE_CONTACT_IN_LIST(state, updatedContact) {
      const index = state.contacts.findIndex(
        (contact) => contact.contactId === updatedContact.contactId
      );
      if (index !== -1) {
        state.contacts.splice(index, 1, updatedContact);
      }
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
          .post(consts.apiUrls.contacts.addOrUpdateContact, payload.form)
          .then(({ data }) => {
            context.commit("NEW_CONTACT", data);
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
          .post(consts.apiUrls.contacts.addOrUpdateContact, payload.form)
          .then(({ data }) => {
            context.commit("UPDATE_CONTACT_IN_LIST", data);
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
          .post(consts.apiUrls.contacts.deleteContactById + payload.contactId)
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
