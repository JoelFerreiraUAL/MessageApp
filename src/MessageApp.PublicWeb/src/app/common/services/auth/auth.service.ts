import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable, map } from 'rxjs';
import { User } from '../../models/user';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private userSubject: BehaviorSubject<User|null>;
  public user: Observable<User | null>;

  constructor( private http: HttpClient,     private router: Router,) {
    this.userSubject= new BehaviorSubject<User|null>(null);
    this.user= this.userSubject.asObservable();
   }
  login(email: string, password: string) {
    return this.http.post<User>(`https://localhost:7255/api/authentication/login`, { email, password })
        .pipe(map((data:any) => {
            localStorage.setItem('token', data.token);
            this.userSubject.next(data.user);
            return data.user;
        }));
}
public get userValue() {
  return this.userSubject.value;
}
getUser() {
  return this.http.get<User>(`https://localhost:7255/api/user`)
      .pipe(map((user:User) => {
          this.userSubject.next(user);
          return user;
      }));
}
logout() {
  localStorage.removeItem('token');
  this.userSubject.next(null);
  this.router.navigate(['/auth/login']);
}
}
