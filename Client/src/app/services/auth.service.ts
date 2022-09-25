import { IAuth } from './../interface/auth';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  authSubject = new BehaviorSubject<IAuth | null>(null);
  auth$ = this.authSubject.asObservable();
  baseUrl = `${environment.apiUrl}/api/auth`;

  constructor(private http: HttpClient) { }

  login(userName: string) {
    this.http.post<IAuth>(`${this.baseUrl}/login/${userName}`, null).subscribe({
      next: auth => this.authSubject.next(auth),
      error: error => console.log(error)
    });
  }

  logout() {
    this.authSubject.next(null);
  }
}
