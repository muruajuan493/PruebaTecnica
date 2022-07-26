import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { NgbActiveModal, NgbModal, NgbModalConfig } from '@ng-bootstrap/ng-bootstrap';
import { AccionEnCrud } from '../Common/Enums/AccionEnCrud.enum';
import { NotificationModel } from '../Common/Models/Notification.model';
import { CommonService } from '../Common/Services/Common.service';
import { IClienteEnListaModel } from './Models/Cliente';
import { ClientesService } from './Services/Clientes.service';

@Component({
  selector: 'app-Clientes',
  templateUrl: './Clientes.component.html',
  providers: [NgbActiveModal, NgbModalConfig, NgbModal],
})
export class ClientesComponent implements OnInit {
  @ViewChild('eliminar') modalEliminar: ElementRef;

  clientes: IClienteEnListaModel[];
  clienteAEliminar: IClienteEnListaModel;

  viewCrud: boolean = false;
  tipoDeAccion: AccionEnCrud = AccionEnCrud.Crear;
  idCliente = 0;

  constructor(
    private clientesService: ClientesService,
    private commonService: CommonService,
    config: NgbModalConfig,
    private modalService: NgbModal
  ) {
    config.backdrop = 'static';
    config.keyboard = false;
    config.centered = true;
  }

  ngOnInit() {
    this.InicializarListaDeClientes();
  }

  InicializarListaDeClientes() {
    this.clientesService.ObtenerClientes().subscribe((res) => {
      if (res.Exito && res.Codigo == 200) {
        if (res.Clientes != null && res.Clientes.length > 0)
          this.clientes = [...res.Clientes];
          return;
      }
      this.clientes = [];
    });
  }

  AccionEditarCliente(IdCliente: number) {
    this.tipoDeAccion = AccionEnCrud.Editar;
    this.idCliente = IdCliente;
    this.viewCrud = !this.viewCrud;
  }

  ShowEliminarCliente(Cliente: IClienteEnListaModel) {
    this.clienteAEliminar = Cliente;
    this.modalService.open(this.modalEliminar).result.then(
      (reason) => {
        this.AccionEliminarCliente(reason);
      });
  }

  AccionEliminarCliente(IdCliente: number) {
    this.clientesService.EliminarCliente(IdCliente).subscribe(res => {
      if (res.Exito && res.Codigo == 200) {
        this.clientes = this.clientes.filter(f => f.Id != IdCliente);
        this.commonService.showSuccess("El cliente se eliminó correctamente");
        return;
      }
      this.commonService.showError("Ocurrió un problema con la eliminación del cliente");
    });
  }

  OnNotification(notification: NotificationModel) {
    this.commonService.sendNotification(notification);
  }

  OnCompletarAccionActual(cliente: IClienteEnListaModel) {
    this.viewCrud = !this.viewCrud;

    if (this.tipoDeAccion == AccionEnCrud.Editar) {
      let idxCliente = this.clientes.findIndex(x => x.Id == cliente.Id);
      this.clientes[idxCliente] = cliente;
    }
    else {
      this.clientes = [...this.clientes, cliente];
    }

    this.tipoDeAccion = AccionEnCrud.Crear;
    this.idCliente = 0;
    this.commonService.showSuccess('La acción se realizó con éxito.');
  }

  OnCancelarAccionActual() {
    this.viewCrud = !this.viewCrud;
    this.tipoDeAccion = AccionEnCrud.Crear;
    this.idCliente = 0;
    this.commonService.showWarn('La acción ha sido cancelada por el usuario.');
  }
}
