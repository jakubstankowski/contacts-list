import axios, { AxiosResponse } from "axios";
import { Contact } from "../models/contact";

axios.defaults.baseURL = "https://localhost:7104/api";

const responseBody = <T>(response: AxiosResponse<T>) => response.data;

const requests = {
  get: <T>(url: string) => axios.get<T>(url).then(responseBody),
  post: <T>(url: string, body: {}) =>
    axios.post<T>(url, body).then(responseBody),
  put: <T>(url: string, body: {}) => axios.put<T>(url, body).then(responseBody),
  del: <T>(url: string) => axios.delete<T>(url).then(responseBody),
};

const Contacts = {
  list: () => requests.get<Contact[]>("/Contacts/GetAllContacts"),
  //   details: (id: string) => requests.get<ContactDetails>(`/activities/${id}`),
  //   create: (activity: Activity) => axios.post<void>("/activities", activity),
  //   update: (activity: Activity) =>
  //     axios.put<void>(`/activities/${activity.id}`, activity),
  //   delete: (id: string) => axios.delete<void>(`/activities/${id}`),
};

const agent = {
  Contacts,
};

export default agent;
