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

    CreatePaymentMode(model: any) {
        return this._http.post(BaseUrl + this.controller + '/Modes', model)
            .pipe(map((response: any) => {
                return response;
            }));
    }

    EditPaymentMode(id: string, model: any) {
        return this._http.put(BaseUrl + this.controller + '/Modes/' + id, model)
            .pipe(map((response: any) => {
                return response.Data;
            }));
    }

    DeletePaymentMode(id: string) {
        return this._http.delete(BaseUrl + this.controller + '/Modes/' + id)
            .pipe(map((response: any) => {
                return response.Data;
            }));
    }
}