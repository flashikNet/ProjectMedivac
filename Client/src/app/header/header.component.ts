import { Component, OnInit } from '@angular/core';
import {AccountService} from "../_services/account.service";
import {Observable} from "rxjs";
import {User} from "../_models/user";

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.less']
})
export class HeaderComponent implements OnInit {
  currentUser$: Observable<User | null> = new Observable<User | null>();
  constructor(private accountService: AccountService) { }

  ngOnInit(): void {
    this.currentUser$ = this.accountService.loadCurrentUser();
    this.currentUser$ = this.accountService.currentUser$;
    console.log(this.currentUser$)
  }
logout() {
    this.accountService.logout();
}
}
