import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { first } from 'rxjs';
import { AuthService } from '../shared/auth.service';
import { UserServiceLocal } from '../shared/local/user.service';
import { Adress, UserGet, UserRegister } from '../shared/models/user';
import { UserService } from '../shared/user.service';
import { ConfirmedValidator } from '../shared/validators/confirmed.validator';

@Component({
  selector: 'app-edit-user',
  templateUrl: './edit-user.component.html',
  styleUrls: ['./edit-user.component.scss'],
})
export class EditUserComponent implements OnInit {
  signupForm: FormGroup;
  user: UserGet;
  constructor(
    public fb: FormBuilder,
    public authService: AuthService,
    public router: Router,
    public _user: UserServiceLocal,
    public adress: UserService
  ) {
    this.user = _user.get(),
    this.signupForm = this.fb.group({
      firstName: [this.user.firstName, Validators.required],
      lastName: [this.user.lastName, Validators.required],
      email: ['', Validators.required],
      password: ['', Validators.required],
      confirm_password: ['', Validators.required],
      street: [this.user.address.street, Validators.required],
      housenumber: [this.user.address.housenumber, Validators.required],
      postalCode: [this.user.address.postalCode, Validators.required],
      city: [this.user.address.city, Validators.required],

    }, { 
      validator: ConfirmedValidator('password', 'confirm_password')
    });
  }

  home() {
    this.router.navigate(['/']);
  }
  ngOnInit() {
    this.adress.getAdress(this.user.id).pipe(first()).subscribe(result => {
      this.user.address = result[0]; // this is the solution
      
    });
  }
}
