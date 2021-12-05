import { CommonModule } from '@angular/common';
import { Component, EventEmitter, Input, NgModule, OnInit, Output } from '@angular/core';
import { FormGroup, FormControl, FormsModule } from '@angular/forms';

@Component({
  selector: 'app-custom-select',
  templateUrl: './custom-select.component.html',
  styleUrls: ['./custom-select.component.css']
})
export class CustomSelectComponent implements OnInit {
  @Output() onListSelection = new EventEmitter<{ casaSeleccionada: string; }>();
  selectControl = new FormControl('1');
  casa = '0';
  options = [
    { value: '0', label: 'Seleccione...' },
    { value: 'slytherin', label: 'Slytherin' },
    { value: 'gryffindor', label: 'Gryffindor' },
    { value: 'ravenclaw', label: 'Ravenclaw' },
    { value: 'hufflepuff', label: 'Hufflepuff' }
  ];
  constructor() { }

  ngOnInit(): void {
  }

  onChange() {
    this.onListSelection.emit({ casaSeleccionada: this.casa });
}

}


@NgModule({
  declarations: [
    CustomSelectComponent
  ],
  exports: [
    CustomSelectComponent
  ],
  imports: [
    CommonModule,
    FormsModule
  ]
})

export class CustomSelectModule {}
