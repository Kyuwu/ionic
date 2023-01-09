import { Contract } from "./contract";
import { Service } from "./service";

export class Scooter {
    licensePlate!: string;
    maxKmh!: number;
    brand!: string;
    year!: number;
    description!: string;
    price!: number;
    contract!: Contract;
    service!: Service;
  }