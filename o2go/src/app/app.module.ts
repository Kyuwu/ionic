import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { RouteReuseStrategy } from '@angular/router';

import { IonicModule, IonicRouteStrategy } from '@ionic/angular';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { SigninComponent } from './components/signin/signin.component';
import { SignupComponent } from './components/signup/signup.component';
import { UserProfileComponent } from './components/user-profile/user-profile.component';
import { AuthInterceptor } from './shared/authconfig.interceptor';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { AngularMaterialModule } from './shared/angular-mat.module';
import { HttpRequestInterceptor } from './shared/http-request.interceptor';
import { Signup2Component } from './components/signup/signup2/signup2.component';

@NgModule({
  declarations: [AppComponent, SigninComponent, SignupComponent, Signup2Component, UserProfileComponent],
  imports: [BrowserModule, FormsModule, IonicModule.forRoot(), AppRoutingModule, HttpClientModule, ReactiveFormsModule, BrowserAnimationsModule, AngularMaterialModule],
  providers: [
    { 
      provide: HTTP_INTERCEPTORS,
      useClass: AuthInterceptor,
      multi: true
    },
    { 
      provide: HTTP_INTERCEPTORS, 
      useClass: HttpRequestInterceptor, 
      multi: true 
    }
  ],
  // providers: [
  //   { 
  //     provide: RouteReuseStrategy, HTTP_INTERCEPTORS,
  //     useClass: IonicRouteStrategy, AuthInterceptor,
  //     multi: true
  //   }
  // ],
  bootstrap: [AppComponent],
})
export class AppModule {}
