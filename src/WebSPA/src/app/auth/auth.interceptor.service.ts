import { HttpInterceptor, HttpRequest, HttpHandler, HttpEvent } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { AuthService } from './auth.service';

@Injectable()
export class AuthInterceptorService implements HttpInterceptor {

    constructor(private authService: AuthService) { }

    intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        let requestToForward = req;

        let token = this.authService.getToken();
        if (token !== '') {
            let tokenValue = 'Bearer ' + token;
            requestToForward = req.clone({ setHeaders: { Authorization: tokenValue } });
        }
        
        return next.handle(requestToForward);
    }
}