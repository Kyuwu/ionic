import {
  Injectable
} from '@angular/core';
import {
  Adress,
  User,
  UserGet,
  UserLogin
} from './models/user';
import {
  Observable,
  throwError
} from 'rxjs';
import {
  catchError,
  map
} from 'rxjs/operators';

import {
  HttpClient,
  HttpHeaders,
  HttpErrorResponse,
} from '@angular/common/http';
import {
  Router
} from '@angular/router';
import {
  SnackbarService
} from './snackbar.service';
import {
  Scooter
} from './models/scooter';
import {
  Address
} from 'cluster';
import { resolve } from 'dns';
@Injectable({
  providedIn: 'root',
})
export class UserService {

  endpoint: string = 'http://localhost:8080/api';
  headers = new HttpHeaders({
    'Content-Type': 'application/json',
    'Authorization': `Bearer ${localStorage.getItem('token')}`
  });
  constructor(private http: HttpClient, public router: Router, public snack: SnackbarService) {}
  // getter
  getAdress(id: number) {
    return this.http.get(`${this.endpoint}/users/address/${id}`);
  }
  update(user: FormData, id: number) {
    try {
      console.log(user)
      return this.http.post(`${this.endpoint}/users/update/${id}`, user).subscribe;
    } catch (error) {
      console.log("xddd")
      return this.handleError(error);
    }
    
  }
  handleError(error: HttpErrorResponse) {
    let msg = '';
    if (error.error instanceof ErrorEvent) {
      // client-side error
      msg = error.error.message;
      this.snack.delete(msg, 'Ok');
    } else {
      // server-side error
      this.snack.delete(`${error.message}`, '');
      msg = `Error Code from server: ${error.status}\nMessage: ${error.message}`;
    }
    return throwError(msg);
  }
}
