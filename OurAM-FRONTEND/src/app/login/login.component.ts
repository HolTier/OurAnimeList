import {Component, importProvidersFrom} from '@angular/core';
import { FormsModule } from '@angular/forms';
import { CommonModule} from "@angular/common";
import { LoginService} from "../../services/login.service";

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [
    FormsModule,
    CommonModule
  ],
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent {
  username: string = '';
  password: string = '';

  constructor(private loginService: LoginService) {}

  onSubmit() {
    console.log('Username: ' + this.username);
    console.log('Password: ' + this.password);

    // Call the login service
    this.loginService.login(this.username, this.password).subscribe(
      response => {
        console.log('Response: ' + response);
      },
      error => {
        console.error('Error: ' + error);
      }
    )
  }
}
