import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomeComponent } from './components/home/home.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatButtonModule } from '@angular/material/button';
import { RegisterClientComponent } from './components/register-client/register-client.component';
import { LoginComponent } from './components/login/login.component';
import { PlaningPrincingComponent } from './components/planing-princing/planing-princing.component';
import { ServiceComponent } from './components/service/service.component';
import { MatInputModule } from '@angular/material/input';
import { ReactiveFormsModule } from '@angular/forms';
import { MatSnackBarModule } from '@angular/material/snack-bar';
import { MatMenuModule } from '@angular/material/menu';
import { MatIconModule } from '@angular/material/icon';
import { ForgotPasswordComponent } from './components/forgot-password/forgot-password.component';
import { ConfirmedForgetPasswordComponent } from './components/confirmed-forget-password/confirmed-forget-password.component';
@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    RegisterClientComponent,
    LoginComponent,
    PlaningPrincingComponent,
    ServiceComponent,
    ForgotPasswordComponent,
    ConfirmedForgetPasswordComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MatButtonModule,
    MatInputModule,
    ReactiveFormsModule,
    HttpClientModule,
    MatSnackBarModule,
    MatMenuModule,
    MatIconModule


  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
