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
@Injectable({
  providedIn: 'root',
})
export class AuthService {
  endpoint: string = 'http://localhost:8080/api';
  headers = new HttpHeaders().set('Content-Type', 'application/json');
  currentUser = {};
  constructor(private http: HttpClient, public router: Router, public snack: SnackbarService) {}
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
      this.router.navigate(['user-profile/0']);
        // this.getUserProfile(res._id).subscribe((res) => {
        //   this.currentUser = res;
        //   // this.currentUser = this.user;
        //   this.router.navigate(['user-profile/' + res.msg._id]);
        // });
      },
      (error) => {                              //Error callback
        this.handleError(error);
  
        //throw error;   //You can also throw the error to a global error handler
      });
    }
    catch(err) {
      return this.handleError(err);
    }
  }
  // signIn(user: UserLogin) {
  //   return this.http
  //     .post<any>(`${this.endpoint}/auth/login`, user)
  //     .subscribe(
  //       res => console.log('HTTP response', this.login(res)),
  //       err => console.log('HTTP Error', err),
  //       () => console.log('HTTP request completed.')
  //   );
  // }
  // login(res) {
  //   if(res == 200) {
  //     localStorage.setItem('token', res.token);
  //     this.router.navigate(['user-profile/0']);
  //   }else {
  //     this.handleError(res)
  //   }
  // }
  signInDummy(user: User) {
    this.router.navigate(['user-profile/0']);
  }
  // get the token from storage
  getToken() {
    return localStorage.getItem('token');
  }
  get isLoggedIn(): boolean {
    let authToken = localStorage.getItem('access_token');
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
  // User profile
  getUserProfile(id: any): Observable<any> {
    let api = `${this.endpoint}/user-profile/${id}`;
    return this.http.get(api, { headers: this.headers }).pipe(
      map((res) => {
        return res || {};
      }),
      catchError(this.handleError)
    );
  }
  // getUserProfileDummy(id: any) {
  //   return this.user;
  // }
  // Error handeling
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