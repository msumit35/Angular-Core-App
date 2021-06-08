import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseUrl } from '../global.consts';
import { map } from 'rxjs/operators';
import { Observable } from 'rxjs';
import { MasterEntity } from '../models/master-entity.model';
import { MobileRechargeBillModel } from '../models/mobile-recharge-bill.model';

@Injectable()
export class MobileService {
    private controller = 'Mobile';

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

    GetRechargeBills(): Observable<MobileRechargeBillModel[]> {
        return this._http.get(BaseUrl + this.controller + '/RechargePayments')
                .pipe(map((response: any) => {
                    return response.Data;
                }));
    }

    MakePayment(model: any) {
        return this._http.post(BaseUrl + this.controller + '/MakePayment', model)
            .pipe(map((response: any) => {
                return response;
            }));
    }

    CreateServiceProvider(model: any) {
        return this._http.post(BaseUrl + this.controller + '/ServiceProviders', model)
            .pipe(map((response: any) => {
                return response;
            }));
    }

    EditServiceProvider(id: string, model: any) {
        return this._http.put(BaseUrl + this.controller + '/ServiceProviders/' + id, model)
            .pipe(map((response: any) => {
                return response.Data;
            }));
    }

    DeleteServiceProvider(id: string) {
        return this._http.delete(BaseUrl + this.controller + '/ServiceProviders/' + id)
            .pipe(map((response: any) => {
                return response.Data;
            }));
    }
}