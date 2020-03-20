import { Component } from '@angular/core';
import { AuthenticateService } from './services/authenticate.service';
import { Authenticate } from './models/authenticate.model';
import { Router } from '@angular/router';
import { User } from './models/user.model';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'ClientApp';
  currentUser: User;
  constructor(private _authService: AuthenticateService, private _router: Router){
    this._authService.CurrentUser.subscribe((res) => {
      this.currentUser = res;
    });
  }

  logout() {
    this._authService.logout();
    this._router.navigate(['/login']);
  }

}
