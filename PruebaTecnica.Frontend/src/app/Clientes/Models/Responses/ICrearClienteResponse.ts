import { IResponseBase } from "src/app/Common/Interfaces/IResponseBase";
import { IClienteEnListaModel } from "../Cliente";

export interface ICrearClienteResponse extends IResponseBase {
  Cliente: IClienteEnListaModel
}
