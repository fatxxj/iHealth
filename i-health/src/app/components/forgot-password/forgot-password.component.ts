import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { RestConnectorService } from 'src/app/services/rest-connector.service';

@Component({
  selector: 'app-forgot-password',
  templateUrl: './forgot-password.component.html',
  styleUrls: ['./forgot-password.component.scss']
})
export class ForgotPasswordComponent implements OnInit {
  form = new FormGroup({
    email: new FormControl('', [Validators.required, Validators.email])
  })

  checkYourEmail: boolean = false

  constructor(private restConnectorService: RestConnectorService) { }

  ngOnInit(): void {
  }
  forgotPassword() {
    if (this.form.valid) {
      this.restConnectorService.forgotPassword(this.form.controls['email'].value).subscribe(result => {

        this.checkYourEmail = true

      })
    }
  }

  getErrorMessage(controlName: string, validationType: string) {
    return this.form.controls[controlName].hasError(validationType);
  }
}
