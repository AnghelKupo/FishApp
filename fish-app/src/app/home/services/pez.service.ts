import { Injectable } from '@angular/core';
import { Observable, BehaviorSubject, switchMap, of } from 'rxjs';
import { map, catchError } from 'rxjs/operators';
import { PezApiService, PezListItem } from '../api/pez.api.service';

function logError(err: any) { console.error('Error al cargar peces', err); return of([] as PezListItem[]); }

export interface PezStats {
  total: number;
  hembras: number;
  estanqueRepr: number;
  estanquePrin: number;
  enEtapa: number;
}

@Injectable({ providedIn: 'root' })
export class PezService {
  private refresh$ = new BehaviorSubject<void>(undefined);

  constructor(private api: PezApiService) {}

  getPeces(): Observable<PezListItem[]> {
    return this.refresh$.pipe(switchMap(() => this.api.getPeces().pipe(catchError(logError))));
  }

  getStats(): Observable<PezStats> {
    return this.getPeces().pipe(
      map((peces) => ({
        total: peces.length,
        hembras: peces.filter((p) => p.sexo === 'H').length,
        estanqueRepr: peces.filter((p) => p.estanqueId === 2).length,
        estanquePrin: peces.filter((p) => p.estanqueId === 1).length,
        enEtapa: peces.filter((p) => p.enReproduccion).length,
      }))
    );
  }

  refresh() {
    this.refresh$.next();
  }
}
