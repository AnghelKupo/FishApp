import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { PezApiService, Pez } from '../api/pez.api.service';

export interface PezStats {
  total: number;
  hembras: number;
  estanqueRepr: number;
  estanquePrin: number;
  enEtapa: number;
}

@Injectable({ providedIn: 'root' })
export class PezService {
  constructor(private api: PezApiService) {}

  getPeces(): Observable<Pez[]> {
    return this.api.getPeces();
  }

  getStats(): Observable<PezStats> {
    return this.api.getPeces().pipe(
      map(peces => ({
        total: peces.length,
        hembras: peces.filter(p => p.sexo === 'H').length,
        estanqueRepr: peces.filter(p => p.estanque === 'Reproducción').length,
        estanquePrin: peces.filter(p => p.estanque === 'Principal').length,
        enEtapa: peces.filter(p => p.enReproduccion).length
      }))
    );
  }
}
