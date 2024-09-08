import { Component } from '@angular/core';
import {MatIcon} from "@angular/material/icon";
import { CommonModule } from '@angular/common';

interface Banner {
  imageUrl: string;
  title: string;
  description: string;
  episodes: number;
  genre: string;
}

@Component({
  selector: 'app-main-banner',
  standalone: true,
  imports: [
    MatIcon,
    CommonModule
  ],
  templateUrl: './main-banner.component.html',
  styleUrl: './main-banner.component.css'
})
export class MainBannerComponent {

  // Example banners array
  banners: Banner[] = [
    {
      imageUrl: 'https://img.freepik.com/free-photo/medium-shot-anime-characters-hugging_23-2150970923.jpg?t=st=1725789143~exp=1725792743~hmac=5d2621731454b2655f980c9efdfd5a5c80672a492b65e4b0c7187bb57af43f77&w=1380',
      title: 'Anime Title 1',
      description: 'Short description of Anime 1',
      episodes: 24,
      genre: 'Action'
    },
    {
      imageUrl: 'https://img.freepik.com/free-photo/anime-style-mythical-dragon-creature_23-2151112768.jpg?t=st=1725789259~exp=1725792859~hmac=21b46a5fca723d3b70520125022e40eadd7c9d96169c335a2b7416ce5b37cc49&w=1380',
      title: 'Anime Title 2',
      description: 'Short description of Anime 2',
      episodes: 12,
      genre: 'Romance'
    },
    {
      imageUrl: 'https://img.freepik.com/free-photo/mythical-dragon-beast-anime-style_23-2151112797.jpg?t=st=1725789280~exp=1725792880~hmac=6286c4f57eca7fc03fbfd65881abde6ab5017a534bc5a5e1de27ad9f61a61502&w=1380',
      title: 'Anime Title 3',
      description: 'Short description of Anime 3',
      episodes: 36,
      genre: 'Fantasy'
    }
  ];

  currentIndex: number = 0;

  // Getter
  get currentBanner() {
    return this.banners[this.currentIndex];
  }

  previousSlide() {
    this.currentIndex = this.currentIndex === 0 ? this.banners.length - 1 : this.currentIndex - 1;
  }

  nextSlide() {
    this.currentIndex = this.currentIndex === this.banners.length - 1 ? 0 : this.currentIndex + 1;
  }
}
