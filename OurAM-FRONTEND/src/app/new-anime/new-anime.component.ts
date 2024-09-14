import { Component } from '@angular/core';
import {HeaderComponent} from "../header/header.component";
import {FormsModule} from "@angular/forms";
import {CdkDropList} from "@angular/cdk/drag-drop";
import {NgClass, NgIf, NgOptimizedImage} from "@angular/common";
import {MatError, MatFormField, MatLabel} from "@angular/material/form-field";
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
    MatButton,
    MatError,
    NgOptimizedImage
  ],
  templateUrl: './new-anime.component.html',
  styleUrl: './new-anime.component.scss'
})
export class NewAnimeComponent {
  imagePath: string = '';
  imageFile: File | null = null;
  genre: any;
  studio: any;
  isImageAdded: boolean = false;
  imgSrc: string | ArrayBuffer | null = null;
  constructor() {
  }

  ngInit() {
    this.imageFile = null;
    this.imgSrc = null;
    this.isImageAdded = false;
  }

  onSubmit() {

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
    // Only one file
    if (this.imageFile) {
      alert('Only one file is allowed');
      return;
    }

    for (const droppedFile of $event) {
      if (droppedFile.fileEntry.isFile) {
        const fileEntry = droppedFile.fileEntry as FileSystemFileEntry;

        fileEntry.file((file: File) => {
          console.log('File dropped', file);
          if (!this.isImageFile(file)) {
            alert('Only images are allowed');
            return;
          }
          // Handle file
          this.handleFile(file);
        });
      }else {
        alert('Only files are allowed');
      }
    }
  }

  fileOver($event: any) {

  }

  fileLeave($event: any) {

  }

  private isImageFile(file: File): boolean {
    // Check if the file is of an image type
    const validImageTypes = ['image/jpeg', 'image/png', 'image/gif'];
    return validImageTypes.includes(file.type);
  }

  private handleFile(file: File) {
    this.imageFile = file;  // Store the file
    const reader = new FileReader();

    reader.onload = (event: any) => {
      this.imgSrc = event.target.result;  // Set the image source to the file content (data URL)
      console.log('Image source:', this.imgSrc);
      this.isImageAdded = true;           // Mark image as added
    };

    reader.onerror = () => {
      console.error('Error reading file');
      alert('Error loading file');
    };

    reader.readAsDataURL(file);  // Read the file as Data URL (for preview purposes)

  }
}
