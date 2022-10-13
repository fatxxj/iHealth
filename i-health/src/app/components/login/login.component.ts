import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { Login } from 'src/app/models/login.model';
import { ApiRequestService } from 'src/app/services/api-request.service';

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
  constructor(private apiRequestService: ApiRequestService, private router: Router) { }

  ngOnInit(): void {
  }
  login() {
    this.apiRequestService.login(this.form.value).subscribe((result: Login) => {
      console.log(result);
      this.router.navigate(['/home'])

    })

  }
}
