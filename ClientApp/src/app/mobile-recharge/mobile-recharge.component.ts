import { Component } from '@angular/core';
import { MobileService } from '../services/mobile-recharge.service';
import { MasterEntity } from '../models/master-entity.model';
import { RechargeDialog } from './recharge.dialog';
import { MatDialog } from '@angular/material/dialog';

@Component({
    selector: 'app-mobile-recharge',
    templateUrl: 'mobile-recharge.component.html'
})
export class MobileRechargeComponent {
    rechargeTypes: MasterEntity[];
    serviceProviders: MasterEntity[];
    constructor(public dialog: MatDialog) {
    }

  openReachargeDialog(): void {
    const dialogRef = this.dialog.open(RechargeDialog, {
      width: '400px'
    });

    dialogRef.afterClosed().subscribe(result => {
      console.log('The dialog was closed');
    });
  }
}