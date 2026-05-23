import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';

export interface Pez {
  id: string;
  sexo: string;
  fechaRegistro: string;
  enReproduccion: boolean;
  huevos: boolean;
  estanque: string;
  entradaEstanque: string;
  diasEstanque: number;
}

@Injectable({ providedIn: 'root' })
export class PezApiService {
  getPeces(): Observable<Pez[]> {
    return of([
      { id: '1234567890', sexo: 'H', fechaRegistro: '08-02-2026', enReproduccion: true, huevos: false, estanque: 'Reproducción', entradaEstanque: '01-05-2026', diasEstanque: 30 },
      { id: '1234567890', sexo: 'M', fechaRegistro: '21-03-2026', enReproduccion: false, huevos: true, estanque: 'Principal', entradaEstanque: '01-04-2026', diasEstanque: 28 },
      { id: '1234567890', sexo: 'H', fechaRegistro: '21-03-2026', enReproduccion: true, huevos: false, estanque: 'Principal', entradaEstanque: '01-05-2026', diasEstanque: 23 },
      { id: '1234567890', sexo: 'M', fechaRegistro: '21-02-2026', enReproduccion: true, huevos: false, estanque: 'Principal', entradaEstanque: '01-05-2026', diasEstanque: 1 },
      { id: '1234567890', sexo: 'H', fechaRegistro: '01-03-2026', enReproduccion: true, huevos: false, estanque: 'Principal', entradaEstanque: '01-05-2026', diasEstanque: 7 }
    ]);
  }
}
