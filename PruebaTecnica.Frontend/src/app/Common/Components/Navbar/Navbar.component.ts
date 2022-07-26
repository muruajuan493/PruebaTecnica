import { Component, OnInit } from '@angular/core';
import { AuthorizationService } from 'src/app/Authorization/Services/Authorization.service';

@Component({
  selector: 'app-navbar',
  templateUrl: './Navbar.component.html',
})
export class NavbarComponent implements OnInit {
  public UserName: string = '';

  constructor(private authService: AuthorizationService) {}

  ngOnInit() {
    this.UserName = this.authService.getUserName();
  }

  logout() {
    this.authService.logout();
  }
}
