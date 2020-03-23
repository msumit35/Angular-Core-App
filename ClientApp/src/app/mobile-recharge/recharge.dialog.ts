import { Component, Inject } from '@angular/core';
import { MatDialog, MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { RechargeModel } from '../models/recharge.model';
import { MasterEntity } from '../models/master-entity.model';
import { MobileService } from '../services/mobile-recharge.service';
import { PaymentService } from '../services/payment.service';
import { PaymentModel, PaymentModule } from '../models/payment.model';
import { SpinnerService } from '../services/spinner.service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-recharge-dialog',
  templateUrl: 'recharge.dialog.html',
  styleUrls: ['mobile-recharge.component.css']
})
export class RechargeDialog {
  paymentModel: PaymentModel;
  rechargeModel: RechargeModel;
  rechargeTypes: MasterEntity[];
  serviceProviders: MasterEntity[];
  paymentModes: MasterEntity[];

  constructor(
    public dialogRef: MatDialogRef<RechargeDialog>,
    @Inject(MAT_DIALOG_DATA) public data: any,
    private _mobileService: MobileService,
    private _paymentService: PaymentService,
    private _spinnerService: SpinnerService,
    private _toastrService: ToastrService) {

    this.rechargeModel = new RechargeModel();
    this.paymentModel = new PaymentModel();
    this.paymentModel.Module = PaymentModule.MobileRecharge;
    this.paymentModel.MobileRecharge = this.rechargeModel;

    this._mobileService.GetRechargeType().subscribe((response) => {
      this.rechargeTypes = response;
      console.log('Recharge types', this.rechargeTypes);
    });

    this._mobileService.GetServiceProviders().subscribe((response) => {
      this.serviceProviders = response;
      console.log('Service Providers', this.serviceProviders);
    });

    this._paymentService.GetPaymentModes().subscribe((response) => {
      this.paymentModes = response;
      console.log('Modes', this.paymentModes);
    });
  }

  closeDialog() {
    this.dialogRef.close();
  }

  onSubmit() {
    this._spinnerService.ProcessingOn();
    console.log('Make Payment Model..', this.paymentModel);
    this._paymentService.MakePayment(this.paymentModel)
      .subscribe((response) => {
        this._spinnerService.ProcessingOff();
        this._toastrService.success('Payment has been done successfully', 'Success');
        console.log('Response Make Payment->', response);
      },
      (error) => {
        this._spinnerService.ProcessingOff();
        console.log('RechargeDialog->onSubmit', error);
      });
  }
}