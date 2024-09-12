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
import {LoginFormComponent} from "../login-form/login-form.component";
import {RegisterFormComponent} from "../register-form/register-form.component";

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
    GoogleSigninButtonModule,
    LoginFormComponent,
    RegisterFormComponent
  ],
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss'],
})
export class LoginComponent {
  isLoginMode: boolean = true;
  user: SocialUser | null = null;
  width = 370;

  constructor(private loginService: LoginService, private authService: AuthService, private router: Router, private socialAuthService: SocialAuthService) {
  }

  ngOnInit() {
    this.socialAuthService.authState.subscribe((user) => {
      console.log('User: ' + user.idToken);
      this.user = user;
      this.validateGoogleLogin(user);
    });
  }

  onSwitchMode() {
    this.isLoginMode = !this.isLoginMode;
  }

  validateGoogleLogin(user: SocialUser) {
    this.loginService.googleLogin(user).pipe(
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
