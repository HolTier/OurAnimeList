import {Component, ViewChild} from '@angular/core';
import { MatToolbar} from "@angular/material/toolbar";
import {MatButtonToggleGroup} from "@angular/material/button-toggle";
import {MatAnchor, MatButton} from "@angular/material/button";
import {Router, RouterLink, RouterLinkActive} from "@angular/router";
import {AuthService} from "../../services/auth.service";
import {NgClass, NgIf} from "@angular/common";
import {LoginService} from "../../services/login.service";
import {tap} from "rxjs";
import {catchError} from "rxjs/operators";
import {MatMenu, MatMenuItem, MatMenuTrigger} from "@angular/material/menu";

@Component({
  selector: 'app-header',
  standalone: true,
  imports: [
    MatToolbar,
    MatButtonToggleGroup,
    MatAnchor,
    RouterLink,
    RouterLinkActive,
    NgIf,
    MatMenu,
    MatMenuItem,
    MatMenuTrigger,
    MatButton,
    NgClass,
  ],
  templateUrl: './header.component.html',
  styleUrl: './header.component.scss'
})
export class HeaderComponent {
  closeMenuTimeout: any;
  isAuthenticated: boolean = false;
  isAnimeButtonActive: boolean = false;
  @ViewChild('clickAnime') clickAnime: any;

  constructor(private router: Router, private authService: AuthService, private loginService: LoginService) {
  }

  ngOnInit() {
    this.isAuthenticated = this.authService.isAuthenticated();
  }

  logout() {
    this.loginService.logout().pipe(
      tap(() => {
        this.authService.removeToken();
        // Refresh the current page
        location.reload();
      }),
      catchError((error) => {
        console.error('An error occurred:', error);
        return error;
      })
    ).subscribe();
  }

  // Close menu on mouse enter
  onMouseEnter(menuTrigger: MatMenuTrigger) {
    menuTrigger.openMenu();
    this.cancelCloseMenu();
    this.isAnimeButtonActive = true;
  }

  // Schedule the menu to close after
  scheduleCloseMenu(menuTrigger: MatMenuTrigger) {
    this.closeMenuTimeout = setTimeout(() => {
      menuTrigger.closeMenu();
      this.removeButtonFocus();
      this.isAnimeButtonActive = false;
    }, 100);
  }

  // Cancel the scheduled menu close
  cancelCloseMenu() {
    if (this.closeMenuTimeout) {
      clearTimeout(this.closeMenuTimeout);
    }
  }

  // Close the menu on mouse leave
  closeMenu(menuTrigger: MatMenuTrigger) {
    menuTrigger.closeMenu();
    this.removeButtonFocus();
  }

  // Remove focus from the button
  removeButtonFocus() {
    this.clickAnime._elementRef.nativeElement.blur();
  }
}
