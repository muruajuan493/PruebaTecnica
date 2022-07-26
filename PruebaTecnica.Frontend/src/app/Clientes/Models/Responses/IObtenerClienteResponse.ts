import { IResponseBase } from "src/app/Common/Interfaces/IResponseBase";
import { IClienteEnListaModel } from "../Cliente";

export interface IObtenerClienteResponse extends IResponseBase {
  Cliente: IClienteEnListaModel
}
