import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})

export class AppComponent implements OnInit {
  title = 'i-health';

  showHeader: boolean = true;
  isUserLoggedIn: boolean = false;
  constructor() { }

  ngOnInit(): void {


  }
}


