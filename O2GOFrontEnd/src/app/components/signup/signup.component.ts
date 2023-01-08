import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { AuthService } from './../../shared/auth.service';
import { Router } from '@angular/router';
import { ConfirmedValidator } from 'src/app/shared/validators/confirmed.validator';
import { UserRegister } from 'src/app/shared/models/user';
@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.scss'],
})
export class SignupComponent implements OnInit {
  signupForm: FormGroup;
  first: boolean = true;
  user: UserRegister;
  constructor(
    public fb: FormBuilder,
    public authService: AuthService,
    public router: Router
  ) {
    this.signupForm = this.fb.group({
      firstName: ['', Validators.required],
      lastName: ['', Validators.required],
      email: ['', Validators.required],
      password: ['', Validators.required],
      confirm_password: ['', Validators.required]
    }, { 
      validator: ConfirmedValidator('password', 'confirm_password')
    });
  }

  navigate(){
    this.first = false;
  }
  home() {
    this.router.navigate(['/']);
  }
  ngOnInit() {

  }
}