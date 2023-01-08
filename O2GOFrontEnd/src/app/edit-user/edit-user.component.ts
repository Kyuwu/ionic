import { Component, OnInit } from "@angular/core";
import { FormGroup, FormBuilder, Validators } from "@angular/forms";
import { Router } from "@angular/router";
import { AuthService } from "../shared/auth.service";
import { UserServiceLocal } from "../shared/local/user.service";
import { UserGet } from "../shared/models/user";
import { UserService } from "../shared/user.service";
import { ConfirmedValidator } from "../shared/validators/confirmed.validator";


@Component({
  selector: 'app-edit-user',
  templateUrl: './edit-user.component.html',
  styleUrls: ['./edit-user.component.scss'],
})
export class EditUserComponent{
  editUserForm: FormGroup;
  user: UserGet;
  constructor(
    public fb: FormBuilder,
    public authService: AuthService,
    public router: Router,
    public _user: UserServiceLocal,
    public _userUpdate: UserService,
  ) {
    this.user = _user.get(),
    this.editUserForm = this.fb.group({
      firstName: [this.user.firstName, Validators.required],
      lastName: [this.user.lastName, Validators.required],
      street: [this.user.address.street, Validators.required],
      housenumber: [this.user.address.housenumber, Validators.required],
      postalCode: [this.user.address.postalCode, Validators.required],
      city: [this.user.address.city, Validators.required],
    });
  }

  home() {
    this.router.navigate(['/']);
  }

  submit() {
    this._userUpdate.update(this.editUserForm.value, this.user.id);
  }
}
