import { Component, OnInit } from '@angular/core';
import {TeamsService} from "../_services/teams.service";

@Component({
  selector: 'app-teams',
  templateUrl: './teams.component.html',
  styleUrls: ['./teams.component.less']
})
export class TeamsComponent implements OnInit {
  teams: any[] = [];

  constructor(private teamsService: TeamsService) { }

  ngOnInit(): void {
    this.getTeams();
  }

  getTeams() {
    this.teamsService.getTeams().subscribe(
      teams => {
        this.teams = teams;
        console.log(teams);
      }
    );
  }

}
