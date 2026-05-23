import { Component, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'home-pez-form',
  standalone: true,
  template: `
    <div class="flex items-end gap-6 mb-6 flex-wrap">
      <h1 class="text-2xl font-semibold text-gray-700 mr-auto">Registrar pez</h1>
      <div class="flex items-end gap-4 flex-wrap">
        <div class="flex flex-col gap-1">
          <label class="text-xs font-medium text-gray-500">ID</label>
          <input type="text" placeholder="+" class="px-3 py-2 border border-gray-300 rounded-md text-sm outline-none focus:border-blue-500 min-w-[140px]" />
        </div>
        <div class="flex flex-col gap-1">
          <label class="text-xs font-medium text-gray-500">Sexo</label>
          <select class="px-3 py-2 border border-gray-300 rounded-md text-sm outline-none focus:border-blue-500 min-w-[140px]">
            <option></option>
          </select>
        </div>
        <div class="flex flex-col gap-1">
          <label class="text-xs font-medium text-gray-500">Estanque</label>
          <select class="px-3 py-2 border border-gray-300 rounded-md text-sm outline-none focus:border-blue-500 min-w-[140px]">
            <option></option>
          </select>
        </div>
        <button class="flex items-center gap-2 px-5 py-2.5 bg-blue-500 text-white rounded-md text-sm font-medium cursor-pointer hover:bg-blue-600 transition-colors" (click)="registrar.emit()">
          <svg width="16" height="16" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2">
            <path d="M11 4H4a2 2 0 0 0-2 2v14a2 2 0 0 0 2 2h14a2 2 0 0 0 2-2v-7"/>
            <path d="M18.5 2.5a2.121 2.121 0 0 1 3 3L12 15l-4 1 1-4 9.5-9.5z"/>
          </svg>
          Registrar
        </button>
      </div>
    </div>
  `
})
export class PezFormComponent {
  @Output() registrar = new EventEmitter<void>();
}
