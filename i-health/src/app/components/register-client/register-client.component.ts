import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Router } from '@angular/router';
import { ApiRequestService } from 'src/app/services/api-request.service';

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
    password: new FormControl('', Validators.required),
    placeId: new FormControl()


  })

  constructor(private apiRequestService: ApiRequestService, private snackBar: MatSnackBar, private router: Router) { }

  ngOnInit(): void {
    this.apiRequestService.getUser(1).subscribe(result => {
      console.log(result);
    })
  }

  registerClient() {
    this.apiRequestService.registerClient(this.form.value).subscribe((result) => {
      console.log(result);
      // this.snackBar.open('Llogaria juaj u krijua me sukses', '', {
      //   duration: 2000,
      //   panelClass: ['snack-bar']
      // })

      this.router.navigate(['/login'])

    }, (error) => {
      console.log(error);
      this.snackBar.open('Ky email ekziston', '', {
        duration: 2000,
        panelClass: ['snack-bar-red']
      })

    }

    )


  }
}
