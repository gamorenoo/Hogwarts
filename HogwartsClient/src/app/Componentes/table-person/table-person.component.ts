import { CommonModule } from '@angular/common';
import { Component, Input, NgModule, OnInit } from '@angular/core';
import { Persona } from 'src/app/models/persona';

@Component({
  selector: 'app-table-person',
  templateUrl: './table-person.component.html',
  styleUrls: ['./table-person.component.css']
})
export class TablePersonComponent implements OnInit {
  @Input() personas: Persona[] = []
  constructor() { }

  ngOnInit(): void {
  }

}

@NgModule({
  declarations: [
    TablePersonComponent
  ],
  exports: [
    TablePersonComponent
  ],
  imports: [
    CommonModule
  ]
})

export class TablePersonModule {}
