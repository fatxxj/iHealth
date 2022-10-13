import { Injectable } from "@angular/core";
import { Router } from "@angular/router";
import { Login } from "../models/login.model";
import { ApiRequestService } from "./api-request.service";
import { catchError, map, of } from 'rxjs';
import { LoginResponse } from "../models/login-response.model";

@Injectable({
    providedIn: 'root'
})

export class AuthService {

    constructor(private apiRequestService: ApiRequestService, private router: Router) { }

    login(userData: Login) {



    }

}