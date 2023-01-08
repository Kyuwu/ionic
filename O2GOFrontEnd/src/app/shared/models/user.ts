import { Contract } from "./contract";
import {
  Scooter
} from "./scooter";

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

export class UserGet {
  id!: number;
  userId!: String;
  address!: Adress;
  addressId!: number;
  password!: String;
  firstName!: String;
  lastName!: String;
  contracts!: Contract[]
  scooter!: Scooter;
}
export class Adress {
  street!: String;
  housenumber!: String;
  postalCode!: String;
  city!: String;
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
