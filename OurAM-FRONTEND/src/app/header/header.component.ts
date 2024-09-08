import {Component} from '@angular/core';
import { MatToolbar} from "@angular/material/toolbar";
import {MatButtonToggleGroup} from "@angular/material/button-toggle";
import {MatAnchor} from "@angular/material/button";
import {RouterLink, RouterLinkActive} from "@angular/router";

@Component({
  selector: 'app-header',
  standalone: true,
  imports: [
    MatToolbar,
    MatButtonToggleGroup,
    MatAnchor,
    RouterLink,
    RouterLinkActive
  ],
  templateUrl: './header.component.html',
  styleUrl: './header.component.css'
})
export class HeaderComponent {

}
