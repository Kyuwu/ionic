import { Scooter } from "./scooter";

export class User {
    email!: String;
    password!: String;
    firstName!: String;
    lastName!: String;
    street!: String;
    housenumber!: String;
    postalCode!: String;
    city!: String;
    admin!: boolean;
    scooter!: Scooter;
  }
  
export class UserLogin {
  email!: String;
  password!: String;
}
export class UserRegister {
  email!: String;
  password!: String;
  firstName!: String;
  lastName!: String;
}