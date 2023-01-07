import { Injectable } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';

@Injectable({
  providedIn: 'root'
})
export class SnackbarService {

  constructor(public snaccy: MatSnackBar) { }
  delete(message: string, action: string) {
    this.snaccy.open(message, action, {
       duration: 2000,
       verticalPosition: 'top',
       panelClass: ['red-snackbar-styling']
    });
  }
  edit(message: string, action: string) {
    this.snaccy.open(message, action, {
       duration: 2000,
       verticalPosition: 'top',
       panelClass: ['orange-snackbar-styling']
    });
  }
  add(message: string, action: string) {
    this.snaccy.open(message, action, {
       duration: 2000,
       verticalPosition: 'top',
       panelClass: ['green-snackbar-styling']
    });
  }
  update(message: string, action: string) {
    this.snaccy.open(message, action, {
       duration: 2000,
       verticalPosition: 'top',
       panelClass: ['blue-snackbar-styling']
    });
  }
}
