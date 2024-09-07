import {Injectable} from "@angular/core";

@Injectable({
    providedIn: 'root'
})
export class AuthService {
  private _tokenKey: string = 'jwtToken';
  constructor() {}

  public setToken(token: string) {
    localStorage.setItem(this._tokenKey, token);
  }

  public getToken(): string | null {
    return localStorage.getItem(this._tokenKey);
  }

  public removeToken() {
    localStorage.removeItem(this._tokenKey);
  }
}
