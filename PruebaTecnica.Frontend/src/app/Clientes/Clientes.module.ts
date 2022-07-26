import { NgModule } from '@angular/core';
import { SharedModule } from '../Core/Shared.module';
import { ClientesComponent } from './Clientes.component';
import { CrudClientesComponent } from './Components/CrudClientes/CrudClientes.component';
import { ClientesService } from './Services/Clientes.service';

@NgModule({
  imports: [SharedModule],
  declarations: [ClientesComponent, CrudClientesComponent],
  exports: [ClientesComponent],
  providers: [ClientesService]
})
export class ClientesModule {}
