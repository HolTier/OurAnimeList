import {Component, EventEmitter, Input, Output} from '@angular/core';
import {NgIf, NgOptimizedImage} from "@angular/common";
import {AnimeCardInterface} from "../shared/interfaces/anime-card.interface";
import {MatButton} from "@angular/material/button";

@Component({
  selector: 'app-anime-page',
  standalone: true,
  imports: [
    NgOptimizedImage,
    NgIf,
    MatButton
  ],
  templateUrl: './anime-page.component.html',
  styleUrl: './anime-page.component.scss'
})
export class AnimePageComponent {
  @Input() anime: AnimeCardInterface | null = null;
  @Output() closeAnimePage = new EventEmitter<void>();

  constructor() {
  }


  onCloseAnimeDetails() {
    this.closeAnimePage.emit();
  }
}
