import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

export interface PezBackend {
  id: number;
  codigo: string;
  sexo: boolean;
  fechaRegistro: string;
  periodoReproduccion: string | null;
  pecesEstanques: PezEstanqueBackend[];
}

export interface PezEstanqueBackend {
  id: number;
  idPez: number;
  idEstanque: number;
  fechaEntrada: string;
  fechaSalida: string;
  motivoMovimento: string | null;
  estanque?: { id: number; nombre: string; tipo: number; fechaCreacion: string };
}

export interface PezListItem {
  id: number;
  codigo: string;
  sexo: string;
  fechaRegistro: string;
  periodoReproduccion: string | null;
  enReproduccion: boolean;
  estanque: string;
  estanqueId: number | null;
  entradaEstanque: string;
  diasEstanque: number;
}

export interface CreatePezRequest {
  codigo: string;
  sexo: boolean;
  fechaRegistro: string;
  idEstanque: number;
  fechaEntrada: string;
}

function toPezListItem(p: PezBackend): PezListItem {
  const ultimo = p.pecesEstanques?.length
    ? p.pecesEstanques[p.pecesEstanques.length - 1]
    : null;

  const fechaEntrada = ultimo ? ultimo.fechaEntrada : '';
  const dias = fechaEntrada
    ? Math.floor(
        (Date.now() - new Date(fechaEntrada).getTime()) / (1000 * 60 * 60 * 24)
      )
    : 0;

  return {
    id: p.id,
    codigo: p.codigo,
    sexo: p.sexo ? 'H' : 'M',
    fechaRegistro: p.fechaRegistro,
    periodoReproduccion: p.periodoReproduccion,
    enReproduccion: p.periodoReproduccion != null,
    estanque: ultimo?.estanque?.nombre ?? '',
    estanqueId: ultimo?.idEstanque ?? null,
    entradaEstanque: fechaEntrada,
    diasEstanque: dias,
  };
}

@Injectable({ providedIn: 'root' })
export class PezApiService {
  constructor(private http: HttpClient) {}

  getPeces(): Observable<PezListItem[]> {
    return this.http
      .get<PezBackend[]>('/api/peces')
      .pipe(map((peces) => peces.map(toPezListItem)));
  }

  createPez(data: CreatePezRequest): Observable<PezBackend> {
    return this.http.post<PezBackend>('/api/peces', data);
  }
}
