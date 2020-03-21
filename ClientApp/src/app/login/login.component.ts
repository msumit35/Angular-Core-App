import { Component, OnInit } from '@angular/core';
import { LoginModel } from '../models/login.model';
import { AuthenticateService } from '../services/authenticate.service';
import { Router, ActivatedRoute } from '@angular/router';
import { SpinnerService } from '../services/spinner.service';
import { ToastrService } from 'ngx-toastr';

@Component({
    selector: 'app-login',
    templateUrl: './login.component.html',
    styleUrls: ['login.component.css']
})
export class LoginComponent implements OnInit {
    model: LoginModel;
    returnUrl: string;
    hide = true;
    constructor(private _authService: AuthenticateService,
        private _router: Router,
        private _activatedRoute: ActivatedRoute,
        private _spinnerService: SpinnerService,
        private _toastrService: ToastrService) {

        if (this._authService.CurrentUserValue) {
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
        this._spinnerService.ProcessingOn();

        this._authService.login(this.model)
            .subscribe((response) => {
                this._spinnerService.ProcessingOff();
                if (response.Status != 200) {
                    this._toastrService.error(response.ErrorMessage, 'Error');
                    this.model.Password = '';
                    return;
                }
                this._router.navigate(['/']);
            },
                (error) => {
                    this._spinnerService.ProcessingOff();
                    console.log('LoginComponent->onSubmit', error);
                });
    }
}