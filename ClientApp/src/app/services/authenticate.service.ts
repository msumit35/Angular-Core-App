import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BehaviorSubject, Observable } from 'rxjs';
import { map } from 'rxjs/operators';

import { Authenticate } from '../models/authenticate.model';
import { BaseUrl } from '../global.consts';
import { User } from '../models/user.model';
import { LoginModel } from '../models/login.model';

@Injectable()
export class AuthenticateService{

    private _localStorageUserKey = 'currentUser';
    private _currentUserSubject: BehaviorSubject<User>;
    public CurrentUser: Observable<User>;

    constructor(private _http: HttpClient){
        this._currentUserSubject = new BehaviorSubject<User>(JSON.parse(localStorage.getItem(this._localStorageUserKey)));
        this.CurrentUser = this._currentUserSubject.asObservable();
    }

    public get CurrentUserValue(): User {
        return this._currentUserSubject.value;
    }

    login(model: LoginModel) {
        return this._http.post(BaseUrl + 'Authenticate/CreateToken', model)
                    .pipe(map((response: any) => {
                        if(response.Status == 200) {
                            localStorage.setItem(this._localStorageUserKey, JSON.stringify(response.Data));
                            this._currentUserSubject.next(response.Data);
                        }

                        return response;
                    }));
    }

    logout() {
        localStorage.removeItem(this._localStorageUserKey);
        this._currentUserSubject.next(null);
    }

}