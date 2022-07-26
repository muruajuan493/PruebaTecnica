import { IRequestBase } from "src/app/Common/Interfaces/IRequestBase";
import { IClienteEnCRUDModel } from "../Cliente";

export interface IActualizarClienteRequest extends IRequestBase {
  Cliente: IClienteEnCRUDModel
}
