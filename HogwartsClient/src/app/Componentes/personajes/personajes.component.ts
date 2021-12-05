import { CommonModule } from '@angular/common';
import { Component, NgModule, OnInit } from '@angular/core';
import { Persona } from 'src/app/models/persona';
import { HerokuappService } from 'src/app/services/herokuapp.service';
import { CustomSelectModule } from 'src/app/Componentes/custom-select/custom-select.component'
import { EdadService } from 'src/app/services/edad.service';
import { TablePersonModule  } from 'src/app/Componentes/table-person/table-person.component';

@Component({
  selector: 'app-personajes',
  templateUrl: './personajes.component.html',
  styleUrls: ['./personajes.component.css']
})
export class PersonajesComponent implements OnInit {

  personajes: Persona[] = [];

  constructor(
    private herokuappService: HerokuappService,
    private edadService: EdadService
  ) { }

  ngOnInit(): void {
  }

  obtenerPersonaje(casa: string) {
    this.personajes = [];
    this.herokuappService.obtenerPersonajes(casa).subscribe(response => {
      try {
        this.personajes = response  as Persona[];

        this.personajes.forEach(p => {
          p.age = this.edadService.calcularEdad(p.dateOfBirth)
        });
      } catch (error) {
        console.error(error);
      }
    });
  }


  onListSelection(e: any) {
    // console.log(e.casaSeleccionada);
    this.obtenerPersonaje(e.casaSeleccionada);
  }

}

@NgModule({
  declarations: [
    PersonajesComponent
  ],
  exports: [
    PersonajesComponent
  ],
  imports: [
    CommonModule,
    CustomSelectModule,
    TablePersonModule
  ]
})

export class PersonajesModule {}
