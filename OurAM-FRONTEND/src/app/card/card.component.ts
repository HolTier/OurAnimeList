import {Component, EventEmitter, Input, Output} from '@angular/core';
import {MatCard, MatCardActions, MatCardContent, MatCardImage} from "@angular/material/card";
import {IMAGE_CONFIG, NgOptimizedImage} from "@angular/common";
import {MatIcon} from "@angular/material/icon";
import {MatButton} from "@angular/material/button";

@Component({
  selector: 'app-card',
  standalone: true,
  imports: [
    MatCard,
    MatCardImage,
    NgOptimizedImage,
    MatCardContent,
    MatIcon,
    MatCardActions,
    MatButton
  ],
  templateUrl: './card.component.html',
  styleUrl: './card.component.scss'
})
export class CardComponent {
  // Inputs to receive data
  @Input() logoUrl: string = '';
  @Input() title: string = '';
  @Input() shortDescription: string = '';
  @Input() rating: number = 0;
  @Input() episodes: number = 0;

  // Outputs to emit events
  @Output() cardClick = new EventEmitter<void>();

  onCardClick() {
    this.cardClick.emit();
  }

  addAnime($event: MouseEvent) {
    $event.stopPropagation();
    console.log('Add button clicked');
  }
}
