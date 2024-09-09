import {Injectable} from "@angular/core";
import {HttpClient} from "@angular/common/http";
import {Observable, throwError} from "rxjs";
import {environment} from "../app/environment/environment";
import { catchError } from 'rxjs/operators';
import {AnimeCardInterface} from "../app/shared/interfaces/animeCardInterface";

@Injectable({
  providedIn: "root"
})
export class AnimeService {
  constructor(private httpClient: HttpClient) {
  }

  public fetchAnimeCard(): Observable<AnimeCardInterface[]>{
    return this.httpClient.get<AnimeCardInterface[]>(environment.apiUrl + "/Anime/GetAnimeCard")
      .pipe(
        catchError(this.handleError)
      )
  }

  private handleError(error: any) {
    // in a real world app, we may send the error to some remote logging infrastructure
    // but for now we'll just log it to the console
    console.error('An error occurred:', error); // log to console instead
    return throwError(() => new Error('Something bad happened; please try again later.'));
  }
}
