import { IRequestBase } from "src/app/Common/Interfaces/IRequestBase";
import { IUsuarioEnCRUDModel } from "../Usuario";

export interface IActualizarUsuarioRequest extends IRequestBase {
  Usuario: IUsuarioEnCRUDModel
}
