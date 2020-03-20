import { Component, Input } from '@angular/core';
import { AuthenticateService } from '../services/authenticate.service';
import { User } from '../models/user.model';
import { Router } from '@angular/router';

@Component({
    selector: 'app-toolbar',
    templateUrl: 'toolbar.component.html',
    styleUrls: ['toolbar.component.css']
})
export class ToolbarComponent {
    currentUser: User;
    @Input("sidenav-event") sidenav: any;
    constructor(private _authService: AuthenticateService, private _router: Router){
        _authService.CurrentUser.subscribe((user) => {
            this.currentUser = user;
        });
    }

    logout() {
        this._authService.logout();
        this._router.navigate(['/login']);
    }
}