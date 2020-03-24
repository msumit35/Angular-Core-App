import { HttpInterceptor, HttpRequest, HttpHandler, HttpEvent } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { AuthenticateService } from '../services/authenticate.service';
import { Injectable } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { SpinnerService } from '../services/spinner.service';

@Injectable()
export class ErrorEnterceptor implements HttpInterceptor {

    constructor(private _authService: AuthenticateService,
                private _toastrService: ToastrService,
                private _spinnerService: SpinnerService){}

    intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        return next.handle(request).pipe(catchError(err => {
            if(err.status === 401) {
                this._authService.logout();
                location.reload();
            }
            this._spinnerService.ProcessingOff();
            this._toastrService.error('Something went wrong', 'Error');
            const error = err.error.message || err.statusText;
            return  throwError(error);
        }));
    }
}