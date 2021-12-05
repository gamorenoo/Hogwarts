import { CommonModule } from '@angular/common';
import { Component, NgModule, OnInit } from '@angular/core';
import { Persona } from 'src/app/models/persona';
import { EdadService } from 'src/app/services/edad.service';
import { HerokuappService } from 'src/app/services/herokuapp.service';
import { TablePersonModule  } from 'src/app/Componentes/table-person/table-person.component';

@Component({
  selector: 'app-profesores',
  templateUrl: './profesores.component.html',
  styleUrls: ['./profesores.component.css']
})
export class ProfesoresComponent implements OnInit {

  profesores: Persona[] = [];

  constructor(
    private herokuappService: HerokuappService,
    private edadService: EdadService
  ) { }

  ngOnInit(): void {
    this.obtenerProfesores();
  }

  obtenerProfesores() {
    this.profesores = [];
    this.herokuappService.obtenerProfesores().subscribe(response => {
      try {
        this.profesores = response  as Persona[];

        this.profesores.forEach(p => {
          p.age = this.edadService.calcularEdad(p.dateOfBirth)
        });
      } catch (error) {
        console.error(error);
      }
    });
  }

}

@NgModule({
  declarations: [
    ProfesoresComponent
  ],
  exports: [
    ProfesoresComponent
  ],
  imports: [
    CommonModule,
    TablePersonModule
  ]
})

export class ProfesoresModule {}
