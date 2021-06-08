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

    CreateElectricityProvider(model: any) {
        return this._http.post(BaseUrl + this.controller + '/Providers', model)
            .pipe(map((response: any) => {
                return response;
            }));
    }

    EditElectricityProvider(id: string, model: any) {
        return this._http.put(BaseUrl + this.controller + '/Providers/' + id, model)
            .pipe(map((response: any) => {
                return response.Data;
            }));
    }

    DeleteElectricityProvider(id: string) {
        return this._http.delete(BaseUrl + this.controller + '/Providers/' + id)
            .pipe(map((response: any) => {
                return response.Data;
            }));
    }
}