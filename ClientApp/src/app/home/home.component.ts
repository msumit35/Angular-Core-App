import { Component } from '@angular/core';
import { UserService } from '../services/user.service';
import { User } from '../models/user.model';
import { SidenavService } from '../services/sidenav.service';
import { NavigationLinks } from '../app.navigation';

@Component({
    selector: 'app-home',
    templateUrl: '/home.component.html'
})
export class HomeComponent {
    users: User[];
    constructor(private _userService: UserService, private _sidenav: SidenavService) {
        this.GetAllUsers();
        _sidenav.ActiveLink(NavigationLinks.Home);
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