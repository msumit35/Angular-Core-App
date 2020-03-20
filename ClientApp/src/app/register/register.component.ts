import { Component, OnInit } from '@angular/core';
import { Register } from '../models/register.model';
import { UserService } from '../services/user.service';
import { Router } from '@angular/router';

@Component({
    selector: 'app-register',
    templateUrl: 'register.component.html'
})
export class RegisterComponent implements OnInit {
    model: Register;

    constructor(private _userService: UserService, private _router: Router) {

    }

    ngOnInit() {
        this.model = new Register();
    }

    onSubmit() {
        this.CreateUser();
    }

    CreateUser(){
        this._userService.CreateUser(this.model)
            .subscribe((userId) => {
                this._router.navigate(['/']);
            },
            (error) => {
                console.log('RegisterComponent->CreateUser()', error);
            });
    }
}