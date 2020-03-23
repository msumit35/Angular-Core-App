import { Component } from '@angular/core';
import { MobileService } from '../services/mobile-recharge.service';
import { MasterEntity } from '../models/master-entity.model';
import { RechargeDialog } from './recharge.dialog';
import { MatDialog } from '@angular/material/dialog';
import { MobileRechargeBillModel } from '../models/mobile-recharge-bill.model';

@Component({
  selector: 'app-mobile-recharge',
  templateUrl: 'mobile-recharge.component.html'
})
export class MobileRechargeComponent {
  rechargeTypes: MasterEntity[];
  serviceProviders: MasterEntity[];
  bills: MobileRechargeBillModel[];

  constructor(public dialog: MatDialog, private _mobileService: MobileService) {

    this._mobileService.GetRechargeBills().subscribe((response) => {
      this.bills = response;
    });
  }

  openReachargeDialog(): void {
    const dialogRef = this.dialog.open(RechargeDialog, {
      width: '400px'
    });

    // dialogRef.afterClosed().subscribe(result => {
    //   console.log('The dialog was closed');
    // });
  }
}