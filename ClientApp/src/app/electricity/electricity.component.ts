import { Component, OnInit, ViewChild } from '@angular/core';
import { SidenavService } from '../services/sidenav.service';
import { NavigationLinks } from '../app.navigation';
import { MatDialog } from '@angular/material/dialog';
import { ElectricityRechargeDialog } from './recharge.dialog';
import { ElectricityService } from '../services/electricity.service';
import { ElectricityBillModel } from '../models/electricity-bill.model';
import { MatTableDataSource } from '@angular/material/table';
import { MatPaginator } from '../../../node_modules/@angular/material/paginator';

@Component({
    selector: 'app-electricity',
    templateUrl: 'electricity.component.html'
})
export class ElectricityComponent implements OnInit {
    dataSource: MatTableDataSource<ElectricityBillModel>;
    @ViewChild(MatPaginator) paginator: MatPaginator;

    constructor(private _dialog: MatDialog, private _sidenavService: SidenavService,
                private _electricityService: ElectricityService) {

        _sidenavService.ActiveLink(NavigationLinks.Electricity);
        this.getElectricityRechargeBills();
    }

    ngOnInit() {
        this.dataSource = new MatTableDataSource([]);
        this.dataSource.paginator = this.paginator;
    }

    getElectricityRechargeBills() {
        this._electricityService.GetElectricityBills().subscribe((response) => {
            this.dataSource.data = response;
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