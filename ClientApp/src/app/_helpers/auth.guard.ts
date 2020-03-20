import { Injectable } from '@angular/core';
import { Router, ActivatedRouteSnapshot, RouterStateSnapshot, CanActivate } from '@angular/router';
import { AuthenticateService } from '../services/authenticate.service';

@Injectable({
    providedIn: 'root'
})
export class AuthGuard implements CanActivate {

    constructor(private _router: Router, private _authService: AuthenticateService) {    
    }

    canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot) {
        const userValue = this._authService.CurrentUserValue;
        if(userValue) {
            return true;
        }

        this._router.navigate(['/login'], { queryParams: { reutrnUrl: state.url } });
        return false;
    }
}