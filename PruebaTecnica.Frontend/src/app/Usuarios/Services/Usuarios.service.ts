import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient } from 'src/app/Common/Services/HttpClient.Service';
import { IResponseBase } from 'src/app/Common/Interfaces/IResponseBase';
import { IActualizarUsuarioRequest } from '../Models/Requests/IActualizarClienteRequest';
import { ICrearUsuarioRequest } from '../Models/Requests/ICrearClienteRequest';
import { IActualizarUsuarioResponse } from '../Models/Responses/IActualizarClienteResponse';
import { ICrearUsuarioResponse } from '../Models/Responses/ICrearClienteResponse';
import { IInicializarActualizarUsuarioResponse } from '../Models/Responses/IInicializarActualizarClienteResponse';
import { IInicializarCrearUsuarioResponse } from '../Models/Responses/IInicializarCrearClienteResponse';
import { IObtenerUsuarioResponse } from '../Models/Responses/IObtenerClienteResponse';
import { IObtenerUsuariosResponse } from '../Models/Responses/IObtenerClientesResponse';

@Injectable()
export class UsuariosService {
  constructor(private http: HttpClient) {}

  ObtenerUsuario(IdUsuario: number): Observable<IObtenerUsuarioResponse> {
    return this.http.get(`Usuarios/ObtenerUsuario/${IdUsuario}`);
  }

  ObtenerUsuarios(): Observable<IObtenerUsuariosResponse> {
    return this.http.get('Usuarios/ObtenerUsuarios');
  }

  InicializarCrearUsuario(): Observable<IInicializarCrearUsuarioResponse> {
    return this.http.get('Usuarios/InicializarCrearUsuario');
  }

  CrearUsuario(body: ICrearUsuarioRequest): Observable<ICrearUsuarioResponse> {
    return this.http.post('Usuarios/CrearUsuario', body);
  }

  InicializarActualizarUsuario(IdUsuario: number): Observable<IInicializarActualizarUsuarioResponse> {
    return this.http.get(`Usuarios/InicializarActualizarUsuario/${IdUsuario}`);
  }

  ActualizarUsuario(body: IActualizarUsuarioRequest): Observable<IActualizarUsuarioResponse> {
    return this.http.post('Usuarios/ActualizarUsuario', body);
  }

  EliminarUsuario(IdUsuario: number): Observable<IResponseBase> {
    return this.http.delete(`Usuarios/EliminarUsuario/${IdUsuario}`);
  }
}
