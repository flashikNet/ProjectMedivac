import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { TeamsService } from '../_services/teams.service';

@Component({
  selector: 'app-team',
  templateUrl: './team.component.html',
  styleUrls: ['./team.component.less']
})
export class TeamComponent implements OnInit {
  team: any;
  leaderView: boolean = false;
  invitationSent: boolean = false;
  playerName: string = '';

  constructor(private route: ActivatedRoute, private teamsService: TeamsService) { }

  ngOnInit(): void {
    this.getTeamById();
  }

  getTeamById(): void {
    let id = this.route.snapshot.paramMap.get('id')!;
    this.teamsService.getTeamById(id).subscribe(team => {
      this.team = team;
      console.log(team)
    });
  }

  sendInvitation(): void {
    this.invitationSent = true;
    this.playerName = '';
  }

  resetInvitation(): void {
    this.invitationSent = false;
  }
}
