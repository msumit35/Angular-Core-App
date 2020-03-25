import { Component } from '@angular/core';
import { SidenavService } from '../services/sidenav.service';
import { NavigationLinks } from '../app.navigation';
import { MatDialog } from '@angular/material/dialog';
import { ElectricityRechargeDialog } from './recharge.dialog';
import { ElectricityService } from '../services/electricity.service';
import { ElectricityBillModel } from '../models/electricity-bill.model';

@Component({
    selector: 'app-electricity',
    templateUrl: 'electricity.component.html'
})
export class ElectricityComponent {
    bills: ElectricityBillModel[];

    constructor(private _dialog: MatDialog, private _sidenavService: SidenavService,
                private _electricityService: ElectricityService) {

        _sidenavService.ActiveLink(NavigationLinks.Electricity);
        this.getElectricityRechargeBills();
    }

    getElectricityRechargeBills() {
        this._electricityService.GetElectricityBills().subscribe((response) => {
            this.bills = response;
        });
    }

    openReachargeDialog(): void {
        const dialogRef = this._dialog.open(ElectricityRechargeDialog, {
            width: '400px'
        });

        dialogRef.afterClosed().subscribe(result => {
            console.log('dialog closed', result);
            if (result)
                this.getElectricityRechargeBills();
        });
    }
}