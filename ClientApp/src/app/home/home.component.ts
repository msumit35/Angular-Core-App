import { Component, OnInit, ViewChild } from '@angular/core';
import { UserService } from '../services/user.service';
import { User } from '../models/user.model';
import { SidenavService } from '../services/sidenav.service';
import { NavigationLinks } from '../app.navigation';
import { MatTableDataSource } from '@angular/material/table';
import { MatPaginator } from '@angular/material/paginator';
import { MatDialog } from '../../../node_modules/@angular/material/dialog';
import { EditUserDialog } from './edit-user.dialog';

@Component({
    selector: 'app-home',
    templateUrl: '/home.component.html'
})
export class HomeComponent implements OnInit {
    dataSource: MatTableDataSource<User>;
    @ViewChild(MatPaginator) paginator: MatPaginator;

    constructor(private _userService: UserService, private _sidenav: SidenavService,
        private _dialog: MatDialog) {
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
}