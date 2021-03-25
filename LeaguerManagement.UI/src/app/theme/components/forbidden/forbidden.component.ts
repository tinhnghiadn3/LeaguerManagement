import {Component, OnInit} from '@angular/core';

import {AuthenticationService} from '@app/services/auth';

@Component({
  selector: 'app-forbidden',
  templateUrl: './forbidden.component.html',
  styleUrls: ['./forbidden.component.scss']
})
export class ForbiddenComponent implements OnInit {

  isLoggedIn: boolean = false;

  constructor(private authService: AuthenticationService) {
  }

  ngOnInit() {
    this.isLoggedIn = this.authService.isLoggedIn();
  }

  logout(e) {
    e.stopPropagation();
    e.preventDefault();
    this.authService.logout();
  }
}
