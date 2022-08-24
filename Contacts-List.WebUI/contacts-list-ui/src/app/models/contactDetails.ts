import { Contact } from "./contact";

export interface ContactDetails extends Contact {
  firstName: string;
  lastName: string;
  email: string;
  phoneNumber: number;
  dateOfBirth: string;
}
