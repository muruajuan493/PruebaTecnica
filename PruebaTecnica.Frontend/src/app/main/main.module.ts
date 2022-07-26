import { NgModule } from '@angular/core';
import { AuthorizationModule } from '../Authorization/Authorization.module';
import { ClientesModule } from '../Clientes/Clientes.module';
import { NavbarModule } from '../Common/Components/Navbar/Navbar.module';
import { SharedModule } from '../Core/Shared.module';
import { UsuariosModule } from '../Usuarios/Usuarios.module';
import { MainComponent } from './main.component';

@NgModule({
  imports: [
    SharedModule,
    AuthorizationModule,
    NavbarModule,
    ClientesModule,
    UsuariosModule,
  ],
  declarations: [MainComponent],
  exports: [MainComponent],
})
export class MainModule {}
