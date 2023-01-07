import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ScooterServiceLocal } from 'src/app/shared/local/scooter.service';
import { UserServiceLocal } from 'src/app/shared/local/user.service';
import { Scooter } from 'src/app/shared/models/scooter';

@Component({
  selector: 'app-scooter-selection',
  templateUrl: './scooter-selection.component.html',
  styleUrls: ['./scooter-selection.component.scss'],
})
export class ScooterSelectionComponent implements OnInit {
  scooters: Scooter[]
  index = 0;
  scooterSelection: FormGroup;
  constructor(
    public fb: FormBuilder,
    public db: ScooterServiceLocal,
    public router: Router,
    public user: UserServiceLocal
  ) {
    this.scooterSelection = this.fb.group({
      scooter: ['', Validators.required],
    });
  }


  ngOnInit(): void {
    this.scooters = this.db.get();
  }

  submit() {
    //update to backend with current user
    let scooter = this.scooters.filter(item => item.licensePlate === this.scooterSelection.controls['scooter'].value)[0];
    console.log(scooter)
    // this.user.setScooter()
  }
}
