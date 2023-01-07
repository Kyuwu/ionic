import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { AuthService } from './../../shared/auth.service';
import { Router } from '@angular/router';
import { MatSnackBar } from '@angular/material/snack-bar';
import { SnackbarService } from 'src/app/shared/snackbar.service';

@Component({
  selector: 'app-signin',
  templateUrl: './signin.component.html',
  styleUrls: ['./signin.component.scss'],
})
export class SigninComponent implements OnInit {
  public signinForm: FormGroup;
  constructor(
    public fb: FormBuilder,
    public authService: AuthService,
    public router: Router,
    public snack: SnackbarService
  ) {
    this.signinForm = this.fb.group({
      email: ['', Validators.required],
      password: ['', Validators.required],
    });
  }
  navigate(){
    this.router.navigate(['/sign-up'])
  }
  test(){
    this.router.navigate(['/user-profile/0'])
  }
  ngOnInit() {
  }
  loginUser() {
    this.authService.signIn(this.signinForm.value);
    console.log(this.signinForm.value)
    console.log(localStorage.getItem('token'));
  }
}