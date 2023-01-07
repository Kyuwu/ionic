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
export class ScooterService {
    
  endpoint: string = 'https://localhost:7283/api';
  headers = new HttpHeaders({
    'Content-Type': 'application/json',
    'Authorization': `Bearer ${localStorage.getItem('token')}`});
  constructor(private http: HttpClient, public router: Router, public snack: SnackbarService) {}
  // getter
  get() {
    return this.http.get < {
        [key: string]: Scooter
      } > (`${this.endpoint}/scooters`)
      .pipe(map(responeData => {
        const postArray: Scooter[] = [];
        for (const key in responeData) {
          if (responeData.hasOwnProperty(key)) {
            postArray.push({
              ...responeData[key],
            });
          }
        }
        return postArray;
      }))
  }
  getScooters(): Observable<any[]> {
    return this.http.get<any[]>(this.endpoint + '/scooters');
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