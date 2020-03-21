import { HttpClient } from '@angular/common/http';
import { BaseUrl } from '../global.consts';
import { map } from 'rxjs/operators';
import { User } from '../models/user.model';
import { Injectable } from '@angular/core';
import { Register } from '../models/register.model';
import { Observable } from 'rxjs';

@Injectable()
export class UserService {
    controller = 'user';
    constructor(private _http: HttpClient){

    }

    GetAllUsers() {
        return this._http.get<User[]>(BaseUrl + this.controller + '/GetAllUsers');
    }

    CreateUser(model: Register): Observable<any> {
        return this._http.post(BaseUrl + this.controller + '/CreateUser', model)
            .pipe(map((response) => {
                return response;
            }));
    }
}