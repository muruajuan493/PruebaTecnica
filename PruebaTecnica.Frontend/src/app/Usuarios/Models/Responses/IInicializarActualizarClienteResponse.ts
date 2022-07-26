import { IResponseBase } from "src/app/Common/Interfaces/IResponseBase";
import { IUsuarioEnCRUDModel } from "../Usuario";

export interface IInicializarActualizarUsuarioResponse extends IResponseBase {
  Usuario: IUsuarioEnCRUDModel
}
