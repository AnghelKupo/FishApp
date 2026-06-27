import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { EspecieBackend } from './pez.api.service';

@Injectable({ providedIn: 'root' })
export class EspecieApiService {
  constructor(private http: HttpClient) {}

  getEspecies(): Observable<EspecieBackend[]> {
    return this.http.get<EspecieBackend[]>('/api/especies');
  }
}
