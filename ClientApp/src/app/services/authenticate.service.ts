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
                    .pipe(map((user: User) => {
                        localStorage.setItem(this._localStorageUserKey, JSON.stringify(user));
                        this._currentUserSubject.next(user);
                        return user;
                    }));
    }

    logout() {
        localStorage.removeItem(this._localStorageUserKey);
        this._currentUserSubject.next(null);
    }

}