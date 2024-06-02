import {Component, OnInit} from '@angular/core';
import {AccountService} from "./_services/account.service";

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.less']
})
export class AppComponent implements OnInit{
  title = 'Client';
  constructor(private accountService: AccountService) {
  }

  ngOnInit(): void {
    this.accountService.loadCurrentUser();
  }
}
