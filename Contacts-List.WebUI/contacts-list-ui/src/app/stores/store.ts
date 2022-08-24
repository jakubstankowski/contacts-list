import { createContext, useContext } from "react";
import ContactsStore from "./contactsStore";

interface Store {
  contactsStore: ContactsStore;
}

export const store: Store = {
  contactsStore: new ContactsStore(),
};

export const StoreContext = createContext(store);

export function useStore() {
  return useContext(StoreContext);
}
