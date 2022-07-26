import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import {
  AbstractControl,
  FormBuilder,
  FormGroup,
  Validators
} from '@angular/forms';
import { AccionEnCrud } from 'src/app/Common/Enums/AccionEnCrud.enum';
import { TiposDeAlertas } from 'src/app/Common/Enums/TiposDeAlertas.enum';
import { NotificationModel } from 'src/app/Common/Models/Notification.model';
import {
  IClienteEnCRUDModel,
  IClienteEnListaModel
} from '../../Models/Cliente';
import { ICrearClienteRequest } from '../../Models/Requests/ICrearClienteRequest';
import { ClientesService } from '../../Services/Clientes.service';

@Component({
  selector: 'app-CrudClientes',
  templateUrl: './CrudClientes.component.html',
})
export class CrudClientesComponent implements OnInit {
  @Input() TipoDeAccion: AccionEnCrud = AccionEnCrud.Crear;
  @Input() IdCliente: number = 0;
  @Output() OnNotificacion = new EventEmitter<NotificationModel>();
  @Output() OnAccionComplete = new EventEmitter<IClienteEnListaModel>();
  @Output() OnCancelar = new EventEmitter();

  tituloDeCrud: string = '';
  textoDeSubmit: string = '';

  clienteFrontView: FormGroup;
  submitted: boolean = false;
  clienteModel: IClienteEnCRUDModel;

  constructor(private formBuilder: FormBuilder, private clienteService: ClientesService) { }

  ngOnInit() {
    switch (this.TipoDeAccion.toString()) {
      case AccionEnCrud.Crear.toString():
        this.nuevoCliente();
        break;
      case AccionEnCrud.Editar.toString():
        this.editarCliente();
        break;
    }
  }

  private nuevoCliente() {
    this.tituloDeCrud = 'Creacion de nuevo Cliente';
    this.textoDeSubmit = 'Guardar cliente';
    this.clienteService.InicializarCrearCliente().subscribe((res) => {
      this.clienteFrontView = this.formModel(res.Cliente);
    });
  }

  private editarCliente() {
    this.tituloDeCrud = 'Edicion de cliente';
    this.textoDeSubmit = 'Actualizar cliente';
    if (this.IdCliente > 0) {
      this.clienteService
        .InicializarActualizarCliente(this.IdCliente)
        .subscribe((res) => {
          this.clienteFrontView = this.formModel(res.Cliente);
        });
    }
  }

  private formModel(clienteModel: IClienteEnCRUDModel): FormGroup {
    this.clienteModel = clienteModel;
    return this.formBuilder.group({
      Nombre: [clienteModel.Nombre, Validators.required],
      Apellido: [clienteModel.Apellido, Validators.required],
      FechaDeNacimiento: [clienteModel.FechaDeNacimiento, Validators.required],
      IdGenero: [clienteModel.IdGenero, Validators.required],
      IdTipoDeIdentificacion: [clienteModel.IdTipoDeIdentificacion, Validators.required],
      NumeroDeIdentificacion: [clienteModel.NumeroDeIdentificacion, Validators.required],
      Maneja: [clienteModel.Maneja, Validators.required],
      UsaLentes: [clienteModel.UsaLentes, Validators.required],
      TieneDiabetes: [clienteModel.TieneDiabetes],
      TieneOtrasEnfermedades: [clienteModel.TieneOtrasEnfermedades, Validators.required],
      OtrasEnfermedades: [clienteModel.OtrasEnfermedades],
      ActivoActualmente: [clienteModel.ActivoActualmente, Validators.required],
    });
  }

  get form(): { [key: string]: AbstractControl } {
    return this.clienteFrontView.controls;
  }

  onSubmint() {
    this.submitted = true;

    if (this.clienteFrontView.invalid) return;

    let clienteRequest: ICrearClienteRequest = {
      Cliente: {
        ...this.clienteFrontView.value,
      },
    };

    switch (this.TipoDeAccion.toString()) {
      case AccionEnCrud.Crear.toString():
        this.clienteService.CrearCliente(clienteRequest).subscribe((res) => {
          if (res.Exito && res.Codigo == 200) {
            if (res.Cliente != null) this.OnAccionComplete.emit(res.Cliente);
            return;
          }
          let notification = new NotificationModel(TiposDeAlertas.warning, res.Mensaje);
          this.OnNotificacion.emit(notification);
        });
        break;
      case AccionEnCrud.Editar.toString():
        clienteRequest.Cliente.Id = this.clienteModel.Id;
        this.clienteService.ActualizarCliente(clienteRequest).subscribe((res) => {
          if (res.Exito && res.Codigo == 200) {
            if (res.Cliente != null) this.OnAccionComplete.emit(res.Cliente);
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
