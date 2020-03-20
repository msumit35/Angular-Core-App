import { HttpClient } from '@angular/common/http';
import { BaseUrl } from '../global.consts';
import { map } from 'rxjs/operators';
import { User } from '../models/user.model';
import { Injectable } from '@angular/core';
import { Register } from '../models/register.model';

@Injectable()
export class UserService {
    controller = 'user';
    constructor(private _http: HttpClient){

    }

    GetAllUsers() {
        return this._http.get<User[]>(BaseUrl + this.controller + '/GetAllUsers');
    }

    CreateUser(model: Register) {
        return this._http.post(BaseUrl + this.controller + '/CreateUser', model)
            .pipe(map((userId) => {
                return userId;
            }));
    }
}