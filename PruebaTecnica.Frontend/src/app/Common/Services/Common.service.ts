import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { CookieService } from 'ngx-cookie-service';
import { Observable, Subject } from 'rxjs';
import { TiposDeAlertas } from '../Enums/TiposDeAlertas.enum';
import { NotificationModel } from '../Models/Notification.model';

@Injectable({
  providedIn: 'root',
})
export class CommonService {
  showNotificacionSource: Subject<NotificationModel> = new Subject<NotificationModel>();

  constructor(private router: Router, private cookieService: CookieService) {}

  /**
   * Routing
   */
  announceRedirect(path: string) {
    this.router.navigate([path]);
  }

  /**
   * Cookies
   */
  setCookie(name: string, value: string) {
    this.cookieService.set(name, value);
  }

  getCookie(name: string): string {
    return this.cookieService.get(name);
  }

  deleteCookie(name: string) {
    this.cookieService.delete(name);
  }

  /**
   * Notification
   */

  getNotificacion(): Observable<NotificationModel> {
    return this.showNotificacionSource.asObservable();
  }

  sendNotification(notificacion: NotificationModel): void {
    this.notify(notificacion);
  }

  showSuccess(msg: string) {
    this.show(TiposDeAlertas.success, msg);
  }

  showWarn(msg: string) {
    this.show(TiposDeAlertas.warning, msg);
  }

  showError(msg: string) {
    this.show(TiposDeAlertas.danger, msg);
  }

  private show(severity: TiposDeAlertas, msg: string) {
    const notificacion = new NotificationModel(severity, msg);
    this.notify(notificacion);
  }

  private notify(notificacion: NotificationModel): void {
    this.showNotificacionSource.next(notificacion);
  }
}
