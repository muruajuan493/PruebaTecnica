import {
  HttpErrorResponse,
  HttpEvent,
  HttpHandler,
  HttpInterceptor,
  HttpRequest,
} from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError, map, Observable, of, throwError } from 'rxjs';
import { AuthorizationService } from '../Services/Authorization.service';

@Injectable()
export class AuthorizationInterceptor implements HttpInterceptor {
  constructor(private authService: AuthorizationService) {}

  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    const token = this.authService.getToken();
    let request = req;
    if (typeof token === 'string' && token.trim().length > 0) {
      request = req.clone({
        headers: request.headers.set('Authorization', 'Bearer ' + token),
      });
    }
    return next.handle(request).pipe(
      catchError((err: HttpErrorResponse) => {
        return this.handleError(err);
      })
    );
  }

  private handleError(error: any) {
    switch (error.status) {
      case 0:
        console.error('An error occurred:', error.error);
        break;
      case 401:
        this.authService.logout();
        break;
      default:
        console.error(`Backend returned code ${error.status}, body was: `,error.error);
        break;
    }
    return throwError(
      () =>
        new Error(
          'Ocurrio un error en la consulta; Por favor, inténtelo de nuevo más tarde.'
        )
    );
  }
}
