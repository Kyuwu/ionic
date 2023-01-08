import {
  Component,
  OnInit
} from '@angular/core';
import {
  Router
} from '@angular/router';
import {
  UserServiceLocal
} from 'src/app/shared/local/user.service';
import {
  User
} from 'src/app/shared/models/user';
import {
  AuthService
} from './../../shared/auth.service';
@Component({
  selector: 'app-user-profile',
  templateUrl: './user-profile.component.html',
  styleUrls: ['./user-profile.component.scss'],
})
export class UserProfileComponent implements OnInit {
  currentUser: User;
  constructor(
    public authService: AuthService,
    public router: Router,
    public user: UserServiceLocal
  ) {
    this.currentUser = user.get();
  }
  ngOnInit() {

  }

  contracts() {
    this.router.navigate(['/user-profile/contracts'])
  }
  scooters() {
    this.router.navigate(['/user-profile/scooters'])
  }
  services() {
    this.router.navigate(['/user-profile/services'])
  }
  settings() {
    this.router.navigate(['/user-profile/settings'])
  }
}
