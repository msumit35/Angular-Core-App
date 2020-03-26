import { Component, Inject } from '@angular/core';
import { User } from '../models/user.model';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { SpinnerService } from '../services/spinner.service';
import { ToastrService } from 'ngx-toastr';
import { UserService } from '../services/user.service';

@Component({
    selector: 'edit-user-dialog',
    templateUrl: 'edit-user.dialog.html'
})
export class EditUserDialog {
    user: User;
    masterUser: User;

    constructor(
        public dialogRef: MatDialogRef<EditUserDialog>,
        @Inject(MAT_DIALOG_DATA) public data: User,
        private _spinnerService: SpinnerService,
        private _toastrService: ToastrService,
        private _userService: UserService) {
        
        this.masterUser = data;
        this.user = new User();
        this.user.UserId = this.masterUser.UserId;
        this.user.FirstName = this.masterUser.FirstName;
        this.user.LastName = this.masterUser.LastName;
        this.user.Username = this.masterUser.Username;
    }

    closeDialog(data: any = null) {
        this.dialogRef.close(data);
    }

    onSubmit() {
        // console.log('User', this.user);
        this._spinnerService.ProcessingOn();
        this._userService.EditUser(this.user.UserId, this.user)
            .subscribe((response) => {
                this._toastrService.success('Details has been updated succesfully', 'Success');
                this._spinnerService.ProcessingOff();
                this.closeDialog(true);
            },
            (error) => {
                this._spinnerService.ProcessingOff();
                this.closeDialog();
                console.log('EditUserDialog->onSubmit', error);
            });
    }
}