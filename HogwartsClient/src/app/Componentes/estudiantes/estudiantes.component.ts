import { CommonModule } from '@angular/common';
import { Component, NgModule, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { Persona } from 'src/app/models/persona';
import { Solicitud } from 'src/app/models/solicitud';
import { EdadService } from 'src/app/services/edad.service';
import { HerokuappService } from 'src/app/services/herokuapp.service';
import { HogwartsApiService } from 'src/app/services/hogwartsApi.service';
import { CustomSelectModule, CustomSelectComponent } from 'src/app/Componentes/custom-select/custom-select.component';
import { TablePersonModule  } from 'src/app/Componentes/table-person/table-person.component';

@Component({
  selector: 'app-estudiantes',
  templateUrl: './estudiantes.component.html',
  styleUrls: ['./estudiantes.component.css']
})
export class EstudiantesComponent implements OnInit {
  @ViewChild('customSelect') customSelectComponent!: CustomSelectComponent;
  formSolicitud!: FormGroup;
  estudiantes: Persona[] = [];
  modeMain = true;
  solicitud: Solicitud = new Solicitud();
  solicitudes: Solicitud[] = [];
  mensajeError = '';
  verError = false;
  casa = '0';
  constructor(
    private herokuappService: HerokuappService,
    private edadService: EdadService,
    private hogwartsApiService: HogwartsApiService,
    private fb: FormBuilder
  ) { }

  ngOnInit(): void {

    this.formSolicitud = this.fb.group({
      identificacion: new FormControl('', [
        Validators.required,
      ]),
      nombre: new FormControl('', [
        Validators.required,
      ]),
      apellido: new FormControl('', [
        Validators.required,
      ]),
      edad: new FormControl('', [
        Validators.required,
      ])
    })

    this.obtenerEstudiantes();
  }

  obtenerEstudiantes() {
    this.estudiantes = [];
    this.herokuappService.obtenerEstudiantes().subscribe(response => {
      try {
        this.estudiantes = response  as Persona[];
        this.estudiantes.forEach(p => {
          p.age = this.edadService.calcularEdad(p.dateOfBirth)
        });
      } catch (error) {
        console.error(error);
      }
    });
  }

  obtenerSolicitudes() {
    this.solicitudes = [];
    this.hogwartsApiService.get().subscribe(response => {
      try {
        this.solicitudes = response  as Solicitud[];
      } catch (error) {
        console.error(error);
      }
    });
  }

  guardarSolicitud() {
    this.hogwartsApiService.post(this.solicitud).subscribe(response => {
      try {
        this.solicitud = new Solicitud();
        this.obtenerSolicitudes();
        this.resetForm();
        this.casa = '0';
        this.customSelectComponent.casa = '0';
      } catch (error) {
        console.error(error);
      }
    });
  }

  verEstudiantes() {
    this.modeMain = true;
  }

  verNuevosEstudiantes(){
    this.obtenerSolicitudes();
    this.modeMain = false;
  }

  crearSolicitud() {
    this.solicitud.identificacion = this.formSolicitud.controls['identificacion'].value;
    this.solicitud.nombre = this.formSolicitud.controls['nombre'].value;
    this.solicitud.apellido = this.formSolicitud.controls['apellido'].value;
    this.solicitud.edad = this.formSolicitud.controls['edad'].value;
    if(this.solicitud.casa == '' || this.solicitud.casa == '0') {
      this.verError = true;
      this.mensajeError = "Debe seleccionar una casa";
    } else {
      this.verError = false;
      this.guardarSolicitud();
    }
  }

  resetForm() {
    this.formSolicitud.controls['identificacion'].setValue('');
    this.formSolicitud.controls['nombre'].setValue('');
    this.formSolicitud.controls['apellido'].setValue('');
    this.formSolicitud.controls['edad'].setValue('');
  }

  onListSelection(e: any) {
    this.casa = e.casaSeleccionada;
    this.solicitud.casa = this.casa;
  }

}

@NgModule({
  declarations: [
    EstudiantesComponent
  ],
  exports: [
    EstudiantesComponent
  ],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    CustomSelectModule,
    TablePersonModule
  ]
})

export class EstudiantesModule {}
