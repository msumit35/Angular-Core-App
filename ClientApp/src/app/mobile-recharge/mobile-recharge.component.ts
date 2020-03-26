import { Component, ViewChild, OnInit } from '@angular/core';
import { MobileService } from '../services/mobile-recharge.service';
import { MasterEntity } from '../models/master-entity.model';
import { RechargeDialog } from './recharge.dialog';
import { MatDialog } from '@angular/material/dialog';
import { MobileRechargeBillModel } from '../models/mobile-recharge-bill.model';
import { NavigationLinks } from '../app.navigation';
import { SidenavService } from '../services/sidenav.service';
import { MatTableDataSource } from '@angular/material/table';
import { MatPaginator } from '@angular/material/paginator';

@Component({
  selector: 'app-mobile-recharge',
  templateUrl: 'mobile-recharge.component.html',
  styleUrls: ['mobile-recharge.component.css']
})
export class MobileRechargeComponent implements OnInit {
  dataSource: MatTableDataSource<MobileRechargeBillModel>;
  @ViewChild(MatPaginator) paginator: MatPaginator;

  constructor(public dialog: MatDialog, private _mobileService: MobileService,
            private _sidenavService: SidenavService) {

    this.getRechargeBills();
    this._sidenavService.ActiveLink(NavigationLinks.MobileRecharge);

    this.dataSource = new MatTableDataSource([]);
  }
  
  ngOnInit() {
    this.dataSource.paginator = this.paginator;
  }

  getRechargeBills() {
    this._mobileService.GetRechargeBills().subscribe((response) => {
      this.dataSource.data = response;
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