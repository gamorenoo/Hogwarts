import { Injectable } from '@angular/core';

@Injectable({
    providedIn: 'root'
  })

  export class EdadService {
    calcularEdad(stringDate: string): number {
      let edad: number = 0;
      if(stringDate != '') {
        const fechaNacimiento: Date = new Date(this.ordernarFecha(stringDate));
        const fechaActual: Date = new Date();
        edad = fechaActual.getFullYear() - fechaNacimiento.getFullYear();
        const mes: number = fechaActual.getMonth() - fechaNacimiento.getMonth();
        if (mes < 0 || (mes === 0 && fechaActual.getDate() < fechaNacimiento.getDate())) {
          edad--;
        }
        if(isNaN(edad)) {
          edad = 0;
        }
      }
      return edad;
    }

    ordernarFecha(fecha: string): string
    {
      var aux = fecha.split("-");
      return (aux[2] + '-' + aux[1] + '-' + aux[0])
    }

  }
