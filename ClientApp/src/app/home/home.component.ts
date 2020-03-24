import { Component } from '@angular/core';
import { UserService } from '../services/user.service';
import { User } from '../models/user.model';
import { SidenavService } from '../services/sidenav.service';
import { SidenavLinks } from '../models/sidenav.enum';

@Component({
    selector: 'app-home',
    templateUrl: '/home.component.html'
})
export class HomeComponent {
    users: User[];
    constructor(private _userService: UserService, private _sidenav: SidenavService) {
        this.GetAllUsers();
        _sidenav.ActiveLink(SidenavLinks.Home);
    }

    GetAllUsers() {
        this._userService.GetAllUsers()
            .subscribe((response) => {
                this.users = response;
            },
            (error) => {
                console.log('HomeComponent-GetAllUsers', error);
            })
    }
}