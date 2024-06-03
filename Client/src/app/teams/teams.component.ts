import { Component, OnInit } from '@angular/core';
import {TeamsService} from "../_services/teams.service";
import {Team} from "../_models/team";
import {Roles} from "../_enums/roles";
import {AccountService} from "../_services/account.service";
import {ToastrService} from "ngx-toastr";

@Component({
  selector: 'app-teams',
  templateUrl: './teams.component.html',
  styleUrls: ['./teams.component.less']
})
export class TeamsComponent implements OnInit {
  teams: Team[] = [];
  userRole: Roles = Roles.User;
  userTeamId: string = '';
  constructor(private teamsService: TeamsService, private accountService: AccountService,
              private toastr: ToastrService) { }

  ngOnInit(): void {
    this.getTeams();
    this.getUserRole();
    this.getUserTeamId();
  }

  getTeams() {
    this.teamsService.getTeams().subscribe(
      teams => {
        this.teams = teams;
        console.log(teams);
      }
    );
  }


  getUserRole() {
    this.accountService.getCurrentUserRole().subscribe(
      role => {
        this.userRole = role;
      }
    );
  }

  getUserTeamId() {
    this.accountService.getCurrentUserTeamId().subscribe(
      teamId => {
        this.userTeamId = teamId;
      }
    );
  }

  canChallenge(team: Team): boolean {
    return this.userRole === Roles.Captain && this.userTeamId !== team.id;
  }

  challengeTeam(team: Team) {
    this.toastr.success('Команда вызвана на дуэль и ожидает принятия', '👍', {positionClass: 'toast-bottom-right'})
    console.log('rofls' + team)
  }
}
