import { IRequestBase } from "src/app/Common/Interfaces/IRequestBase";
import { IUsuarioEnCRUDModel } from "../Usuario";

export interface ICrearUsuarioRequest extends IRequestBase {
  Usuario: IUsuarioEnCRUDModel
}
