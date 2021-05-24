import { HttpClient } from '@angular/common/http';
import { BaseUrl } from '../global.consts';
import { map } from 'rxjs/operators';
import { MasterEntity } from '../models/master-entity.model';
import { Observable } from 'rxjs';
import { Injectable } from '../../../node_modules/@angular/core';
import { ElectricityBillModel } from '../models/electricity-bill.model';

@Injectable()
export class ElectricityService {
    private controller = 'Electricity';

    constructor(private _http: HttpClient) {

    }

    GetProviders(): Observable<MasterEntity[]> {
        return this._http.get(BaseUrl + this.controller + '/Providers')
                    .pipe(map((response: any) => {
                        return response.Data;
                    }));
    }

    GetElectricityBills(): Observable<ElectricityBillModel[]> {
        return this._http.get(BaseUrl + this.controller + '/ElectricityPayments')
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
}