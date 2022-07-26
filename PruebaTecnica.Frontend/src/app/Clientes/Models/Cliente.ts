import { IBaseEntity } from 'src/app/Common/Interfaces/IBaseEntity';
import { ISelector } from 'src/app/Common/Interfaces/ISelector';

export interface IClienteEnCRUDModel extends IBaseEntity {
  Nombre: string;
  Apellido: string;
  FechaDeNacimiento: string;
  IdGenero: number;
  Generos: ISelector[];
  IdTipoDeIdentificacion: string;
  TiposDeIdentificacion: ISelector[];
  NumeroDeIdentificacion: string;
  Maneja: boolean;
  UsaLentes: boolean;
  TieneDiabetes: boolean;
  TieneOtrasEnfermedades: boolean;
  OtrasEnfermedades: string;
  ActivoActualmente: boolean;
}

export interface IClienteEnListaModel extends IBaseEntity {
  Nombre: string;
  Apellido: string;
  Edad: string;
  Genero: string;
  TipoDeIdentificacion: string;
  NumeroDeIdentificacion: string;
  Maneja: string;
  UsaLentes: string;
  TieneDiabetes: string;
  TieneOtrasEnfermedades: string;
  OtrasEnfermedades: string;
  ActivoActualmente: string;
}
