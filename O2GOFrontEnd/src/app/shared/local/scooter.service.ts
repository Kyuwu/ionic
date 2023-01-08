import {
  Scooter
} from "../models/scooter";

export class ScooterServiceLocal {

  public get(): Scooter[] {
    return [{
        licensePlate: 'Ng01',
        maxKmh: 42,
        brand: 'Scooter',
        year: 2020,
        description: 'des331c',
        price: 42321,
        contract: null
      },
      {
        licensePlate: 'Ng02',
        maxKmh: 42,
        brand: 'Vroom v123rrom',
        year: 2021,
        description: 'de321sc',
        price: 423,
        contract: null
      },
      {
        licensePlate: 'Ng03',
        maxKmh: 42,
        brand: 'brum brum',
        year: 2022,
        description: 'desc3',
        price: 421231,
        contract: null
      },
      {
        licensePlate: 'Ng04',
        maxKmh: 43,
        brand: 'burm',
        year: 2022,
        description: 'desc3',
        price: 421231,
        contract: null
      },
    ];
  }

}
