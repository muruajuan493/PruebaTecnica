export interface IUsuarioLogeado {
  IdUsuario: number;
  NombreDeUsuario: string;
  Token: string;
}

export class UsuarioLogeado {
  IdUsuario: number;
  NombreDeUsuario: string;
  Token: string;

  constructor() {
    this.IdUsuario = 0;
    this.NombreDeUsuario = "";
    this.Token = "";
  }
}
