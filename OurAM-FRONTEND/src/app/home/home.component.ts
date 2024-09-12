import { Component, OnInit } from '@angular/core';
import {HeaderComponent} from "../header/header.component";
import {MainBannerComponent} from "../main-banner/main-banner.component";
import {CardComponent} from "../card/card.component";
import {NgForOf} from "@angular/common";
import {AnimeCardInterface} from "../shared/interfaces/animeCardInterface";
import {AnimeService} from "../../services/anime.service";
import {tap, throwError} from "rxjs";
import {catchError} from "rxjs/operators";


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
  styleUrl: './home.component.scss'
})
export class HomeComponent {
  animeList: AnimeCardInterface[] = [];

  constructor(private animeService: AnimeService) {
  }

  ngOnInit(): void {
    this.onRefresh();
  }

  private onRefresh(): void {
    console.log('Component initialized or refreshed')
    this.loadAnimeList();
  }

  loadAnimeList(): void {
    this.animeService.fetchAnimeCard().pipe(
      tap((data: AnimeCardInterface[]) => {
          console.log('Response:', data);
          this.animeList = data;
        }
      ),
      catchError(error => {
        console.error('Error:', error);
        return throwError(() => new Error('Something bad happened; please try again later.'));
      })
    ).subscribe();
  }

  onAnimeSelected(anime: AnimeCardInterface) {
    console.log('Anime selected:', anime);
    // Handle card click logic, such as navigating to a detailed page or opening a modal
  }


}
