import { Component, OnInit, ViewChild } from '@angular/core';
import { UserService } from '../services/user.service';
import { User } from '../models/user.model';
import { SidenavService } from '../services/sidenav.service';
import { NavigationLinks } from '../app.navigation';
import { MatTableDataSource } from '@angular/material/table';
import { MatPaginator } from '@angular/material/paginator';
import { MatDialog } from '@angular/material/dialog';
import { EditUserDialog } from './edit-user.dialog';
import { ToastrService } from 'ngx-toastr';
import { SpinnerComponent } from '../spinner/spinner.component';
import { SpinnerService } from '../services/spinner.service';
import { map } from '../../../node_modules/rxjs/operators';

@Component({
    selector: 'app-home',
    templateUrl: '/home.component.html'
})
export class HomeComponent implements OnInit {
    dataSource: MatTableDataSource<User>;
    @ViewChild(MatPaginator) paginator: MatPaginator;

    constructor(private _userService: UserService, private _sidenav: SidenavService,
        private _dialog: MatDialog, private _toastrService: ToastrService,
        private _spinnerService: SpinnerService) {
        this.GetAllUsers();
        this._sidenav.ActiveLink(NavigationLinks.Home);
    }

    ngOnInit() {
        this.dataSource = new MatTableDataSource([]);
        this.dataSource.paginator = this.paginator;
    }

    OpenEditUserDialog(data: any) {
        let dialog = this._dialog.open(EditUserDialog, {
            width: '400px',
            data: data
        });

        dialog.afterClosed().subscribe((data: any) => {
            if (data)
                this.GetAllUsers();
        });
    }

    GetAllUsers() {
        this._userService.GetAllUsers()
            .subscribe((response) => {
                this.dataSource.data = response;
            },
                (error) => {
                    console.log('HomeComponent-GetAllUsers', error);
                });
    }

    ActivateUser(id: string) {
        this._spinnerService.ProcessingOn();

        this._userService.ActivateUser(id)
            .subscribe((response) => {
                this._spinnerService.ProcessingOff();
                this._toastrService.info('User has been activated', 'Info');
                this.GetAllUsers();
            });
    }

    DeactivateUser(id: string) {
        this._spinnerService.ProcessingOn();

        this._userService.DeactivateUser(id)
            .subscribe((response) => {
                this._spinnerService.ProcessingOff();
                this._toastrService.warning('User has been deactivated', 'Warning');
                this.GetAllUsers();
            });
    }

    DeleteUser(id: string) {
        this._spinnerService.ProcessingOn();

        this._userService.DeleteUser(id)
            .subscribe((response) => {
                this._spinnerService.ProcessingOff();
                this._toastrService.warning('User has been deleted', 'Warning');
                this.GetAllUsers();
            });
    }

    UnDeleteUser(id: string) {
        this._spinnerService.ProcessingOn();

        this._userService.UnDeleteUser(id)
            .subscribe((response) => {
                this._spinnerService.ProcessingOff();
                this._toastrService.warning('User has been undeleted', 'Warning');
                this.GetAllUsers();
            });
    }
}