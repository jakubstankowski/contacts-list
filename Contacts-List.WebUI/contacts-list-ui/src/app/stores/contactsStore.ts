import { makeAutoObservable } from "mobx";
import agent from "../api/agent";
import { Contact } from "../models/contact";

export default class ContactStore {
  contactsRegistry = new Map<string, Contact>();
  selectedContact: Contact | undefined = undefined;
  editMode = false;
  loading = false;
  loadingInitial = true;

  constructor() {
    makeAutoObservable(this);
  }

  loadContacts = async () => {
    this.loadingInitial = true;
    try {
      const contacts = await agent.Contacts.list();
      console.log("contacts: ", contacts);
    } catch (error) {}
  };
}
