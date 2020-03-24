import { Component, OnInit } from '@angular/core';
import { AuthenticateService } from './services/authenticate.service';
import { Router } from '@angular/router';
import { User } from './models/user.model';
import { SidenavService } from './services/sidenav.service';
import { SidenavLinks } from './models/sidenav.enum';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'ClientApp';
  currentUser: User;
  activeLink: SidenavLinks;
  constructor(private _authService: AuthenticateService, private _router: Router,
              private _sidenavService: SidenavService){
    
    this._authService.CurrentUser.subscribe((res) => {
      this.currentUser = res;
    });

    this._sidenavService.ActiveLink$.subscribe((link) => {
      console.log('link', link);
      this.activeLink = link;
    })
  }

  ngOnInit() {
  }

}
