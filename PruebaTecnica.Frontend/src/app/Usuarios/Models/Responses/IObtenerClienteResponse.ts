import { IResponseBase } from "src/app/Common/Interfaces/IResponseBase";
import { IUsuarioEnListaModel } from "../Usuario";

export interface IObtenerUsuarioResponse extends IResponseBase {
  Usuario: IUsuarioEnListaModel
}
