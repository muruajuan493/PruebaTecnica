import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormGroup, Validators, AbstractControl, FormBuilder } from '@angular/forms';
import { AccionEnCrud } from 'src/app/Common/Enums/AccionEnCrud.enum';
import { TiposDeAlertas } from 'src/app/Common/Enums/TiposDeAlertas.enum';
import { NotificationModel } from 'src/app/Common/Models/Notification.model';
import { ICrearUsuarioRequest } from '../../Models/Requests/ICrearClienteRequest';
import { IUsuarioEnListaModel, IUsuarioEnCRUDModel } from '../../Models/Usuario';
import { UsuariosService } from '../../Services/Usuarios.service';

@Component({
  selector: 'app-CrudUsuario',
  templateUrl: './CrudUsuario.component.html',
})
export class CrudUsuarioComponent implements OnInit {
  @Input() TipoDeAccion: AccionEnCrud = AccionEnCrud.Crear;
  @Input() IdUsuario: number = 0;
  @Output() OnNotificacion = new EventEmitter<NotificationModel>();
  @Output() OnAccionComplete = new EventEmitter<IUsuarioEnListaModel>();
  @Output() OnCancelar = new EventEmitter();

  tituloDeCrud: string = '';
  textoDeSubmit: string = '';

  usuarioFrontView: FormGroup;
  submitted: boolean = false;
  usuarioModel: IUsuarioEnCRUDModel;

  constructor(private formBuilder: FormBuilder, private usuarioService: UsuariosService) {}

  ngOnInit() {
    switch (this.TipoDeAccion.toString()) {
      case AccionEnCrud.Crear.toString():
        this.nuevoUsuario();
        break;
      case AccionEnCrud.Editar.toString():
        this.editarUsuario();
        break;
    }
  }

  private nuevoUsuario() {
    this.tituloDeCrud = 'Creacion de nuevo Usuario';
    this.textoDeSubmit = 'Guardar usuario';
    this.usuarioService.InicializarCrearUsuario().subscribe((res) => {
      this.usuarioFrontView = this.formModel(res.Usuario);
    });
  }

  private editarUsuario() {
    this.tituloDeCrud = 'Edicion de usuario';
    this.textoDeSubmit = 'Actualizar usuario';
    if (this.IdUsuario > 0) {
      this.usuarioService
        .InicializarActualizarUsuario(this.IdUsuario)
        .subscribe((res) => {
          this.usuarioFrontView = this.formModel(res.Usuario);
        });
    }
  }

  private formModel(usuarioModel: IUsuarioEnCRUDModel): FormGroup {
    this.usuarioModel = usuarioModel;
    return this.formBuilder.group({
      NombreCompleto: [usuarioModel.NombreCompleto, Validators.required],
      NombreDeUsuario: [usuarioModel.NombreDeUsuario, Validators.required],
      Contraseña: [usuarioModel.Contraseña, Validators.required],
      RepeaTContraseña: [usuarioModel.Contraseña, Validators.required],
      ActivoActualmente: [usuarioModel.ActivoActualmente, Validators.required],
    },
    {
      validator: this.MustMatch("Contraseña", "RepeaTContraseña")
    });
  }

  MustMatch(controlName: string, matchingControlName: string) {
    return (formGroup: FormGroup) => {
      const control = formGroup.controls[controlName];
      const matchingControl = formGroup.controls[matchingControlName];

      if (matchingControl.errors && !matchingControl.errors["mustMatch"]) {
        return;
      }

      if (control.value !== matchingControl.value) {
        matchingControl.setErrors({ mustMatch: true });
      } else {
        matchingControl.setErrors(null);
      }
    };
  }

  get form(): { [key: string]: AbstractControl } {
    return this.usuarioFrontView.controls;
  }

  onSubmint() {
    this.submitted = true;

    if (this.usuarioFrontView.invalid) return;

    let usuarioRequest: ICrearUsuarioRequest = {
      Usuario: {
        ...this.usuarioFrontView.value,
      },
    };

    switch (this.TipoDeAccion.toString()) {
      case AccionEnCrud.Crear.toString():
        this.usuarioService.CrearUsuario(usuarioRequest).subscribe((res) => {
          if (res.Exito && res.Codigo == 200) {
            if (res.Usuario != null) this.OnAccionComplete.emit(res.Usuario);
            return;
          }
          let notification = new NotificationModel(TiposDeAlertas.warning, res.Mensaje);
          this.OnNotificacion.emit(notification);
        });
        break;
      case AccionEnCrud.Editar.toString():
        usuarioRequest.Usuario.Id = this.usuarioModel.Id;
        this.usuarioService.ActualizarUsuario(usuarioRequest).subscribe((res) => {
          if (res.Exito && res.Codigo == 200) {
            if (res.Usuario != null) this.OnAccionComplete.emit(res.Usuario);
            return;
          }
          let notification = new NotificationModel(TiposDeAlertas.warning, res.Mensaje);
          this.OnNotificacion.emit(notification);
        });
        break;
    }
  }

  onCancelar() {
    this.OnCancelar.emit();
  }
}
