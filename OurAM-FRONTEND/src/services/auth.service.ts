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

  public isAuthenticated(): boolean {
    const token = this.getToken();
    if (!token) return false;

    const tokenData = JSON.parse(atob(token.split('.')[1]));
    const expirationDate = new Date(tokenData.exp * 1000);

    return expirationDate > new Date();
  }
}
