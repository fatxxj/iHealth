import { Injectable, EventEmitter } from '@angular/core';
import { Router } from '@angular/router';
import { catchError, of, map } from 'rxjs';
import { Login } from '../models/login.model';
import { RestConnectorService } from './rest-connector.service';
import { LoginResponse } from '../models/login-response.model';


@Injectable({
    providedIn: 'root'
})

export class AuthService {

    isUserLoggedIn = new EventEmitter<boolean>()


    constructor(private restConnectorService: RestConnectorService, private router: Router) { }



    login(userData: Login) {
        return this.restConnectorService.login(userData).pipe(
            map((result: LoginResponse) => {
                this.isUserLoggedIn.emit(true)
                console.log(result);


                localStorage.setItem('token', result.value.user.token);
                localStorage.setItem('id', result.value.user.id.toString());
                localStorage.setItem('fullName', result.value.user.name + " " + result.value.user.surname);

                return result
            }),
            catchError(error => {
                this.isUserLoggedIn.emit(false)
                return of(error)
            })
        )
    }
    getToken() {
        return localStorage.getItem('token') ?? '';
    }

    logout() {
        localStorage.removeItem('token');
        localStorage.removeItem('fullName')
        localStorage.removeItem('id')
        this.router.navigate(['login']);
        this.isUserLoggedIn.emit(false);
    }
}