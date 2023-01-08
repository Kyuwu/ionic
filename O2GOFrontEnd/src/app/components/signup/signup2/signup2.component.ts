import { Component, Input, OnInit } from '@angular/core';
import { Form, FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/shared/auth.service';
import { UserRegister } from 'src/app/shared/models/user';
import { ConfirmedValidator } from 'src/app/shared/validators/confirmed.validator';

@Component({
  selector: 'app-signup2',
  templateUrl: './signup2.component.html',
  styleUrls: ['./signup2.component.scss'],
})
export class Signup2Component implements OnInit {
  signupForm: FormGroup;
  @Input() user: UserRegister;

  constructor(public fb: FormBuilder,
    public authService: AuthService,
    public router: Router) {
    this.signupForm = this.fb.group({
      street: ['', Validators.required],
      housenumber: ['', Validators.required],
      postalCode: ['', Validators.required],
      city: ['', Validators.required],
      admin: [false],
    });
    }
  ngOnInit(): void {
    console.log(this.user)
    this.signupForm.addControl('firstName', new FormControl(this.user.firstName, Validators.required));
    this.signupForm.addControl('lastName', new FormControl(this.user.lastName, Validators.required));
    this.signupForm.addControl('email', new FormControl(this.user.email, Validators.required));
    this.signupForm.addControl('password', new FormControl(this.user.password, Validators.required));
  }

  registerUser() {
    this.authService.signUp(this.signupForm.value);
  }
}
