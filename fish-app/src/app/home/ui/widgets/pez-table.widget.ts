import { Component, inject } from '@angular/core';
import { AsyncPipe, DatePipe } from '@angular/common';
import { PezService } from '../../services/pez.service';

@Component({
  selector: 'home-pez-table',
  standalone: true,
  imports: [AsyncPipe, DatePipe],
  template: `
    <div class="bg-white border border-gray-200 rounded-lg p-4">
      <h2 class="text-lg font-medium text-gray-700 mb-4">Peces</h2>
      <div class="overflow-x-auto">
        <table class="w-full border-collapse">
          <thead>
            <tr>
              <th class="text-left py-3 px-2 text-xs font-medium text-gray-500 border-b-2 border-gray-200">Código</th>
              <th class="text-left py-3 px-2 text-xs font-medium text-gray-500 border-b-2 border-gray-200">ID</th>
              <th class="text-left py-3 px-2 text-xs font-medium text-gray-500 border-b-2 border-gray-200">Sexo</th>
              <th class="text-left py-3 px-2 text-xs font-medium text-gray-500 border-b-2 border-gray-200">Especie</th>
              <th class="text-left py-3 px-2 text-xs font-medium text-gray-500 border-b-2 border-gray-200">Fecha registro</th>
              <th class="text-left py-3 px-2 text-xs font-medium text-gray-500 border-b-2 border-gray-200">En Reproducción</th>              
              <th class="text-left py-3 px-2 text-xs font-medium text-gray-500 border-b-2 border-gray-200">Ultima reproducción</th>
              <th class="text-left py-3 px-2 text-xs font-medium text-gray-500 border-b-2 border-gray-200">Estanque</th>
              <th class="text-left py-3 px-2 text-xs font-medium text-gray-500 border-b-2 border-gray-200">Entrada estanque</th>
              <th class="text-left py-3 px-2 text-xs font-medium text-gray-500 border-b-2 border-gray-200">Días estanque</th>
            </tr>
          </thead>
          <tbody>
            @if (peces$ | async; as peces) {
              @for (pez of peces; track pez.id) {
                <tr>
                  <td class="py-3 px-2 text-sm text-gray-700 border-b border-gray-100 font-mono">{{ pez.codigo }}</td>
                  <td class="py-3 px-2 text-sm text-gray-700 border-b border-gray-100">{{ pez.id }}</td>
                  <td class="py-3 px-2 text-sm border-b border-gray-100 font-semibold"
                    [class.text-green-600]="pez.sexo === 'H'"
                    [class.text-yellow-500]="pez.sexo === 'M'">{{ pez.sexo }}</td>
                  <td class="py-3 px-2 text-sm text-gray-700 border-b border-gray-100">{{ pez.especie }}</td>
                  <td class="py-3 px-2 text-sm text-gray-700 border-b border-gray-100">{{ pez.fechaRegistro | date:'dd-MM-yyyy' }}</td>
                  <td class="py-3 px-2 border-b border-gray-100">
                    <span class="inline-block px-2.5 py-0.5 rounded text-xs font-semibold text-white"
                      [class.bg-green-600]="pez.enReproduccion"
                      [class.bg-red-500]="!pez.enReproduccion">
                      {{ pez.enReproduccion ? 'Si' : 'No' }}
                    </span>
                  </td>
                  <td class="py-3 px-2 text-sm text-gray-700 border-b border-gray-100">{{ pez.fechaUltimaReproduccion | date:'dd-MM-yyyy' }}</td>
                  <td class="py-3 px-2 text-sm text-gray-700 border-b border-gray-100">{{ pez.estanque }}</td>
                  <td class="py-3 px-2 text-sm text-gray-700 border-b border-gray-100">{{ pez.entradaEstanque | date:'dd-MM-yyyy' }}</td>
                  <td class="py-3 px-2 text-sm text-gray-700 border-b border-gray-100">{{ pez.diasEstanque }}</td>
                </tr>
              }
            }
          </tbody>
        </table>
      </div>
    </div>
  `
})
export class PezTableWidget {
  peces$ = inject(PezService).getPeces();
}
