import { IResponseBase } from "src/app/Common/Interfaces/IResponseBase";
import { IUsuarioEnListaModel } from "../Usuario";

export interface IObtenerUsuariosResponse extends IResponseBase {
  Usuarios: IUsuarioEnListaModel[]
}
