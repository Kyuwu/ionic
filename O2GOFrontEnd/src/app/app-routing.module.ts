import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { SigninComponent } from './components/signin/signin.component';
import { SignupComponent } from './components/signup/signup.component';
import { Signup2Component } from './components/signup/signup2/signup2.component';
import { ContractsComponent } from './components/user-profile/contracts/contracts.component';
import { ScootersComponent } from './components/user-profile/scooters/scooters.component';
import { ServicesComponent } from './components/user-profile/services/services.component';
import { UserProfileComponent } from './components/user-profile/user-profile.component';
import { EditUserComponent } from './edit-user/edit-user.component';
import { AuthGuard } from "./shared/auth.guard";
// const routes: Routes = [
//   {
//     path: 'tabs',
//     loadChildren: () => import('./tabs/tabs.module').then(m => m.TabsPageModule)
//   },
//   {
//     path: 'login',
//     loadChildren: () => import('./login/login/login.module').then( m => m.LoginPageModule)
//   },
//   {
//     path: 'registration',
//     loadChildren: () => import('./login/registration/registration.module').then( m => m.RegistrationPageModule)
//   },
//   {
//     path: 'forgot-password',
//     loadChildren: () => import('./login/forgot-password/forgot-password.module').then( m => m.ForgotPasswordPageModule)
//   },
//   {
//     path: '',
//     loadChildren: () => import('./home/home.module').then( m => m.HomePageModule)
//   }
// ];
const routes: Routes = [
  { path: '', redirectTo: '/log-in', pathMatch: 'full' },
  { path: 'log-in', component: SigninComponent, },
  { path: 'sign-up', component: SignupComponent },
  { path: 'sign-up2', component: Signup2Component },
  { path: 'user-profile', component: UserProfileComponent, canActivate:[AuthGuard] },
  { path: 'user-profile/scooters', component: ScootersComponent, canActivate:[AuthGuard]  },
  { path: 'user-profile/contracts', component: ContractsComponent, canActivate:[AuthGuard]  },
  { path: 'user-profile/services', component: ServicesComponent, canActivate:[AuthGuard]  },
  { path: 'user-profile/settings', component: EditUserComponent, canActivate:[AuthGuard]  },
];
@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
