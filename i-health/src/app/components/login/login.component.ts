import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { LoginResponse } from 'src/app/models/login-response.model';
import { Login } from 'src/app/models/login.model';
import { RestConnectorService } from 'src/app/services/rest-connector.service';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {
  form = new FormGroup({

    email: new FormControl('', Validators.required),
    password: new FormControl('', Validators.required),

  })

  failedLogin: boolean = false
  constructor(private restConnectorService: RestConnectorService, private router: Router, private authService: AuthService) { }

  ngOnInit(): void {

  }
  login() {
    if (this.form.valid) {
      this.authService.login(this.form.value).subscribe((result: LoginResponse) => {
        console.log(result);

        //? kontrollon objektin a ka vler ose jo!
        if (result?.value?.user?.token) {

          this.router.navigate(['/home'])
        }
        else {
          this.failedLogin = true
        }
      })

    }

  }

  getErrorMessage(controlName: string, validationType: string) {
    return this.form.controls[controlName].hasError(validationType)


  }
}
