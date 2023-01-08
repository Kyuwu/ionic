import { Component } from "@angular/core";
import { FormGroup, FormBuilder, Validators, FormControl } from "@angular/forms";
import { Router } from "@angular/router";
import { AuthService } from "../shared/auth.service";
import { UserServiceLocal } from "../shared/local/user.service";
import { UserGet } from "../shared/models/user";
import { UserService } from "../shared/user.service";


@Component({
  selector: 'app-edit-user',
  templateUrl: './edit-user.component.html',
  styleUrls: ['./edit-user.component.scss'],
})
export class EditUserComponent{
  editUserForm: FormGroup;
  user: UserGet;
  postUser: UserGet;
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
      address: new FormGroup({
        street: new FormControl(this.user.address.street, Validators.required),
        housenumber: new FormControl(this.user.address.housenumber, Validators.required),
        postalCode: new FormControl(this.user.address.postalCode, Validators.required),
        city: new FormControl(this.user.address.city, Validators.required),
      }),
      user: new FormGroup({
        id: new FormControl(''),
      }),
    });
  }

  home() {
    this.router.navigate(['/user-profile']);
  }

  submit() {

    this.editUserForm.addControl('id', new FormControl(this.user.id, Validators.required));
    this.editUserForm.addControl('userId', new FormControl(this.user.userId));
    this._user.set(this.editUserForm.value)
    this.postUser = this.editUserForm.value;
    this._userUpdate.update(this.postUser);
  }
}
