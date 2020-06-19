import { Injectable } from '@angular/core';
import * as jwt_decode from "jwt-decode";
import { OidcConfigService, OidcSecurityService, OpenIdConfiguration, ConfigResult } from 'angular-auth-oidc-client';
import { Claim } from './claim.model';
import { map, take } from 'rxjs/operators';
import { environment } from 'src/environments/environment';

export function loadConfig(oidcConfigService: OidcConfigService) {
    return () => oidcConfigService.load_using_stsServer(environment.stsBaseUrl);
}

@Injectable({ providedIn: 'root' })
export class AuthService {
    constructor(
        private oidcConfigService: OidcConfigService,
        public oidcSecurityService: OidcSecurityService) { }

    login() {
        this.oidcSecurityService.authorize();
    }

    logout() {
        this.oidcSecurityService.logoff();
    }
    onConfigurationLoaded() {
        return this.oidcConfigService.onConfigurationLoaded;
    }

    getIsAuthorized() {
        return this.oidcSecurityService.getIsAuthorized();
    }

    getUserData() {
        return this.oidcSecurityService.getUserData();
    }

    getToken() {
        return this.oidcSecurityService.getToken();
    }

    getClaims() {
        var result: Claim[] = [];
        return this.getIsAuthorized().pipe(map(() => {
            var token = this.getToken();
            if (token !== '') {
                var decodedToken = jwt_decode(token);
                for (var key in decodedToken) {
                    var currentValue = decodedToken[key];
                    if (Array.isArray(currentValue))
                        for (var i in currentValue) {
                            result.push(new Claim(key, currentValue[i]));
                        }
                    else
                        result.push(new Claim(key, currentValue));
                }
            }
            return result;
        }));
    }

    hasClaim(type: string, value: string) {
        return this.getClaims().pipe(take(1), map(claims => {
            return claims.some(c => c.Type === type && c.Value === value);
        }));
    }

    setupOidcSecurityModule() {
        this.oidcConfigService.onConfigurationLoaded.subscribe((configResult: ConfigResult) => {
            const config: OpenIdConfiguration = {
                stsServer: configResult.customConfig.stsServer,
                redirect_url: environment.baseUrl,
                post_logout_redirect_uri: environment.baseUrl,
                client_id: 'online-shopping-angular-app',
                scope: 'openid profile OnlineShoppingApi',
                response_type: 'code',
                silent_renew: true,
                silent_renew_url: environment.baseUrl + '/silent-renew.html',
                log_console_debug_active: !environment.production,
            };

            //config.start_checksession = true;
            //config.post_login_route = '/home';
            //config.forbidden_route = '/home';
            //config.unauthorized_route = '/home';
            //config.max_id_token_iat_offset_allowed_in_seconds = 5;
            //config.history_cleanup_off = true;

            this.oidcSecurityService.setupModule(config, configResult.authWellknownEndpoints);
        });
    }

    doCallbackLogicIfRequired() {
        if (this.oidcSecurityService.moduleSetup) {
            this.authorizedCallbackWithCode();
        } else {
            this.oidcSecurityService.onModuleSetup.subscribe(() => {
                this.authorizedCallbackWithCode();
            });
        }
    }

    private authorizedCallbackWithCode() {
        // Will do a callback, if the url has a code and state parameter.
        this.oidcSecurityService.authorizedCallbackWithCode(window.location.toString());
    }
}