import { Component } from '@angular/core';
import {HeaderComponent} from "../header/header.component";
import {MainBannerComponent} from "../main-banner/main-banner.component";

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [
    HeaderComponent,
    MainBannerComponent
  ],
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})
export class HomeComponent {
  constructor() {
  }
}
