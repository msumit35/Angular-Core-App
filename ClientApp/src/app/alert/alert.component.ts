import { Component } from '@angular/core';
import { Message } from '../models/alert-message.model';
import { AlertService } from '../services/alert.service';

@Component({
    selector: 'app-alert',
    templateUrl: 'alert.component.html'
})
export class AlertComponent {
    message: Message;

    constructor(private _alertService: AlertService) {
        
        this._alertService.Message$.subscribe((message) => {

            if(message) {
                switch(message.Type) {
                    case 'success':
                        message.CssClass = 'alert alert-success';
                    case 'error':
                        message.CssClass = 'alert alert-danger';
                }
            }
            this.message = message;
        });
    }
}