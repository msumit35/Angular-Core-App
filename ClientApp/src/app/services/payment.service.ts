import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseUrl } from '../global.consts';
import { map } from 'rxjs/operators';
import { MasterEntity } from '../models/master-entity.model';
import { Observable } from 'rxjs';

@Injectable()
export class PaymentService {
    controller = 'Payment';

    constructor(private _http: HttpClient) {

    }

    GetPaymentModes(): Observable<MasterEntity[]> {
        return this._http.get(BaseUrl + this.controller + '/Modes')
            .pipe(map((response: any) => {
                return response.Data;
            }));
    }

    MakePayment(model: any) {
        return this._http.post(BaseUrl + this.controller + '/MakePayment', model)
            .pipe(map((response) => {
                return response;
            }));
    }
}