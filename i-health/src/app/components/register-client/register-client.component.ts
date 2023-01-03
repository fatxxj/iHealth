import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Router } from '@angular/router';
import { RestConnectorService } from 'src/app/services/rest-connector.service';

@Component({
  selector: 'app-register-client',
  templateUrl: './register-client.component.html',
  styleUrls: ['./register-client.component.scss']
})
export class RegisterClientComponent implements OnInit {
  form = new FormGroup({
    name: new FormControl('', Validators.required),
    surname: new FormControl('', Validators.required),
    email: new FormControl('', Validators.required),
    password: new FormControl('', [Validators.required, Validators.pattern('^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$')]),
    placeId: new FormControl()


  })

  constructor(private restConnectorService: RestConnectorService, private snackBar: MatSnackBar, private router: Router) { }

  ngOnInit(): void {

  }

  registerClient() {
    if (this.form.valid) {
      this.restConnectorService.registerClient(this.form.value).subscribe((result) => {
        console.log(result);
        this.snackBar.open('Llogaria juaj u krijua me sukses', '', {
          duration: 2000,
          panelClass: ['snack-bar']
        })

        this.router.navigate(['/login'])

      },

        (error) => {
          console.log(error);
          this.snackBar.open('This email exist', '', {
            duration: 2000,
            panelClass: ['snack-bar-red']
          })

        }
      )
    }

  }
  getErrorMessage(controlName: string, validationType: string) {
    return this.form.controls[controlName].hasError(validationType)
  }
}
