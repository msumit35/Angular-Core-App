import { HttpInterceptor, HttpRequest, HttpHandler, HttpEvent } from '@angular/common/http'
import { AuthenticateService } from '../services/authenticate.service';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable()
export class JwtInterceptor implements HttpInterceptor {
    constructor(private _authService: AuthenticateService){

    }

    intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        const userValue = this._authService.CurrentUserValue;

        if(userValue && userValue.Token) {
            request = request.clone({
                setHeaders: {
                    Authorization: `Bearer ${userValue.Token}`
                }
            });
        }
        
        return next.handle(request);
    }
}