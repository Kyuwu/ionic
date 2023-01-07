import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { AuthService } from './../../shared/auth.service';
@Component({
  selector: 'app-user-profile',
  templateUrl: './user-profile.component.html',
  styleUrls: ['./user-profile.component.scss'],
})
export class UserProfileComponent implements OnInit {
  currentUser: Object = {};
  id;
  constructor(
    public authService: AuthService,
    private actRoute: ActivatedRoute,
    public router: Router
  ) {
    this.id = this.actRoute.snapshot.paramMap.get('id');
    // this.authService.getUserProfile(this.id).subscribe((res) => {
    //   this.currentUser = res.msg;
    // });
    // this.currentUser = this.authService.getUserProfileDummy(id);
  }
  ngOnInit() {}

  contracts() {
    this.router.navigate(['/user-profile/'+this.id+'/contracts'])  
  }
  scooters() {
    this.router.navigate(['/user-profile/'+this.id+'/scooters'])
  }
  services() {
    this.router.navigate(['/user-profile/'+this.id+'/services'])    
  }
  settings() {
    this.router.navigate(['/user-profile/'+this.id+'/settings'])   
  }
}