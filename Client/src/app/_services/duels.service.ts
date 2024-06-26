import {Injectable} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";
import {environment} from "../../environments/environment";

@Injectable({
  providedIn: 'root'
})
export class DuelsService {

  constructor(private http: HttpClient) {
  }

  getDuels(): Observable<any> {
    return this.http.get('https://project-medivac.somee.com/api/' + 'matches')
  }

  getDuelById(id: string): Observable<any> {
    return this.http.get('https://project-medivac.somee.com/api/' + 'matches/' + id);
  }
}
