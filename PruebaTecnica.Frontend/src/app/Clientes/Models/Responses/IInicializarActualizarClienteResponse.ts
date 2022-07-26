import { IResponseBase } from "src/app/Common/Interfaces/IResponseBase";
import { IClienteEnCRUDModel } from "../Cliente";

export interface IInicializarActualizarClienteResponse extends IResponseBase {
  Cliente: IClienteEnCRUDModel
}
