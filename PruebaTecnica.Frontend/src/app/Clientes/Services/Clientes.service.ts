import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient } from 'src/app/Common/Services/HttpClient.Service';
import { IResponseBase } from 'src/app/Common/Interfaces/IResponseBase';
import { IActualizarClienteRequest } from '../Models/Requests/IActualizarClienteRequest';
import { ICrearClienteRequest } from '../Models/Requests/ICrearClienteRequest';
import { IActualizarClienteResponse } from '../Models/Responses/IActualizarClienteResponse';
import { ICrearClienteResponse } from '../Models/Responses/ICrearClienteResponse';
import { IInicializarActualizarClienteResponse } from '../Models/Responses/IInicializarActualizarClienteResponse';
import { IInicializarCrearClienteResponse } from '../Models/Responses/IInicializarCrearClienteResponse';
import { IObtenerClienteResponse } from '../Models/Responses/IObtenerClienteResponse';
import { IObtenerClientesResponse } from '../Models/Responses/IObtenerClientesResponse';

@Injectable()
export class ClientesService {

  constructor(private http: HttpClient) {}

  ObtenerCliente(IdCliente: number): Observable<IObtenerClienteResponse> {
    return this.http.get(`Clientes/ObtenerCliente/${IdCliente}`);
  }

  ObtenerClientes(): Observable<IObtenerClientesResponse> {
    return this.http.get('Clientes/ObtenerClientes');
  }

  InicializarCrearCliente(): Observable<IInicializarCrearClienteResponse> {
    return this.http.get('Clientes/InicializarCrearCliente');
  }

  CrearCliente(body: ICrearClienteRequest): Observable<ICrearClienteResponse> {
    return this.http.post('Clientes/CrearCliente', body);
  }

  InicializarActualizarCliente(IdCliente: number): Observable<IInicializarActualizarClienteResponse> {
    return this.http.get(`Clientes/InicializarActualizarCliente/${IdCliente}`);
  }

  ActualizarCliente(body: IActualizarClienteRequest): Observable<IActualizarClienteResponse> {
    return this.http.post('Clientes/ActualizarCliente', body);
  }

  EliminarCliente(IdCliente: number): Observable<IResponseBase> {
    return this.http.delete(`Clientes/EliminarCliente/${IdCliente}`);
  }
}
