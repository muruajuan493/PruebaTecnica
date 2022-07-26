import { IResponseBase } from "src/app/Common/Interfaces/IResponseBase";
import { IClienteEnListaModel } from "../Cliente";

export interface IActualizarClienteResponse extends IResponseBase {
  Cliente: IClienteEnListaModel
}
