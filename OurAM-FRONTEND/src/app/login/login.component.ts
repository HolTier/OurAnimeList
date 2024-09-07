import {Component, importProvidersFrom} from '@angular/core';
import { FormsModule } from '@angular/forms';
import { CommonModule} from "@angular/common";
import { LoginService} from "../../services/login.service";
import { AuthService } from "../../services/auth.service";

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [
    FormsModule,
    CommonModule
  ],
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
})
export class LoginComponent {
  username: string = '';
  password: string = '';

  constructor(private loginService: LoginService, private authService: AuthService) {}

  onSubmit() {
    console.log('Username: ' + this.username);
    console.log('Password: ' + this.password);

    // Call the login service
    this.loginService.login(this.username, this.password).subscribe(
      response => {
        console.log('Response: ' + response);

        // Save the token
        this.authService.setToken(response.token);
      },
      error => {
        console.error('Error: ' + error);
      }
    )
  }
}
