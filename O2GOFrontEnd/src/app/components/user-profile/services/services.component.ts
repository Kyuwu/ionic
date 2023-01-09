import {
  Component,
  Injectable,
  OnInit
} from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { DateAdapter } from '@angular/material/core';
import { MatDateRangeSelectionStrategy, DateRange, MAT_DATE_RANGE_SELECTION_STRATEGY } from '@angular/material/datepicker';
import {
  Router
} from '@angular/router';
import {
  PhotoService
} from 'src/app/services/photo.service';
import {
  UserServiceLocal
} from 'src/app/shared/local/user.service';
import {
  UserGet
} from 'src/app/shared/models/user';
import {
  UserService
} from 'src/app/shared/user.service';


@Injectable()
export class FiveDayRangeSelectionStrategy<D> implements MatDateRangeSelectionStrategy<D> {
  constructor(private _dateAdapter: DateAdapter<D>) {}

  selectionFinished(date: D | null): DateRange<D> {
    return this._createFiveDayRange(date);
  }

  createPreview(activeDate: D | null): DateRange<D> {
    return this._createFiveDayRange(activeDate);
  }

  private _createFiveDayRange(date: D | null): DateRange<D> {
    if (date) {
      const start = this._dateAdapter.addCalendarDays(date, -2);
      const end = this._dateAdapter.addCalendarDays(date, 2);
      return new DateRange<D>(start, end);
    }

    return new DateRange<D>(null, null);
  }
}

@Component({
  selector: 'app-services',
  templateUrl: './services.component.html',
  styleUrls: ['./services.component.scss'],
  providers: [
    {
      provide: MAT_DATE_RANGE_SELECTION_STRATEGY,
      useClass: FiveDayRangeSelectionStrategy,
    },
  ],
})
export class ServicesComponent implements OnInit {

  user: UserGet
  serviceForm: FormGroup;
  endDate: string;
  startDate: string;
  first: boolean = true;
  constructor(public _user: UserServiceLocal, public fb: FormBuilder, public router: Router, public setService: UserService, public photoService: PhotoService) {
    this.user = _user.get();
    this.serviceForm = this.fb.group({
      start: ['', Validators.required],
      end: ['', Validators.required],
      reason: ['', Validators.required],
    });
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

  plan() {
    this._user.setService(this.serviceForm.value);
    this.setService.update(this._user.get());
  }

  addPhotoToGallery() {
    this.serviceForm.addControl('photo', new FormControl(this.photoService.photos[0]));
    this.photoService.addNewToGallery();
  }

  async ngOnInit() {
  }


  remove() {
    this._user.setService(null)
    this.setService.update(this._user.get());
  }

}
