import { Component, OnInit } from '@angular/core';
import { LoginModel } from '../models/login.model';
import { AuthenticateService } from '../services/authenticate.service';
import { Router, ActivatedRoute } from '@angular/router';

@Component({
    selector: 'app-login',
    templateUrl: './login.component.html'
})
export class LoginComponent implements OnInit{
    model: LoginModel;
    returnUrl: string;

    constructor(private _authService: AuthenticateService,
                private _router: Router,
                private _activatedRoute: ActivatedRoute) {
        
            if(this._authService.CurrentUserValue) {
                this._router.navigate(['/']);
            }
    }

    ngOnInit() {
        this.model = new LoginModel();
        this.model.Email = '';
        this.model.Username = '';
        this.model.Password = '';

        this.returnUrl = this._activatedRoute.snapshot.queryParams['returnUrl'] || '/';
    }

    onSubmit() {
        console.log('model', this.model);
        this._authService.login(this.model)
            .subscribe((response) => {
                this._router.navigate(['/']);
            },
            (error) => {
                console.log(error);
            });
    }
}