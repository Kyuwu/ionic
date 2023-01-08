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
import { ScooterService } from './shared/scooters.service';
import { ScooterServiceLocal } from './shared/local/scooter.service';
import { CommonModule } from '@angular/common';
import { ScootersComponent } from './components/user-profile/scooters/scooters.component';
import { UserServiceLocal } from './shared/local/user.service';
import { SettingsComponent } from './components/user-profile/settings/settings.component';
import { ServicesComponent } from './components/user-profile/services/services.component';
import { ContractsComponent } from './components/user-profile/contracts/contracts.component';
import { ScooterSelectionComponent } from './components/user-profile/scooters/scooter-selection/scooter-selection.component';
import { ContractSelectionComponent } from './components/user-profile/scooters/contract-selection/contract-selection.component';
import { PaymentSelectionComponent } from './components/user-profile/scooters/payment-selection/payment-selection.component';
import { MenuHeaderComponent } from './menu-header/menu-header.component';
import { MenuComponent } from './menu/menu.component';

@NgModule({
    declarations: [AppComponent, SigninComponent, SignupComponent, Signup2Component, UserProfileComponent, ScootersComponent, MenuComponent, MenuHeaderComponent, SettingsComponent, ServicesComponent, ContractsComponent, ScooterSelectionComponent, ContractSelectionComponent, PaymentSelectionComponent],
    providers: [ScooterService, ScooterServiceLocal, UserServiceLocal,
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
    imports: [BrowserModule, CommonModule, FormsModule, IonicModule.forRoot(), AppRoutingModule, HttpClientModule, ReactiveFormsModule, BrowserAnimationsModule, AngularMaterialModule]
})
export class AppModule {}