import { Injectable } from "@angular/core";
import { User } from "../models/user.model";
import { HttpClient } from "@angular/common/http";
import { Login } from "../models/login.model";
import { LoginResponse } from "../models/login-response.model";
import { ForgotPassword } from "../models/forgot-password.model";
import { ChangePasswordFromForget } from "../models/change-password-through-forget.model";



@Injectable({
    providedIn: 'root'
})
export class RestConnectorService {
    URLRequest: string = 'https://localhost:5100/api/Users/';

    constructor(private http: HttpClient) { }

    registerClient(userData: User) {
        return this.http.post<User>(this.URLRequest + 'CreateUser', userData)
    }

    login(userData: Login) {
        return this.http.post<LoginResponse>(this.URLRequest + 'Login', userData)
    }

    getUser(id: number) {
        return this.http.get(this.URLRequest + 'GetUser', {
            params: {
                id: id
            }
        })
    }

    forgotPassword(email: string) {
        return this.http.post(this.URLRequest + 'ForgotPassword', null, {
            params: {
                email: email
            }
        })
    }
    changePasswordFromForget(userData: ChangePasswordFromForget) {
        return this.http.post(this.URLRequest + 'ChangePasswordThroughForget', userData)
    }
}

