import { Injectable } from "@angular/core";
import { User } from "../models/user.model";
import { HttpClient } from "@angular/common/http";
import { Login } from "../models/login.model";



@Injectable({
    providedIn: 'root'
})
export class ApiRequestService {
    URLRequest: string = 'https://localhost:5100/api/Users/';

    constructor(private http: HttpClient) { }

    registerClient(userData: User) {
        return this.http.post<User>(this.URLRequest + 'CreateUser', userData)
    }

    login(userData: Login) {
        return this.http.post<Login>(this.URLRequest + 'Login', userData)
    }

    getUser(id: number) {
        return this.http.get(this.URLRequest + 'GetUser', {
            params: {
                id: id
            }
        })
    }
}

