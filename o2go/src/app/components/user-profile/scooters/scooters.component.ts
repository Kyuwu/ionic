import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { map } from 'rxjs/internal/operators/map';
import { AuthService } from 'src/app/shared/auth.service';
import { Scooter } from 'src/app/shared/models/scooter';
import { ScooterService } from 'src/app/shared/scooters.service';


@Component({
  selector: 'app-scooters',
  templateUrl: './scooters.component.html',
  styleUrls: ['./scooters.component.scss'],
})
export class ScootersComponent implements OnInit {
  scooters: Scooter[]
  constructor(private db: ScooterService) { }
  ngOnInit(): void {
    this.getScooters();
  }
  getScooters() {
    this.db.getScooters().subscribe(
      i => this.scooters = i);
  }
}
