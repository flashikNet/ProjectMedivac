import { Injectable } from '@angular/core';
import {Observable} from "rxjs";
import {environment} from "../../environments/environment";
import {HttpClient} from "@angular/common/http";

@Injectable({
  providedIn: 'root'
})
export class PlayersService {
  constructor(private http: HttpClient) { }

  getPlayerById(id: string): Observable<any> {
    return this.http.get(environment.apiUrl + 'players/' + id);
  }
}
