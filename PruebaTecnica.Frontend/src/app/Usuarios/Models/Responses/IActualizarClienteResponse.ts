import { IResponseBase } from "src/app/Common/Interfaces/IResponseBase";
import { IUsuarioEnListaModel } from "../Usuario";

export interface IActualizarUsuarioResponse extends IResponseBase {
  Usuario: IUsuarioEnListaModel
}
