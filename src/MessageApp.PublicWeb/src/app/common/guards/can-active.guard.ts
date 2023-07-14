import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot, UrlTree } from '@angular/router';
import { Observable, map } from 'rxjs';
import { AuthService } from '../services/auth/auth.service';
import { User } from '../models/user';

@Injectable({
  providedIn: 'root'
})
export class CanActiveGuard  {
  constructor(
    private auth: AuthService,
    private router: Router
  ) {}

  canActivate(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<boolean | UrlTree> | Promise<boolean | UrlTree> | boolean | UrlTree {
      const user = this.auth.userValue;
      if (user) {
          return true;
      }
      const token = localStorage.getItem("token");
      if (!token) {
        this.router.navigate(["/auth/login"]);
        return false;
      }
      else{
      return this.auth.getUser().pipe(map((user:User)=>{
        if(!user){
          return false
        }
        return true
      }))
      }


  }

}
