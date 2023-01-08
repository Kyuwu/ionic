import {
  Component,
  OnInit
} from '@angular/core';
import {
  FormBuilder,
  FormControl,
  FormGroup,
  Validators
} from '@angular/forms';
import {
  Router
} from '@angular/router';
import {
  ScooterServiceLocal
} from 'src/app/shared/local/scooter.service';
import { UserServiceLocal } from 'src/app/shared/local/user.service';
import {
  Scooter
} from 'src/app/shared/models/scooter';
import { UserService } from 'src/app/shared/user.service';


@Component({
  selector: 'app-scooters',
  templateUrl: './scooters.component.html',
  styleUrls: ['./scooters.component.scss'],
})
export class ScootersComponent {
  scooters: Scooter[]
  index = 0;
  scooterSelection: FormGroup;
  contractSelection: FormGroup;
  chosenScooter: Scooter;

  constructor(
    public fb: FormBuilder,
    public db: ScooterServiceLocal,
    public router: Router,
    public user: UserServiceLocal,
    public userUpdate: UserService
  ) {
    this.scooterSelection = this.fb.group({
      scooter: ['', Validators.required],
    });
    this.contractSelection = this.fb.group({
      price: ['', Validators.required],
      start: ['', Validators.required],
      end: ['', Validators.required],
    });
  }

  ngOnInit(): void {
    this.scooters = this.db.get();
  }
  submitScooter() {

    let scooter = this.scooters.filter(item => item.licensePlate === this.scooterSelection.controls['scooter'].value)[0];
    this.contractSelection.setControl('price', new FormControl(scooter.price, Validators.required));
    this.user.setScooter(scooter)
  }
  submitContract() {
    this.user.setContract(this.contractSelection.value)
  }

  finish() {
    //update to backend with current user
    this.userUpdate.update(this.user.get());
  }
}
