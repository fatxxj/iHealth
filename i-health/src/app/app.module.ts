import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

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
@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    RegisterClientComponent,
    LoginComponent,
    PlaningPrincingComponent,
    ServiceComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MatButtonModule,
    MatInputModule,




  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
