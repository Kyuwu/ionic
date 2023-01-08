import { Injectable } from '@angular/core';
import { User, UserLogin } from './models/user';
import { Observable, throwError } from 'rxjs';
import { catchError, map } from 'rxjs/operators';
import {
  HttpClient,
  HttpHeaders,
  HttpErrorResponse,
} from '@angular/common/http';
import { Router } from '@angular/router';
import { SnackbarService } from './snackbar.service';
import { Scooter } from './models/scooter';
import { UserServiceLocal } from './local/user.service';
@Injectable({
  providedIn: 'root',
})
export class AuthService {
  endpoint: string = 'http://localhost:8080/api';
  headers = new HttpHeaders().set('Content-Type', 'application/json');
  currentUser = {};
  constructor(private http: HttpClient, public router: Router, public snack: SnackbarService, public user: UserServiceLocal) {}
  // Sign-up post
  signUp(user: User) {
    try {
      return this.http
      .post<any>(`${this.endpoint}/auth/register`, user)
      .subscribe((res: any,) => {
        console.log(res);
      this.router.navigate(['']);
      },
      (error) => { 
        this.handleError(error);
      });
    }
    catch(err) {
      return this.handleError(err);
    }
  }
  // Sign-in post api
  signIn(user: UserLogin) {
    try {
      return this.http
      .post<any>(`${this.endpoint}/auth/login`, user)
      .subscribe((res: any,) => {
      localStorage.setItem('token', res.token);
      this.user.set(res.user);
      console.log(res)
      this.user.set(res.appUser);
      this.router.navigate(['user-profile/']);
      },
      (error) => {                              
        //Error callback
        this.handleError(error);
      });
    }
    catch(err) {
      return this.handleError(err);
    }
  }
  // get the token from storage
  getToken() {
    return localStorage.getItem('token');
  }
  get isLoggedIn(): boolean {
    let authToken = localStorage.getItem('token');
    return authToken !== null ? true : false;
  }
  // logout and remove token
  doLogout() {
    let removeToken = localStorage.removeItem('token');
    if (removeToken == null) {
      this.router.navigate(['log-in']);
    }
    this.snack.add('Logged out','Ok')
  }

  handleError(error: HttpErrorResponse) {
    let msg = '';
    if (error.error instanceof ErrorEvent) {
      // client-side error
      msg = error.error.message;
      this.snack.delete(msg,'Ok');
    } else {
      // server-side error
      this.snack.delete(`${error.message}`, '');
      msg = `Error Code from server: ${error.status}\nMessage: ${error.message}`;
    }
    return throwError(msg);
  }
}