import { Component, OnInit } from '@angular/core';
import { OidcConfigService, OidcSecurityService, ConfigResult } from 'angular-auth-oidc-client';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  isAuthenticated: boolean;
  isConfigurationLoaded: boolean;
  userData: any;

  constructor(private oidcConfigService: OidcConfigService, public oidcSecurityService: OidcSecurityService) { }

  ngOnInit() {
    this.oidcConfigService.onConfigurationLoaded.subscribe((value: ConfigResult) => {
      this.isConfigurationLoaded = true;
    });

    this.oidcSecurityService.getIsAuthorized().subscribe(auth => {
      this.isAuthenticated = auth;
    });

    this.oidcSecurityService.getUserData().subscribe(userData => {
      this.userData = userData;
    });
  }

  login() {
    this.oidcSecurityService.authorize();
  }

  logout() {
    this.oidcSecurityService.logoff();
  }

}
