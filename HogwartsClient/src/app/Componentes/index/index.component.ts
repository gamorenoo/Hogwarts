import { CommonModule } from '@angular/common';
import { Component, NgModule, OnInit } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { PersonajesModule } from 'src/app/Componentes/personajes/personajes.component';
import { ProfesoresModule } from 'src/app/Componentes/profesores/profesores.component';
import { EstudiantesModule } from 'src/app/Componentes/estudiantes/estudiantes.component';

@Component({
  selector: 'app-index',
  templateUrl: './index.component.html',
  styleUrls: ['./index.component.css']
})
export class IndexComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }

}

const routes: Routes = [
  { path: '', component: IndexComponent },
];

@NgModule({
  declarations: [
    IndexComponent
  ],
  exports: [
    IndexComponent
  ],
  imports: [
    RouterModule.forChild(routes),
    CommonModule,
    PersonajesModule,
    EstudiantesModule,
    ProfesoresModule
  ]
})

export class IndexModule {}
