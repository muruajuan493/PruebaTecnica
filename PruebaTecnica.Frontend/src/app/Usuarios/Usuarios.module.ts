import { NgModule } from '@angular/core';
import { SharedModule } from '../Core/Shared.module';
import { CrudUsuarioComponent } from './Components/CrudUsuario/CrudUsuario.component';
import { UsuariosService } from './Services/Usuarios.service';
import { UsuariosComponent } from './Usuarios.component';

@NgModule({
  imports: [SharedModule],
  declarations: [UsuariosComponent, CrudUsuarioComponent],
  exports: [UsuariosComponent],
  providers: [UsuariosService]
})
export class UsuariosModule {}
