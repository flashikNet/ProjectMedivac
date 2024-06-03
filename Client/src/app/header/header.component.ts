import {Component, OnInit} from '@angular/core';
import {AccountService} from "../_services/account.service";
import {Observable} from "rxjs";
import {User} from "../_models/user";
import {Roles} from "../_enums/roles";

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.less']
})
export class HeaderComponent implements OnInit {
  currentUser$: Observable<User | null> = new Observable<User | null>();
  isCaptain: boolean = false;
  userRole: Roles = Roles.User;

  constructor(private accountService: AccountService) {
  }

  ngOnInit(): void {
    this.currentUser$ = this.accountService.loadCurrentUser();
    this.currentUser$ = this.accountService.currentUser$;
    this.isUserCaptain();
    console.log(this.currentUser$)
  }

  logout() {
    this.accountService.logout();
  }

  isUserCaptain() {
    this.accountService.getCurrentUserRole().subscribe(role => {
      this.userRole = role;
      this.isCaptain = this.userRole === Roles.Captain;
    });
  }
}
