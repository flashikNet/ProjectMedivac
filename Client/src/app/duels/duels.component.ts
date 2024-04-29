import { Component, OnInit } from '@angular/core';
import {DuelsService} from "../_services/duels.service";

@Component({
  selector: 'app-duels',
  templateUrl: './duels.component.html',
  styleUrls: ['./duels.component.less']
})
export class DuelsComponent implements OnInit {
  duels: any;

  constructor(private duelsService: DuelsService) { }

  ngOnInit(): void {
    this.getDuels()
  }

  getDuels(): void {
    this.duelsService.getDuels().subscribe(duels => {
      this.duels = duels;
    })
  }

}
