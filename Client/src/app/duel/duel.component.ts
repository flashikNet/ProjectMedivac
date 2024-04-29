import { Component, OnInit } from '@angular/core';
import {DuelsService} from "../_services/duels.service";
import {ActivatedRoute} from "@angular/router";

@Component({
  selector: 'app-duel',
  templateUrl: './duel.component.html',
  styleUrls: ['./duel.component.less']
})
export class DuelComponent implements OnInit {
  duel: any;

  constructor(private route: ActivatedRoute, private duelsService: DuelsService) { }

  ngOnInit(): void {
    let id = this.route.snapshot.paramMap.get('id')!;
    this.duelsService.getDuelById(id).subscribe(duel => {
      this.duel = duel;
    })
  }


}
