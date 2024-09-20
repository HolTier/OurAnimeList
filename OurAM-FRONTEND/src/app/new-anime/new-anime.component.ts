import {Component, ElementRef, ViewChild} from '@angular/core';
import {HeaderComponent} from "../header/header.component";
import {FormControl, FormGroup, FormsModule, ReactiveFormsModule} from "@angular/forms";
import {CdkDropList} from "@angular/cdk/drag-drop";
import {AsyncPipe, NgClass, NgForOf, NgIf, NgOptimizedImage} from "@angular/common";
import {MatError, MatFormField, MatFormFieldModule, MatHint, MatLabel} from "@angular/material/form-field";
import {MatInput} from "@angular/material/input";
import { NgxFileDropModule} from "ngx-file-drop";
import { NgxFileDropEntry, FileSystemFileEntry } from 'ngx-file-drop';
import {MatButton, MatIconButton} from "@angular/material/button";
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
import {NewAnimeService} from "../../services/new-anime.services";
import {AnimeLookupInterface, GenericLookupInterface} from "../shared/interfaces/new-anime.interfaces";
import {Observable, tap, throwError} from "rxjs";
import {catchError} from "rxjs/operators";
import {MatIcon} from "@angular/material/icon";

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
    MatFormFieldModule,
    MatIcon,
    MatIconButton
  ],
  templateUrl: './new-anime.component.html',
  styleUrl: './new-anime.component.scss',
})
export class NewAnimeComponent {
  // Image upload
  @ViewChild('fileInput') fileInput!: ElementRef;
  imageFile: File | null = null;
  isImageAdded: boolean = false;
  imgSrc: string | ArrayBuffer | null = null;

  // Titles
  titleEN: any;
  titleJP: any;

  // Lookup data
  lookupData: AnimeLookupInterface | null = null;
  filteredGenres: GenericLookupInterface[] = [];
  filteredStudios: GenericLookupInterface[] = [];
  filteredAnimeTypes: GenericLookupInterface[] = [];
  filteredAnimeStatuses: GenericLookupInterface[] = [];

  // Lookup ngModels
  type: any;
  status: any
  studio: any;
  genre: any;

  // Date range
  readonly airedRange = new FormGroup({
    start: new FormControl<Date | null>(null),
    end: new FormControl<Date | null>(null)
  })

  // Right side (descriptions and episode count)
  synopsis: any;
  longDescription: any;
  episodeCount: any;

  constructor(private newAnimeService: NewAnimeService) {

  }

  ngOnInit(): void {
    this.fetchAllLookupData();
  }

  // Fetch all lookup data
  fetchAllLookupData() {
    this.newAnimeService.fetchAnimeLookup().pipe(
      tap((data: AnimeLookupInterface) => {
        console.log('Lookup data:', data);
        this.lookupData = data;
        this.filteredGenres = data.genres;
        this.filteredStudios = data.studios;
        this.filteredAnimeTypes = data.animeTypes;
        this.filteredAnimeStatuses = data.animeStatuses;
      }
    ),
      catchError(error => {
        console.error('Error:', error);
        return throwError(() => new Error('Something bad happened; please try again later.'));
      })
    ).subscribe();
  }

  onSubmit() {

  }

  onAddFileClick() {
    this.fileInput.nativeElement.click();
  }

  onFileSelected(event: any) {
    const input = event.target as HTMLInputElement;
    if (input.files && input.files.length > 0) {
      const file = input.files[0];
      console.log('Selected file:', file);
      this.handleFile(file);
    }
  }

  addImageFromUrl() {
    const imageUrl = prompt('Enter image URL:');
    if (imageUrl) {
      console.log('Image URL:', imageUrl);
      // Handle URL
      this.handleFileFromUrl(imageUrl);
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

  private handleFileFromUrl(file: string) {
    this.imgSrc = file;
    this.isImageAdded = true;
  }

  filterList(list: GenericLookupInterface[] | undefined, inputElement: HTMLInputElement): GenericLookupInterface[] {
    const filterValue = inputElement.value.toLowerCase();

    if (!list) {
      return [];
    }
    return list.filter((item: GenericLookupInterface) => item.name.toLowerCase().includes(filterValue));
  }

  resetForm() {
    this.titleEN = null;
    this.titleJP = null;
    this.studio = null;
    this.synopsis = null;
    this.longDescription = null;
    this.episodeCount = null;
    this.genre = null;
    this.type = null;
    this.status = null;
    this.airedRange.reset();
    this.removeImage();
  }

  removeImage() {
    this.imageFile = null;
    this.imgSrc = null;
    this.isImageAdded = false;
  }
}
