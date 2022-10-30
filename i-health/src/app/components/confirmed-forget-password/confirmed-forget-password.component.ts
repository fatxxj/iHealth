import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { AuthService } from 'src/app/services/auth.service';
import { RestConnectorService } from 'src/app/services/rest-connector.service';
import { ChangePasswordFromForget } from 'src/app/models/change-password-through-forget.model'

@Component({
  selector: 'app-confirmed-forget-password',
  templateUrl: './confirmed-forget-password.component.html',
  styleUrls: ['./confirmed-forget-password.component.scss']
})
export class ConfirmedForgetPasswordComponent implements OnInit {
  form = new FormGroup({
    newPassword: new FormControl('', [Validators.required, Validators.pattern('^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$')]),
    confirmPassword: new FormControl('', Validators.required)
  })


  isMatch: boolean = true;
  userId!: number;
  token!: string;
  passwordChangedSuccessfully: boolean = false;
  constructor(private route: ActivatedRoute, private authService: AuthService, private restConnectorService: RestConnectorService, private router: Router) { }

  ngOnInit(): void {
  }
  changePassword() {
    if (this.form.controls['newPassword'].value !==
      this.form.controls['confirmPassword'].value) {
      this.isMatch = false;
    }
    else {
      this.isMatch = true;
      if (this.form.valid) {
        this.route.queryParams
          .subscribe(params => {
            this.userId = params['userId'];
            this.token = params['token'];
          });


        const userData: ChangePasswordFromForget = {
          userId: this.userId,
          password: this.form.get('newPassword')?.value,
          confirmPassword: this.form.get('confirmPassword')?.value,
          token: this.token
        }

        this.restConnectorService.changePasswordFromForget(userData).subscribe(result => {
          this.passwordChangedSuccessfully = true
        })
      }

    }
  }



  getErrorMessage(controlName: string, validationType: string) {
    return this.form.controls[controlName].hasError(validationType)
  }
}
