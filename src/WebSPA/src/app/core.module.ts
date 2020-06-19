import { APP_INITIALIZER, NgModule } from '@angular/core';
import { HTTP_INTERCEPTORS } from '@angular/common/http';
import { AuthInterceptorService } from './auth/auth.interceptor.service';
import { AuthModule, OidcConfigService } from 'angular-auth-oidc-client';
import { AuthService, loadConfig } from './auth/auth.service';



@NgModule({
    imports:[
        AuthModule.forRoot(),
    ],
    providers: [
        OidcConfigService,
        {
            provide: APP_INITIALIZER,
            useFactory: loadConfig,
            deps: [OidcConfigService],
            multi: true,
        },
        {
            provide: HTTP_INTERCEPTORS,
            useClass: AuthInterceptorService,
            multi: true
        }
    ]
})
export class CoreModule {
    constructor(private authService: AuthService) {
        this.authService.setupOidcSecurityModule();
    }
 }