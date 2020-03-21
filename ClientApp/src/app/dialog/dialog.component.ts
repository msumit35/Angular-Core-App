import { Component, Inject, OnInit } from '@angular/core';
import { MatDialogRef, MatDialog, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { DialogModel } from '../models/dialog.model';

@Component({
    selector: 'app-dialog',
    templateUrl: 'dialog.component.html',
    styleUrls: ['dialog.component.css']
})
export class DialogComponent implements OnInit {
    constructor(public dialogRef: MatDialogRef<DialogComponent>, 
        @Inject(MAT_DIALOG_DATA) public data: DialogModel){}


    ngOnInit() {
    }

    onOkClick(){
        this.dialogRef.close();
    }
}