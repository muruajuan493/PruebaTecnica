import { Component, OnInit } from '@angular/core';
import { NotificationModel } from '../Common/Models/Notification.model';
import { CommonService } from '../Common/Services/Common.service';

@Component({
  selector: 'app-main',
  templateUrl: './main.component.html',
})
export class MainComponent implements OnInit {
  alerts: NotificationModel[];
  active = 1;

  constructor(private commonService: CommonService) {}

  ngOnInit() {
    this.alerts = [];
    this.suscribirANotificaciones();
  }

  suscribirANotificaciones() {
    this.commonService.getNotificacion().subscribe((notification) => {
      this.alerts.push(notification);
    });
  }

  closeAlert(alert: NotificationModel) {
    this.alerts.splice(this.alerts.indexOf(alert), 1);
  }
}
