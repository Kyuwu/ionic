import {
  Scooter
} from "../models/scooter";
import { User, UserGet } from "../models/user";

export class UserServiceLocal {

  private user = new UserGet();

  public set(userset: UserGet) {
    this.user = userset;
  }

  public setScooter(scooter: Scooter) {
    this.user.scooter = scooter;
    console.log(this.user.scooter.brand)
  }

  public get() {
    return this.user
  }
}
