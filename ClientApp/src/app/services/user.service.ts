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
        return this._http.get<User[]>(BaseUrl + this.controller + '/GetAllUsers')
                .pipe(map((response: any) => {
                    return response.Data;
                }));
    }

    CreateUser(model: Register): Observable<any> {
        return this._http.post(BaseUrl + this.controller + '/CreateUser', model)
            .pipe(map((response) => {
                return response;
            }));
    }

    EditUser(id: string, model: User) {
        return this._http.put(BaseUrl + this.controller + '/EditUser/' + id, model)
            .pipe(map((response: any) => {
                return response.Data;
            }));
    }

    ActivateUser(id: string) {
        return this._http.options(BaseUrl + this.controller + '/Activate/' + id)
            .pipe(map((response: any) => {
                return response.Data;
            }));
    }

    DeactivateUser(id: string) {
        return this._http.delete(BaseUrl + this.controller + '/Deactivate/' + id)
            .pipe(map((response: any) => {
                return response.Data;
            }));
    }
}