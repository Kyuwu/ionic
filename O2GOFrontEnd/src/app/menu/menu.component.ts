import { Component, Input, OnInit } from "@angular/core";
import { Router } from "@angular/router";
import { UserServiceLocal } from "../shared/local/user.service";
import { User, UserGet } from "../shared/models/user";


@Component({
  selector: 'app-menu',
  templateUrl: './menu.component.html',
  styleUrls: ['./menu.component.scss'],
})
export class MenuComponent implements OnInit {

  @Input() menu = false;
  @Input() state = "";

  _user: UserGet
  constructor(private router: Router, private user: UserServiceLocal) {
    console.log(this.user.get())
    this._user = this.user.get();
   }

  ngOnInit() {}

  logout(){
    localStorage.removeItem('token');
    this.router.navigate(['log-in']);
  }

  contracts() {
    this.router.navigate(['/user-profile/contracts'])  
  }
  home() {
    this.router.navigate(['/user-profile'])  
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
  editUser() {
    this.router.navigate(['/user-profile/edit'])   
  }
}
