import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable, map } from 'rxjs';
import { User } from '../../models/user';
import { HttpClient } from '@angular/common/http';
@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private userSubject: BehaviorSubject<User | null>;
  public user: Observable<User | null>;

  constructor( private http: HttpClient) { }
  login(username: string, password: string) {
    return this.http.post<User>(`https://localhost:7255/api/authentication/login`, { username, password })
        .pipe(map((data:any) => {
            localStorage.setItem('token', JSON.stringify(data.token));
            this.userSubject.next(data.user);
            return data.user;
        }));
}

}
