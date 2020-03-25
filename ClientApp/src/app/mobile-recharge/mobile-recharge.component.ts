import { Component } from '@angular/core';
import { MobileService } from '../services/mobile-recharge.service';
import { MasterEntity } from '../models/master-entity.model';
import { RechargeDialog } from './recharge.dialog';
import { MatDialog } from '@angular/material/dialog';
import { MobileRechargeBillModel } from '../models/mobile-recharge-bill.model';
import { NavigationLinks } from '../app.navigation';
import { SidenavService } from '../services/sidenav.service';

@Component({
  selector: 'app-mobile-recharge',
  templateUrl: 'mobile-recharge.component.html',
  styleUrls: ['mobile-recharge.component.css']
})
export class MobileRechargeComponent {
  rechargeTypes: MasterEntity[];
  serviceProviders: MasterEntity[];
  bills: MobileRechargeBillModel[];

  constructor(public dialog: MatDialog, private _mobileService: MobileService,
            private _sidenavService: SidenavService) {

    this.getRechargeBills();
    _sidenavService.ActiveLink(NavigationLinks.MobileRecharge);
  }

  getRechargeBills() {
    this._mobileService.GetRechargeBills().subscribe((response) => {
      this.bills = response;
    });
  }

  openReachargeDialog(): void {
    const dialogRef = this.dialog.open(RechargeDialog, {
      width: '400px'
    });

    dialogRef.afterClosed().subscribe(result => {
      console.log('dialog closed', result);
      if (result)
        this.getRechargeBills();
    });
  }
}