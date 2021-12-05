import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';

@Injectable({
    providedIn: 'root'
})

export class HerokuappService {
    private urlBase = 'http://hp-api.herokuapp.com/api/characters';
    constructor(
        private httpClient: HttpClient
    ) { }

    // Obtiene los profesores
    obtenerPersonajes(nombreCasa: string){
        return this.httpClient.get(`${this.urlBase}/house/${nombreCasa}`);
    }

    // Obtiene los estudiantes
    obtenerEstudiantes(){
        return this.httpClient.get(`${this.urlBase}/students`);
    }

    // Obtiene los profesores
    obtenerProfesores(){
        return this.httpClient.get(`${this.urlBase}/staff`);
    }
}