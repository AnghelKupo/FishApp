import { Component, Output, EventEmitter, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { EstanqueApiService, Estanque } from '../../api/estanque.api.service';
import { PezApiService } from '../../api/pez.api.service';

@Component({
  selector: 'home-pez-form',
  standalone: true,
  imports: [FormsModule],
  template: `
    <div class="flex items-end gap-6 mb-6 flex-wrap">
      <h1 class="text-2xl font-semibold text-gray-700 mr-auto">Registrar pez</h1>
      <div class="flex items-end gap-4 flex-wrap">
        <div class="flex flex-col gap-1">
          <label class="text-xs font-medium text-gray-500">Código</label>
          <input type="text" [(ngModel)]="codigo" placeholder="Escanear chip..."
            class="px-3 py-2 border border-gray-300 rounded-md text-sm outline-none focus:border-blue-500 min-w-[180px]" />
        </div>
        <div class="flex flex-col gap-1">
          <label class="text-xs font-medium text-gray-500">Sexo</label>
          <select [(ngModel)]="sexo" required
            class="px-3 py-2 border border-gray-300 rounded-md text-sm outline-none focus:border-blue-500 min-w-[140px]">
            <option value="" disabled>Seleccionar</option>
            <option value="M">Macho</option>
            <option value="H">Hembra</option>
          </select>
        </div>
        <div class="flex flex-col gap-1">
          <label class="text-xs font-medium text-gray-500">Estanque</label>
          <select [(ngModel)]="estanqueId" required
            class="px-3 py-2 border border-gray-300 rounded-md text-sm outline-none focus:border-blue-500 min-w-[180px]">
            <option [ngValue]="null" disabled>Seleccionar</option>
            @for (e of estanques; track e.id) {
              <option [ngValue]="e.id">{{ e.nombre }}</option>
            }
          </select>
        </div>
        <div class="flex flex-col gap-1">
          <label class="text-xs font-medium text-gray-500">Fecha Registro</label>
          <input type="text" [value]="fechaActual" disabled
            class="px-3 py-2 border border-gray-200 rounded-md text-sm bg-gray-50 text-gray-500 min-w-[140px]" />
        </div>
        <button [disabled]="!codigo || !sexo || !estanqueId || guardando" (click)="onRegistrar()"
          class="flex items-center gap-2 px-5 py-2.5 bg-blue-500 text-white rounded-md text-sm font-medium cursor-pointer hover:bg-blue-600 transition-colors disabled:opacity-50 disabled:cursor-not-allowed">
          <svg width="16" height="16" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2">
            <path d="M11 4H4a2 2 0 0 0-2 2v14a2 2 0 0 0 2 2h14a2 2 0 0 0 2-2v-7"/>
            <path d="M18.5 2.5a2.121 2.121 0 0 1 3 3L12 15l-4 1 1-4 9.5-9.5z"/>
          </svg>
          {{ guardando ? 'Guardando...' : 'Registrar' }}
        </button>
      </div>
    </div>
  `
})
export class PezFormComponent implements OnInit {
  @Output() registrado = new EventEmitter<void>();

  codigo = '';
  sexo = '';
  estanqueId: number | null = null;
  estanques: Estanque[] = [];
  fechaActual = '';
  guardando = false;

  constructor(
    private estanqueApi: EstanqueApiService,
    private pezApi: PezApiService
  ) {}

  ngOnInit() {
    this.fechaActual = new Date().toLocaleDateString('es-MX', {
      year: 'numeric',
      month: '2-digit',
      day: '2-digit'
    });
    this.estanqueApi.getEstanques().subscribe({
      next: (res) => (this.estanques = res),
      error: () => console.error('Error al cargar estanques')
    });
  }

  onRegistrar() {
    if (!this.codigo || !this.sexo || !this.estanqueId) return;

    this.guardando = true;
    const ahora = new Date().toISOString();

    this.pezApi.createPez({
      codigo: this.codigo,
      sexo: this.sexo === 'H',
      fechaRegistro: ahora,
      idEstanque: this.estanqueId,
      fechaEntrada: ahora
    }).subscribe({
      next: () => {
        this.guardando = false;
        this.codigo = '';
        this.sexo = '';
        this.estanqueId = null;
        this.registrado.emit();
      },
      error: () => {
        this.guardando = false;
        console.error('Error al crear pez');
      }
    });
  }
}
