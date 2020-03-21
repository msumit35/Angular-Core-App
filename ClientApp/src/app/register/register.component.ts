import { Component, OnInit } from '@angular/core';
import { Register } from '../models/register.model';
import { UserService } from '../services/user.service';
import { Router } from '@angular/router';
import { MatDialog } from '@angular/material/dialog';
import { DialogComponent } from '../dialog/dialog.component';
import { DialogModel } from '../models/dialog.model';
import { SpinnerService } from '../services/spinner.service';
import { ToastrService } from 'ngx-toastr';

@Component({
    selector: 'app-register',
    templateUrl: 'register.component.html',
    styleUrls: ['register.component.css']
})
export class RegisterComponent implements OnInit {
    model: Register;
    step = 0;
    hide = true;
    constructor(private _userService: UserService, private _router: Router,
        public dialog: MatDialog,
        private _spinnerService: SpinnerService,
        private _toastrService: ToastrService) {

    }

    ngOnInit() {
        this.model = new Register();
    }

    OpenDialog() {
        var model = new DialogModel();
        model.Title = 'Success';
        model.Message = 'Congratulations! You are registered successfully';
        const dialogRef = this.dialog.open(DialogComponent, {
            width: '300px',
            height: '220px',
            data: model
        });

        dialogRef.afterClosed().subscribe((res) => {
            this._router.navigate(['/login']);
        });
    }

    onSubmit() {
        this.CreateUser();
    }

    CreateUser() {
        this._spinnerService.ProcessingOn();

        this._userService.CreateUser(this.model)
            .subscribe((response) => {
                this._spinnerService.ProcessingOff();
                if (response.Status != 200) {
                    //show error
                    this.model.Password = '';
                    this._toastrService.error(response.ErrorMessage, 'error');
                    return;
                }

                var toastr = this._toastrService.success('Congratulations! You are registered successfully. Redirecting to login page...',
                    'Success', { timeOut: 5000 });
                toastr.onHidden.subscribe((res) => {
                    this._router.navigate(['/login']);
                });
            },
                (error) => {
                    console.log('RegisterComponent->CreateUser()', error);
                    this._spinnerService.ProcessingOff();
                });
    }

    setStep(index: number) {
        this.step = index;
    }

    nextStep() {
        this.step++;
    }

    prevStep() {
        this.step--;
    }
}