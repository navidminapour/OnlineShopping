import { Component, OnInit } from '@angular/core';
import { AuthService } from 'src/app/auth/auth.service';
import { ConfigResult } from 'angular-auth-oidc-client';

@Component({
  selector: 'app-top-bar',
  templateUrl: './top-bar.component.html',
  styleUrls: ['./top-bar.component.css']
})
export class TopBarComponent implements OnInit {
  isAuthenticated: boolean;
  isConfigurationLoaded: boolean;
  userData: any;
  
  constructor(private authService: AuthService) { }

  ngOnInit() {
    this.authService.onConfigurationLoaded().subscribe((value: ConfigResult) => {
      this.isConfigurationLoaded = true;
    });

    this.authService.getIsAuthorized().subscribe(auth => {
      this.isAuthenticated = auth;
      this.authService.getClaims();
    });

    this.authService.getUserData().subscribe(userData => {
      this.userData = userData;
    });
  }

  login() {
    this.authService.login();
  }

  logout() {
    this.authService.logout();
  }

}
