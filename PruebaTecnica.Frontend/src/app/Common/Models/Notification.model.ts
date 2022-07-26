import { TiposDeAlertas } from '../Enums/TiposDeAlertas.enum';

export class NotificationModel {
  type: string;
  message: string;

  constructor(tipo?: TiposDeAlertas, mensaje?: string) {
    this.type = tipo != null ? tipo : TiposDeAlertas.success;
    this.message = mensaje != null ? mensaje : '';
  }
}
