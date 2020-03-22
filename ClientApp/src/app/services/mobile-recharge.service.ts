import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseUrl } from '../global.consts';
import { map } from 'rxjs/operators';
import { Observable } from 'rxjs';
import { MasterEntity } from '../models/master-entity.model';

@Injectable()
export class MobileService {
    controller = 'Mobile';

    constructor(private _http: HttpClient){
    }

    GetRechargeType(): Observable<MasterEntity[]> {
        return this._http.get(BaseUrl + this.controller + '/RechargeTypes')
                .pipe(map((response: any) => {
                    return response.Data;
                }));
    }

    GetServiceProviders(): Observable<MasterEntity[]> {
        return this._http.get(BaseUrl + this.controller + '/ServiceProviders')
                .pipe(map((response: any) => {
                    return response.Data;
                }));
    }
}