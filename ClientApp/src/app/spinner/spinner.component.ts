import { Component } from '@angular/core';
import { SpinnerService } from '../services/spinner.service';

@Component({
    selector: 'app-spinner',
    templateUrl: 'spinner.component.html'
})
export class SpinnerComponent {
    public isProcessing = false;
    constructor(private _spinnerService: SpinnerService){
        this._spinnerService.IsPorcessing$.subscribe((value) => {
            this.isProcessing = value;
        });
    }
}