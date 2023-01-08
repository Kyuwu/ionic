import {
  Scooter
} from "../models/scooter";

export class ScooterServiceLocal {

  public get(): Scooter[] {
    return [{
        licensePlate: 'FDQ38X',
        maxKmh: 45,
        brand: 'AGM',
        year: 2020,
        description: 'Betrouwbare scooter.',
        price: 125,
        contract: null
      },
      {
        licensePlate: 'TRB25A',
        maxKmh: 45,
        brand: 'SYM',
        year: 2021,
        description: 'Betrouwbare scooter met weinig kilometers.',
        price: 175,
        contract: null
      },
      {
        licensePlate: 'YON39Q',
        maxKmh: 25,
        brand: 'AGM',
        year: 2022,
        description: 'Betrouwbare nieuwe scooter. Weinig mee gereden.',
        price: 250,
        contract: null
      },
      {
        licensePlate: 'XNG94D',
        maxKmh: 25,
        brand: 'SYM',
        year: 2022,
        description: 'Betrouwbare nieuwe scooter. Veel mee gereden, nooit problemen.',
        price: 215,
        contract: null
      },
    ];
  }

}
