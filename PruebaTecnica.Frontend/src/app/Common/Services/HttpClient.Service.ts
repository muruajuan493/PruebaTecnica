import { HttpClient as HttpC, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root',
})
export class HttpClient {
  private baseUrl: string = environment.baseUrl;

  constructor(private http: HttpC) {}

  public get(url: string): Observable<any> {
    const headers = this.setHeaders();

    return this.http.get(this.baseUrl + url, { headers: headers });
  }

  public post(url: string, body: any): Observable<any> {
    const headers = this.setHeaders();

    return this.http.post(this.baseUrl + url, body, { headers: headers });
  }

  public delete(url: string): Observable<any> {
    const headers = this.setHeaders();

    return this.http.delete(this.baseUrl + url, { headers: headers });
  }

  private setHeaders(): HttpHeaders {
    return new HttpHeaders({
      Accept: 'application/json',
      'Content-Type': 'application/json',
      From: 'PruebaTecnicaFrontend',
    });
  }
}
