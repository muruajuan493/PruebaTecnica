import { IResponseBase } from "src/app/Common/Interfaces/IResponseBase";

export interface ILoginResponseModel extends IResponseBase {
  IdUsuario: number;
  NombreDeUsuario: string;
  Token: string;
}
