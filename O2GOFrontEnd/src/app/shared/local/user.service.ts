import { Contract } from "../models/contract";
import {
  Scooter
} from "../models/scooter";
import { Service } from "../models/service";
import {
  User,
  UserGet
} from "../models/user";

export class UserServiceLocal {

  private user = new UserGet();

  public set(userset: UserGet) {
    this.user = userset;
  }

  public setScooter(scooter: Scooter) {
    this.user.scooter = scooter;
    console.log(this.user.scooter)
  }

  public setContract(contract: Contract) {
    this.user.scooter.contract = contract;
  }

  public setService(service: Service) {
    this.user.scooter.service = service;
    console.log(this.user.scooter.service)
  }

  public get() {
    //static adress gebruikt omdat onze backend geen adress meer kan meeleveren
    this.user.address = {
      street: "Pitruslaan",
      postalCode: "4123JB",
      housenumber: "3",
      city: "enschede"
    }
    return this.user
  }
}
