import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

export interface Estanque {
  id: number;
  nombre: string;
  tipo: number;
  fechaCreacion: string;
}

@Injectable({ providedIn: 'root' })
export class EstanqueApiService {
  constructor(private http: HttpClient) {}

  getEstanques(): Observable<Estanque[]> {
    return this.http.get<Estanque[]>('/api/estanques');
  }
}
