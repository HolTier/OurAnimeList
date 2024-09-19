import {Injectable} from "@angular/core";
import {HttpClient} from "@angular/common/http";
import {Observable, throwError} from "rxjs";
import {AnimeLookupInterface} from "../app/shared/interfaces/new-anime.interfaces";
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

  private handleError() {
    // in a real world app, we may send the error to some remote logging infrastructure
    // but for now we'll just log it to the console
    console.error('An error occurred:'); // log to console instead
    return throwError(() => new Error('Something bad happened; please try again later.'));
  }
}
