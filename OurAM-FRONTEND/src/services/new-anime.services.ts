import {Injectable} from "@angular/core";
import {HttpClient} from "@angular/common/http";
import {Observable, throwError} from "rxjs";
import {AnimeLookupInterface, NewAnimeInterface} from "../app/shared/interfaces/new-anime.interfaces";
import {environment} from "../app/environment/environment";
import { catchError } from 'rxjs/operators';

@Injectable({
  providedIn: "root"
})
export class NewAnimeService {
  constructor(private httpClient: HttpClient) {
  }

  public fetchAnimeLookup(): Observable<AnimeLookupInterface>{
    return this.httpClient.get<AnimeLookupInterface>(environment.apiUrl + "/lookup/all-lookups")
      .pipe(
        catchError(this.handleError)
      )
  }

  // Send the new anime data to the server
  public saveNewAnime(newAnimeData: NewAnimeInterface): Observable<any> {
    const headers = { 'responseType': 'text' }
    const body = JSON.stringify(newAnimeData)

    return this.httpClient.post(environment.apiUrl + "/Anime/AddAnime", newAnimeData, { headers })
      .pipe(
        catchError((error) => {
          console.error('Error:', error);
          return throwError(() => new Error('Something bad happened; please try again later.'));
        })
      )
  }

  private handleError(error: any) {
    // in a real world app, we may send the error to some remote logging infrastructure
    // but for now we'll just log it to the console
    console.error('An error occurred:', ); // log to console instead
    return throwError(() => new Error('Something bad happened; please try again later.'));
  }
}
