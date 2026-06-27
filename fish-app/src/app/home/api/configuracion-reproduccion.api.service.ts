import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

export interface ConfiguracionReproduccionBackend {
  id: number;
  especieId: number;
  sexo: boolean;
  diasCiclo: number;
  duracionEtapa: number;
  especie: { id: number; descripcion: string };
}

@Injectable({ providedIn: 'root' })
export class ConfiguracionReproduccionApiService {
  constructor(private http: HttpClient) {}

  getConfiguraciones(): Observable<ConfiguracionReproduccionBackend[]> {
    return this.http.get<ConfiguracionReproduccionBackend[]>(
      '/api/configuracionesreproduccion'
    );
  }
}
