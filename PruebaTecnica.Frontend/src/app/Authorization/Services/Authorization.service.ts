import { Injectable } from '@angular/core';
import { Observable, Subject } from 'rxjs';
import { HttpClient } from 'src/app/Common/Services/HttpClient.Service';
import { CommonService } from 'src/app/Common/Services/Common.service';
import { ILoginRequestModel } from '../Models/Requests/ILoginRequest.model';
import { ILoginResponseModel } from '../Models/Responses/ILoginResponse.model';
import { UsuarioLogeado } from '../Models/UsuarioLogeado.model';

@Injectable({
  providedIn: 'root',
})
export class AuthorizationService {
  constructor(private http: HttpClient, private commonService: CommonService) {}

  login(body: ILoginRequestModel): Observable<ILoginResponseModel> {
    return this.http.post('Authorization/Authenticate', body);
  }

  setUser(userData: ILoginResponseModel) {
    this.commonService.setCookie('idUsuario', userData.IdUsuario.toString());
    this.commonService.setCookie('nombreDeUsuario', userData.NombreDeUsuario);
    this.commonService.setCookie('token', userData.Token);
  }

  getUserName(): string {
    return this.commonService.getCookie('nombreDeUsuario');
  }

  getToken(): string {
    return this.commonService.getCookie('token');
  }

  isLogged(): boolean {
    let token = this.getToken();

    if (typeof token === "string" && token.trim().length > 0) {
      return true;
    }

    this.logout();
    return false;
  }

  logout() {
    this.commonService.deleteCookie('idUsuario');
    this.commonService.deleteCookie('nombreDeUsuario');
    this.commonService.deleteCookie('token');
    this.commonService.announceRedirect('/Login');
  }
}
