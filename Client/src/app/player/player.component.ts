import { Component, OnInit } from '@angular/core';
import {ActivatedRoute} from "@angular/router";
import {TeamsService} from "../_services/teams.service";
import {PlayersService} from "../_services/players.service";

@Component({
  selector: 'app-player',
  templateUrl: './player.component.html',
  styleUrls: ['./player.component.less']
})
export class PlayerComponent implements OnInit {
  player: any;
  constructor(private route: ActivatedRoute, private playersService: PlayersService) { }

  ngOnInit(): void {
    this.getPlayerById()
  }

  getPlayerById(): void {
    let id = this.route.snapshot.paramMap.get('id')!;
    this.playersService.getPlayerById(id).subscribe(player => {
      this.player = player;
      console.log(player)
    });
  }

}
