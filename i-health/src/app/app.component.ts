import { Component, OnInit } from '@angular/core';
import { NavigationStart, Router } from '@angular/router';
import { filter } from 'rxjs';
import { AuthService } from './services/auth.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})

export class AppComponent implements OnInit {
  title = 'i-health';

  isUserLoggedIn: boolean = false;
  showHeader: boolean = true;

  constructor(private authService: AuthService, private router: Router) {

    this.router.events
      .pipe(filter(event => event instanceof NavigationStart))
      .subscribe((route: any) => {
        if (route.url === '/login' || route.url === '/register-client') {
          this.showHeader = false;
        }
        else {
          this.showHeader = true;
        }
      })
  }

  ngOnInit(): void {
    if (this.authService.getToken()) {
      this.isUserLoggedIn = true
    }

    this.authService.isUserLoggedIn.subscribe(result => {
      this.isUserLoggedIn = true
    })
  }

  logout() {
    this.authService.logout();
    this.isUserLoggedIn = false;
  }
}


