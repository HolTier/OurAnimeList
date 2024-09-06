import {Injectable} from "@angular/core";
import {HttpClient, HttpHeaders} from "@angular/common/http";
import {environment} from "../app/environment/environment";
import {Observable} from "rxjs";
import { catchError } from 'rxjs/operators';
import { throwError } from 'rxjs';

@Injectable({
    providedIn: 'root'
})
export class LoginService {
    constructor(private http: HttpClient) {}

    public login(username: string, password: string): Observable<any> {
      const body = { username, password };
      const headers = new HttpHeaders({ 'Content-Type': 'application/json' });

      return this.http.post(environment.apiUrl + '/Account/login', body, { headers })
        .pipe(
          catchError(this.handleError)
        );
    }

  private handleError(error: any) {
    // in a real world app, we may send the error to some remote logging infrastructure
    // but for now we'll just log it to the console
    console.error('An error occurred:', error); // log to console instead
    return throwError(() => new Error('Something bad happened; please try again later.'));
  }
}
