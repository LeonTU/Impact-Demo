import { AuthService } from './../services/auth.service';
import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor
} from '@angular/common/http';
import { Observable, take } from 'rxjs';

@Injectable()
export class AuthTokenInterceptor implements HttpInterceptor {

  constructor(private authService: AuthService) { }

  intercept(request: HttpRequest<unknown>, next: HttpHandler): Observable<HttpEvent<unknown>> {
    this.authService.auth$.pipe(take(1)).subscribe(auth => {
      if (auth) {
        request = request.clone({
          setHeaders: {
            Authorization: `Bearer ${auth.token}`
          }
        });
      }
    });

    return next.handle(request);
  }
}
