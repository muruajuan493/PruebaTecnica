import { IResponseBase } from "src/app/Common/Interfaces/IResponseBase";
import { IClienteEnCRUDModel } from "../Cliente";

export interface IInicializarCrearClienteResponse extends IResponseBase {
  Cliente: IClienteEnCRUDModel
}
