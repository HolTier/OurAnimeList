import {Component, importProvidersFrom} from '@angular/core';
import { FormsModule } from '@angular/forms';
import { CommonModule} from "@angular/common";
import { LoginService} from "../../services/login.service";
import { AuthService } from "../../services/auth.service";
import {Router} from "@angular/router";
import {tap, throwError} from "rxjs";
import {catchError} from "rxjs/operators";
import { FlexLayoutModule } from '@angular/flex-layout';
import {MatError, MatFormField, MatLabel} from "@angular/material/form-field";
import {MatInput} from "@angular/material/input";
import {MatButton} from "@angular/material/button";
import {environment} from "../environment/environment";
import {
  GoogleLoginProvider,
  GoogleSigninButtonModule,
  SocialAuthService,
  SocialUser
} from "@abacritt/angularx-social-login";

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [
    FormsModule,
    CommonModule,
    FlexLayoutModule,
    MatFormField,
    MatLabel,
    MatInput,
    MatError,
    MatButton,
    GoogleSigninButtonModule
  ],
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
})
export class LoginComponent {
  username: string = '';
  password: string = '';
  registerUsername: string = '';
  registerEmail: string = '';
  registerPassword: string = '';
  user: SocialUser | null;

  constructor(private loginService: LoginService, private authService: AuthService, private router: Router, private socialAuthService: SocialAuthService) {
    this.user = null;
    this.socialAuthService.authState.subscribe((user) => {
      console.log('User: ' + user);
      this.user = user;
    });
  }

  ngOnInit() {
    this.socialAuthService.authState.subscribe((user) => {
      console.log('User: ' + user.idToken);
      this.user = user;
    });
  }

  onSubmit() {
    console.log('Username: ' + this.username);
    console.log('Password: ' + this.password);

    // Call the login service
    this.loginService.login(this.username, this.password).pipe(
      tap(response => {
        console.log('Response: ' + response);
        this.authService.setToken(response.token);
        this.router.navigate(['/home']).then(r => console.log('Navigated to home'));
      }),
      catchError(error => {
        console.error('Error: ' + error);
        return throwError(() => new Error('Something bad happened; please try again later.'));
      })
    ).subscribe();
  }

  onRegister() {
    console.log('Register Username: ' + this.registerUsername);
    console.log('Register Password: ' + this.registerPassword);

    // Call the login service
    this.loginService.register(this.registerUsername, this.registerEmail, this.registerPassword).pipe(
      tap(response => {
        console.log('Response: ' + response);
        this.authService.setToken(response.token);
        this.router.navigate(['/home']).then(r => console.log('Navigated to home'));
      }),
      catchError(error => {
        console.error('Error: ' + error);
        return throwError(() => new Error('Something bad happened; please try again later.'));
      })
    ).subscribe();
  }
}
