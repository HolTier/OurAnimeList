import {Injectable, inject} from "@angular/core";
import {CanActivate, Router} from "@angular/router";
import {AuthService} from "../services/auth.service";

@Injectable({
    providedIn: 'root'
})
export class AuthGuard implements CanActivate {
  constructor(private authService: AuthService, private router: Router) {}

  canActivate(): boolean{
    if (this.authService.isAuthenticated()) {
      return true;
    }else {
      this.router.navigate(['/login']).then(r => console.log('Navigated to login'));
      return false;
    }
  }
}
