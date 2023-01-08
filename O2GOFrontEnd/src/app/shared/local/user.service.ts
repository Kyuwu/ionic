import {
  Scooter
} from "../models/scooter";
import { User } from "../models/user";

export class UserServiceLocal {

  private user = new User();

  public set(userset: User) {
    this.user = userset;
  }

  public setEmail(email: string) {
    this.user.email = email;
  }

  public setScooter(scooter: Scooter) {
    this.user.scooter = scooter;
    console.log(this.user.scooter.brand)
  }

  public get() {
    return this.user
  }
}
