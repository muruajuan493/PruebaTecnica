import { Component, OnInit } from '@angular/core';
import { CommonService } from '../Common/Services/Common.service';
import { ILoginModel } from './Models/Interfaces/ILogin.model';
import { AuthorizationService } from './Services/Authorization.service';

@Component({
  selector: 'app-LoginForm',
  templateUrl: './LoginForm.component.html',
  styleUrls: ['./LoginForm.component.scss'],
})
export class LoginFormComponent implements OnInit {
  UserName: string;
  Password: string;

  constructor( private authServide: AuthorizationService, private commonService: CommonService) {}

  ngOnInit() {}

  login() {
    const login: ILoginModel = {
      NombreDeUsuario: this.UserName,
      Contraseña: this.Password,
    };
    this.authServide.login(login).subscribe((data) => {
      this.authServide.setUser(data);
      this.commonService.announceRedirect("/Inicio");
    });
  }
}
