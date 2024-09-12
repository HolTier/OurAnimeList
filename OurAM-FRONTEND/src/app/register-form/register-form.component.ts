import { Component } from '@angular/core';
import {FormsModule} from "@angular/forms";
import {MatButton} from "@angular/material/button";
import {MatError, MatFormField, MatLabel} from "@angular/material/form-field";
import {MatInput} from "@angular/material/input";
import {NgIf} from "@angular/common";
import {tap, throwError} from "rxjs";
import {catchError} from "rxjs/operators";
import {LoginService} from "../../services/login.service";
import {AuthService} from "../../services/auth.service";
import {Router} from "@angular/router";

@Component({
  selector: 'app-register-form',
  standalone: true,
  imports: [
    FormsModule,
    MatButton,
    MatError,
    MatFormField,
    MatInput,
    MatLabel,
    NgIf
  ],
  templateUrl: './register-form.component.html',
  styleUrls: ['./register-form.component.css', '../login/login.component.css']
})
export class RegisterFormComponent {
  constructor(private loginService: LoginService, private authService: AuthService, private router: Router) {
  }

  registerUsername: string = '';
  registerEmail: string = '';
  registerPassword: string = '';

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
