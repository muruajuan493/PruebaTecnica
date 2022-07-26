import { IRequestBase } from "src/app/Common/Interfaces/IRequestBase";
import { IClienteEnCRUDModel } from "../Cliente";

export interface ICrearClienteRequest extends IRequestBase {
  Cliente: IClienteEnCRUDModel
}
