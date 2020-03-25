import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { NavigationLinks } from '../app.navigation';

@Injectable()
export class SidenavService {

    private activeLinkSubject: BehaviorSubject<NavigationLinks>;
    public ActiveLink$: Observable<NavigationLinks>;

    constructor() {
        this.activeLinkSubject = new BehaviorSubject<NavigationLinks>(NavigationLinks.Home);
        this.ActiveLink$ = this.activeLinkSubject.asObservable();
    }

    ActiveLink(link: NavigationLinks) {
        this.activeLinkSubject.next(link);
    }

}