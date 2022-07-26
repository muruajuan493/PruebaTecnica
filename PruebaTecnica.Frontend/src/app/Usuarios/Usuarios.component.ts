import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { NgbModalConfig, NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { AccionEnCrud } from '../Common/Enums/AccionEnCrud.enum';
import { NotificationModel } from '../Common/Models/Notification.model';
import { CommonService } from '../Common/Services/Common.service';
import { IUsuarioEnListaModel } from './Models/Usuario';
import { UsuariosService } from './Services/Usuarios.service';

@Component({
  selector: 'app-Usuarios',
  templateUrl: './Usuarios.component.html',
})
export class UsuariosComponent implements OnInit {

  @ViewChild('eliminar') modalEliminar: ElementRef;

  usuarios: IUsuarioEnListaModel[];
  usuarioAEliminar: IUsuarioEnListaModel;

  viewCrud: boolean = false;
  tipoDeAccion: AccionEnCrud = AccionEnCrud.Crear;
  idUsuario = 0;

  constructor(
    private usuariosService: UsuariosService,
    private commonService: CommonService,
    config: NgbModalConfig,
    private modalService: NgbModal
  ) {
    config.backdrop = 'static';
    config.keyboard = false;
    config.centered = true;
  }

  ngOnInit() {
    this.InicializarListaDeUsuarios();
  }

  InicializarListaDeUsuarios() {
    this.usuariosService.ObtenerUsuarios().subscribe((res) => {
      if (res.Exito && res.Codigo == 200) {
        if (res.Usuarios != null && res.Usuarios.length > 0)
          this.usuarios = [...res.Usuarios];
          return;
      }
      this.usuarios = [];
    });
  }

  AccionEditarUsuario(IdUsuario: number) {
    this.tipoDeAccion = AccionEnCrud.Editar;
    this.idUsuario = IdUsuario;
    this.viewCrud = !this.viewCrud;
  }

  ShowEliminarUsuario(Usuario: IUsuarioEnListaModel) {
    this.usuarioAEliminar = Usuario;
    this.modalService.open(this.modalEliminar).result.then(
      (reason) => {
        this.AccionEliminarUsuario(reason);
      });
  }

  AccionEliminarUsuario(IdUsuario: number) {
    this.usuariosService.EliminarUsuario(IdUsuario).subscribe(res => {
      if (res.Exito && res.Codigo == 200) {
        this.usuarios = this.usuarios.filter(f => f.Id != IdUsuario);
        this.commonService.showSuccess("El usuario se eliminó correctamente");
        return;
      }
      this.commonService.showError("Ocurrió un problema con la eliminación del usuario");
    });
  }

  OnNotification(notification: NotificationModel) {
    this.commonService.sendNotification(notification);
  }

  OnCompletarAccionActual(usuario: IUsuarioEnListaModel) {
    this.viewCrud = !this.viewCrud;

    if (this.tipoDeAccion == AccionEnCrud.Editar) {
      let idxUsuario = this.usuarios.findIndex(x => x.Id == usuario.Id);
      this.usuarios[idxUsuario] = usuario;
    }
    else {
      this.usuarios = [...this.usuarios, usuario];
    }

    this.tipoDeAccion = AccionEnCrud.Crear;
    this.idUsuario = 0;
    this.commonService.showSuccess('La acción se realizó con éxito.');
  }

  OnCancelarAccionActual() {
    this.viewCrud = !this.viewCrud;
    this.tipoDeAccion = AccionEnCrud.Crear;
    this.idUsuario = 0;
    this.commonService.showWarn('La acción ha sido cancelada por el usuario.');
  }
}
