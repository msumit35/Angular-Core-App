import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { SidenavLinks } from '../models/sidenav.enum';

@Injectable()
export class SidenavService {

    private activeLinkSubject: BehaviorSubject<SidenavLinks>;
    public ActiveLink$: Observable<SidenavLinks>;

    constructor() {
        this.activeLinkSubject = new BehaviorSubject<SidenavLinks>(SidenavLinks.Home);
        this.ActiveLink$ = this.activeLinkSubject.asObservable();
    }

    ActiveLink(link: SidenavLinks) {
        this.activeLinkSubject.next(link);
    }

}