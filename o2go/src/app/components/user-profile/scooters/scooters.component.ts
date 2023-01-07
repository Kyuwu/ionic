import { Component, OnInit } from '@angular/core';
import { ScooterServiceLocal } from 'src/app/shared/local/scooter.service';
import { Scooter } from 'src/app/shared/models/scooter';


@Component({
  selector: 'app-scooters',
  templateUrl: './scooters.component.html',
  styleUrls: ['./scooters.component.scss'],
})
export class ScootersComponent implements OnInit {
  scooters: Scooter[]
  constructor(private db: ScooterServiceLocal) { 
    
  }
  ngOnInit(): void {
    this.scooters = this.db.get();
  }
}
