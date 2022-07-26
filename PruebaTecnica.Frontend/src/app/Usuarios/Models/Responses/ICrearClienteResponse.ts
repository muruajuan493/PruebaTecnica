import { IResponseBase } from "src/app/Common/Interfaces/IResponseBase";
import { IUsuarioEnListaModel } from "../Usuario";

export interface ICrearUsuarioResponse extends IResponseBase {
  Usuario: IUsuarioEnListaModel
}
