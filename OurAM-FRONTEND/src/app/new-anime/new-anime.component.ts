import {Component, ElementRef, ViewChild} from '@angular/core';
import {HeaderComponent} from "../header/header.component";
import {FormControl, FormGroup, FormsModule, ReactiveFormsModule} from "@angular/forms";
import {CdkDropList} from "@angular/cdk/drag-drop";
import {AsyncPipe, NgClass, NgForOf, NgIf, NgOptimizedImage} from "@angular/common";
import {MatError, MatFormField, MatFormFieldModule, MatHint, MatLabel} from "@angular/material/form-field";
import {MatInput} from "@angular/material/input";
import { NgxFileDropModule} from "ngx-file-drop";
import { NgxFileDropEntry, FileSystemFileEntry } from 'ngx-file-drop';
import {MatButton} from "@angular/material/button";
import {MatOption, MatSelect} from "@angular/material/select";
import {MatAutocomplete, MatAutocompleteTrigger} from "@angular/material/autocomplete";
import {
  MatDatepicker,
  MatDatepickerModule,
  MatDatepickerToggle,
  MatDateRangeInput,
  MatDateRangePicker
} from "@angular/material/datepicker";
import {CdkTextareaAutosize} from "@angular/cdk/text-field";

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
    NgOptimizedImage,
    MatSelect,
    MatOption,
    NgForOf,
    MatAutocomplete,
    MatAutocompleteTrigger,
    AsyncPipe,
    MatDateRangeInput,
    MatDatepickerToggle,
    MatDateRangePicker,
    ReactiveFormsModule,
    CdkTextareaAutosize,
    MatHint,
    MatDatepickerModule,
    MatFormFieldModule
  ],
  templateUrl: './new-anime.component.html',
  styleUrl: './new-anime.component.scss',
})
export class NewAnimeComponent {
  imageFile: File | null = null;
  genre: any;
  studio: any;
  isImageAdded: boolean = false;
  imgSrc: string | ArrayBuffer | null = null;
  genreList: string[] = [
    'Action',
    'Adventure',
    'Comedy',
    'Drama',
    'Fantasy',
    'Horror',
    'Mecha',
    'Mystery',
    'Psychological',
    'Romance',
    'Sci-Fi',
    'Slice of Life',
    'Sports',
    'Supernatural',
    'Thriller'
  ];
  filteredGenreList: string[];
  filteredStudioList: string[] = [];
  studioList: string[] = [];
  titleEN: any;
  titleJP: any;
  type: any;
  filteredTypeList: string[] = [];
  typeList: string[] = ['TV', 'OVA', 'Movie', 'Special', 'ONA', 'Music'];
  status: any;
  filteredStatusList: string[] = [];
  statusList: string[] = ['Finished Airing', 'Currently Airing', 'Not Yet Aired'];
  readonly airedRange = new FormGroup({
    start: new FormControl<Date | null>(null),
    end: new FormControl<Date | null>(null)
  })
  synopsis: any;
  longDescription: any;
  episodeCount: any;
  constructor() {
    this.filteredGenreList = this.genreList.slice();
    this.filteredStudioList = this.studioList.slice();
    this.filteredTypeList = this.typeList.slice();
    this.filteredStatusList = this.statusList.slice();
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

  filterList(list: string[], inputElement: HTMLInputElement): string[] {
    const filterValue = inputElement.value.toLowerCase();
    return list.filter(item => item.toLowerCase().includes(filterValue));
  }
}
