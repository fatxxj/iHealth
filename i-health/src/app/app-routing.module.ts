import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ConfirmedForgetPasswordComponent } from './components/confirmed-forget-password/confirmed-forget-password.component';
import { ForgotPasswordComponent } from './components/forgot-password/forgot-password.component';
import { HomeComponent } from './components/home/home.component';
import { LoginComponent } from './components/login/login.component';
import { PlaningPrincingComponent } from './components/planing-princing/planing-princing.component';
import { RegisterClientComponent } from './components/register-client/register-client.component';
import { ServiceComponent } from './components/service/service.component';

const routes: Routes = [
  { path: 'home', component: HomeComponent },
  { path: 'register-client', component: RegisterClientComponent },
  { path: 'login', component: LoginComponent },
  { path: 'planing-princing', component: PlaningPrincingComponent },
  { path: 'service', component: ServiceComponent },
  { path: 'forgot-password', component: ForgotPasswordComponent },
  { path: 'confirmed-forget-password', component: ConfirmedForgetPasswordComponent },
  { path: '**', redirectTo: 'home', pathMatch: 'full' },

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {


}
