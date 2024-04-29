import { Component } from '@angular/core';

@Component({
  selector: 'app-create-team',
  templateUrl: './create-team.component.html',
  styleUrls: ['./create-team.component.less']
})
export class CreateTeamComponent {
  regions: { code: string, name: string } [] = [
    { code: 'US', name: 'North America' },
    { code: 'RU', name: 'Russia' },
    { code: 'EU', name: 'Europe' },
    { code: 'KR', name: 'Asia' },
  ];

  constructor() { }
}
