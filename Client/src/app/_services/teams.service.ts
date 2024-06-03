import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import {environment} from "../../environments/environment";
import {Team} from "../_models/team";
import {Roles} from "../_enums/roles";
import {Router} from "@angular/router";

@Injectable({
  providedIn: 'root'
})
export class TeamsService {

  constructor(private http: HttpClient) { }

  getTeams(): Observable<Team[]> {
    return this.http.get<Team[]>('https://project-medivac.somee.com/api/' + 'Teams/teams');
  }

  getTeamById(id: string): Observable<Team> {
    return this.http.get<Team>('https://project-medivac.somee.com/api/' + 'Teams/teams' + id);
  }
  createTeam(name: string) {
    return this.http.post('https://project-medivac.somee.com/api/' + 'Teams/teams/createTeam', name);
  }

}
