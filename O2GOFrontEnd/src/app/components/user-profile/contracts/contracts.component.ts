import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ScooterServiceLocal } from 'src/app/shared/local/scooter.service';
import { UserServiceLocal } from 'src/app/shared/local/user.service';
import { Scooter } from 'src/app/shared/models/scooter';
import { UserGet } from 'src/app/shared/models/user';
import { UserService } from 'src/app/shared/user.service';

@Component({
  selector: 'app-contracts',
  templateUrl: './contracts.component.html',
  styleUrls: ['./contracts.component.scss'],
})
export class ContractsComponent implements OnInit {

  user: UserGet
  endDate: string;
  startDate: string;
  constructor(public _user: UserServiceLocal, public router: Router, public removeScooter: UserService) { 
    this.user = _user.get();
    if (this.user.scooter != null) {
      var emonth = this.user.scooter.contract.end.getUTCMonth() + 1; //months from 1-12
      var eday = this.user.scooter.contract.end.getUTCDate();
      var eyear = this.user.scooter.contract.end.getUTCFullYear();
      var smonth = this.user.scooter.contract.start.getUTCMonth() + 1; //months from 1-12
      var sday = this.user.scooter.contract.start.getUTCDate();
      var syear = this.user.scooter.contract.start.getUTCFullYear();
      this.endDate = eday + "-" + emonth + "-" + eyear;
      this.startDate = sday + "-" + smonth + "-" + syear;
    }


  }
  home() {
    this.router.navigate(['/user-profile']);
  }

  remove() {
    this._user.setScooter(null)
    this.removeScooter.update(this._user.get());
  }


  ngOnInit() {}

}
