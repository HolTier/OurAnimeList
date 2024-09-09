import { Component } from '@angular/core';
import {HeaderComponent} from "../header/header.component";
import {MainBannerComponent} from "../main-banner/main-banner.component";
import {CardComponent} from "../card/card.component";
import {NgForOf} from "@angular/common";
import {AnimeCardInterface} from "../shared/interfaces/animeCardInterface";


@Component({
  selector: 'app-home',
  standalone: true,
  imports: [
    HeaderComponent,
    MainBannerComponent,
    CardComponent,
    NgForOf
  ],
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})
export class HomeComponent {
  constructor() {
  }

  animeList: AnimeCardInterface[] = [
    {
      logoUrl: 'https://img.freepik.com/free-photo/anime-style-portrait-traditional-japanese-samurai-character_23-2151499068.jpg?t=st=1725792982~exp=1725796582~hmac=128ac5261c7c754e38d59b487ec1666ead2825201937d7e93c81a0899419a833&w=740',
      title: 'Anime Title 1',
      description: 'Short description of Anime 1',
      rating: 8.5,
      episodes: 24
    },
    {
      logoUrl: 'https://img.freepik.com/free-photo/full-shot-ninja-wearing-equipment_23-2150960846.jpg?t=st=1725793095~exp=1725796695~hmac=c93df91fe1f28fba51fdda0d5cd193df0e863bbc77dd8324206e023048e5c75d&w=740',
      title: 'Anime Title 2',
      description: 'Short description of Anime 2',
      rating: 7.9,
      episodes: 12
    }
    // Add more anime as needed
  ];

  onAnimeSelected(anime: AnimeCardInterface) {
    console.log('Anime selected:', anime);
    // Handle card click logic, such as navigating to a detailed page or opening a modal
  }
}
