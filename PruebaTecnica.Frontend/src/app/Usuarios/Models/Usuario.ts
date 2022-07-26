import { IBaseEntity } from 'src/app/Common/Interfaces/IBaseEntity';

export interface IUsuarioEnCRUDModel extends IBaseEntity {
  NombreCompleto: string;
  NombreDeUsuario: string;
  Contraseña: string;
  ActivoActualmente: boolean;
}

export interface IUsuarioEnListaModel extends IBaseEntity {
  NombreCompleto: string;
  NombreDeUsuario: string;
  ActivoActualmente: string;
}
