import { IResponseBase } from "src/app/Common/Interfaces/IResponseBase";
import { IClienteEnListaModel } from "../Cliente";

export interface IObtenerClientesResponse extends IResponseBase {
  Clientes: IClienteEnListaModel[]
}
