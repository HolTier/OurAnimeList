import { Component } from '@angular/core';
import {HeaderComponent} from "../header/header.component";
import {FormsModule} from "@angular/forms";
import {CdkDropList} from "@angular/cdk/drag-drop";
import {NgClass, NgIf} from "@angular/common";
import {MatFormField, MatLabel} from "@angular/material/form-field";
import {MatInput} from "@angular/material/input";
import { NgxFileDropModule} from "ngx-file-drop";
import { NgxFileDropEntry, FileSystemFileEntry } from 'ngx-file-drop';
import {MatButton} from "@angular/material/button";

@Component({
  selector: 'app-new-anime',
  standalone: true,
  imports: [
    HeaderComponent,
    FormsModule,
    CdkDropList,
    NgClass,
    MatFormField,
    MatInput,
    MatLabel,
    NgxFileDropModule,
    NgIf,
    MatButton
  ],
  templateUrl: './new-anime.component.html',
  styleUrl: './new-anime.component.scss'
})
export class NewAnimeComponent {
  isDragOver: any;
  image: any;
  imagePath: string = '';
  constructor() {
  }

  onSubmit() {

  }

  onFileDropped($event: NgxFileDropEntry[]) {

  }

  onFileLeave($event: any) {

  }

  onFileOver($event: any) {

  }

  onFileSelected(event: any) {
    const file: File = event.target.files[0];
    console.log('File selected', file);
    // Handle file
  }

  addImageFromUrl() {
    const imageUrl = prompt('Enter image URL:');
    if (imageUrl) {
      console.log('Image URL:', imageUrl);
      // Handle URL
    }
  }

  dropped($event: NgxFileDropEntry[]) {

  }

  fileOver($event: any) {

  }

  fileLeave($event: any) {

  }
}
