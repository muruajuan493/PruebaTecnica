import { IResponseBase } from "src/app/Common/Interfaces/IResponseBase";
import { IUsuarioEnCRUDModel } from "../Usuario";

export interface IInicializarCrearUsuarioResponse extends IResponseBase {
  Usuario: IUsuarioEnCRUDModel
}
