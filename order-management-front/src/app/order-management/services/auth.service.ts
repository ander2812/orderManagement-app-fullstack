import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { tap } from 'rxjs/operators';

interface LoginRequest {
  userName: string;
  password: string;
}

interface AuthResponse {
  accessToken: string;
  expiresAt: string;
  userName: string;
  role: 'Customer' | 'SalesManager';
  customerId?: number | null;
  employeeId?: number | null;
}

const TOKEN_KEY = 'access_token';
const EXP_KEY   = 'access_expires';


const API = 'https://localhost:5001/api';

@Injectable({ providedIn: 'root' })
export class AuthService {
  private _token: string | null = localStorage.getItem(TOKEN_KEY);
  private _expiresAt: Date | null = this.getDate(localStorage.getItem(EXP_KEY));

  constructor(private http: HttpClient) {}

  login(req: LoginRequest) {
    return this.http.post<AuthResponse>(`${API}/auth/login`, req).pipe(
      tap(res => {
        this._token = res.accessToken;
        this._expiresAt = new Date(res.expiresAt);
        localStorage.setItem(TOKEN_KEY, res.accessToken);
        localStorage.setItem(EXP_KEY, res.expiresAt);
      })
    );
  }

  logout() {
    this._token = null;
    this._expiresAt = null;
    localStorage.removeItem(TOKEN_KEY);
    localStorage.removeItem(EXP_KEY);
  }

  get token(): string | null {
    if (!this._token || !this._expiresAt) return null;
    if (this._expiresAt <= new Date()) return null;
    return this._token;
  }

  isLoggedIn(): boolean {
    return !!this.token;
  }

  private getDate(v: string | null): Date | null {
    if (!v) return null;
    const d = new Date(v);
    return isNaN(d.getTime()) ? null : d;
  }
}
