import { Scooter } from "../models/scooter";

export class ScooterServiceLocal {  
  
  public get(): Scooter [] {  
  return [  
    {  
   licensePlate: 'Ng01',  
   maxKmh : 42,
   brand: 'Scooter',  
   year1: 2022,
   description: 'desc',
   price: 42 
  }, 
  {  
    licensePlate: 'Ng02',  
    maxKmh : 42,
    brand: 'Vroom vrrom',  
    year1: 2022,
    description: 'desc',
    price: 42 
   },  
   {  
    licensePlate: 'Ng03',  
    maxKmh : 42,
    brand: 'IK HEB KANKER',  
    year1: 2022,
    description: 'desc',
    price: 42 
   },   

  ];  
  }  
  
}  