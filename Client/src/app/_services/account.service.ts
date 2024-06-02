import {Injectable} from '@angular/core';
import {HttpClient, HttpHeaders} from "@angular/common/http";
import {map} from "rxjs/operators";
import {User} from "../_models/user";
import {of, ReplaySubject} from "rxjs";
import {environment} from "../../environments/environment";
import {Register} from "../_models/register";
import {Login} from "../_models/login";
import {Router} from "@angular/router";

@Injectable({
  providedIn: 'root'
})
export class AccountService {
  baseUrl = environment.apiUrl;
  private currentUserSource = new ReplaySubject<User | null>(1);
  currentUser$ = this.currentUserSource.asObservable();

  constructor(private http: HttpClient,  private router: Router) {
  }

  login(model: Login) {
    return this.http.post<User>(this.baseUrl + 'users/login', model).pipe(
      map((response: User) => {
          const user = response;

          if (user) {
            localStorage.setItem('user', JSON.stringify(user))
            this.setCurrentUser(user);
          }
        }
      )
    )
  }

  setCurrentUser(user: User) {
    localStorage.setItem('user', JSON.stringify(user));
    this.currentUserSource.next(user);
  }

  register(model: Register) {
    return this.http.post<User>(this.baseUrl + 'Users/register', model).pipe(
      map((response: User) => {
        const user = response;
        if (user) {
          localStorage.setItem('user', JSON.stringify(user))
          this.setCurrentUser(user);
        }
      })
    )
  }
  loadCurrentUser() {
    let user = localStorage.getItem('user');
    if (user === null) {
      this.currentUserSource.next(null);
      return of(null);
    }
    this.currentUserSource.next(JSON.parse(user));
    return JSON.parse(user);
  }
  logout() {
    localStorage.removeItem('user');
    this.currentUserSource.next(null);
    this.router.navigateByUrl('/')
  }

}
