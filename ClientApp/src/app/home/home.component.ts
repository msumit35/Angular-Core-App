import { Component } from '@angular/core';
import { UserService } from '../services/user.service';
import { User } from '../models/user.model';

@Component({
    selector: 'app-home',
    templateUrl: '/home.component.html'
})
export class HomeComponent {
    users: User[];
    constructor(private _userService: UserService) {
        this.GetAllUsers();
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