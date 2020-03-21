import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { Message } from '../models/alert-message.model';

@Injectable()
export class AlertService {
    private _messageSubject: BehaviorSubject<Message>;
    public Message$: Observable<Message>;

    constructor(){
        this._messageSubject = new BehaviorSubject<Message>(null);
        this.Message$ = this._messageSubject.asObservable();
    }

    ShowMessage(message: Message) {
        this._messageSubject.next(message);
    }
}