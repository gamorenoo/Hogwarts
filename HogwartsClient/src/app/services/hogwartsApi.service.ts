import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Solicitud } from '../models/solicitud';

@Injectable({
    providedIn: 'root'
})

export class HogwartsApiService {
    private urlBase = 'https://localhost:44382/api/Solicitud';
    constructor(
        private httpClient: HttpClient
    ) { }

    // Crea una solicitud
    post(solicitud: Solicitud){
        return this.httpClient.post(`${this.urlBase}`, solicitud);
    }

    // Obtiene las solicitudes
    get(){
        return this.httpClient.get(`${this.urlBase}`);
    }
}