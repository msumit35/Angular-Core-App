import { Component, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { ElectricityRechargeModel } from '../models/electricity-recharge.model';
import { PaymentModel, PaymentModule } from '../models/payment.model';
import { PaymentService } from '../services/payment.service';
import { MasterEntity } from '../models/master-entity.model';
import { ElectricityService } from '../services/electricity.service';
import { SpinnerService } from '../services/spinner.service';
import { ToastrService } from 'ngx-toastr';

@Component({
    selector: 'app-electricity-recharge-dialog',
    templateUrl: 'recharge.dialog.html'
})
export class ElectricityRechargeDialog {

    paymentModes: MasterEntity[];
    providers: MasterEntity[];
    rechargeModel: ElectricityRechargeModel;
    paymentModel: PaymentModel;

    constructor(
        public dialogRef: MatDialogRef<ElectricityRechargeDialog>,
        @Inject(MAT_DIALOG_DATA) public data: any,
        private _spinnerService: SpinnerService,
        private _toastrService: ToastrService,
        private _paymentService: PaymentService,
        private _electricityService: ElectricityService) {

            this.rechargeModel = new ElectricityRechargeModel();
            this.paymentModel = new PaymentModel();
            this.paymentModel.Module = PaymentModule.Electricity;
            this.paymentModel.ElectricityRecharge = this.rechargeModel;

            this._paymentService.GetPaymentModes().subscribe((response) => {
                this.paymentModes = response;
            });

            this._electricityService.GetProviders().subscribe((response) => {
                this.providers = response;
            })
         }

    closeDialog(data: any = null) {
        this.dialogRef.close(data);
    }

    onSubmit() {
        this._spinnerService.ProcessingOn();
        console.log('Make Payment Model..', this.paymentModel);
        this._paymentService.MakePayment(this.paymentModel)
          .subscribe((response) => {
            this._spinnerService.ProcessingOff();
            this._toastrService.success('Payment has been done successfully', 'Success');
            this.closeDialog(true);
            console.log('Electricity Response Make Payment->', response);
          },
          (error) => {
            this._spinnerService.ProcessingOff();
            this.dialogRef.close();
            console.log('ElectricityRechargeDialog->onSubmit', error);
          });
      }

}