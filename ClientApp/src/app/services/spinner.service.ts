import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';

@Injectable()
export class SpinnerService {
    private _isProcessingSubject: BehaviorSubject<boolean>;
    public IsPorcessing$: Observable<boolean>;

    constructor(){
        this._isProcessingSubject = new BehaviorSubject<boolean>(false);
        this.IsPorcessing$ = this._isProcessingSubject.asObservable();
    }

    ProcessingOn() {
        this._isProcessingSubject.next(true);
    }

    ProcessingOff() {
        this._isProcessingSubject.next(false);
    }
}