import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import {environment} from "../../environments/environment";
import {Team} from "../_models/team";
import {Roles} from "../_enums/roles";

@Injectable({
  providedIn: 'root'
})
export class TeamsService {

  constructor(private http: HttpClient) { }

  getTeams(): Observable<Team[]> {
    return this.http.get<Team[]>(environment.apiUrl + 'Teams/teams');
  }

  getTeamById(id: string): Observable<Team> {
    return this.http.get<Team>(environment.apiUrl + 'Teams/teams' + id);
  }
  createTeam(name: string) {
    return this.http.post(environment.apiUrl + 'Teams/teams/createTeam', name);
  }

}
