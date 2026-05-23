import { Component, inject, OnInit } from '@angular/core';
import { AsyncPipe } from '@angular/common';
import { StatCardComponent } from '../components/stat-card.component';
import { PezService } from '../../services/pez.service';

@Component({
  selector: 'home-stats-grid',
  standalone: true,
  imports: [StatCardComponent, AsyncPipe],
  template: `
    <div class="grid grid-cols-5 gap-4 mb-6">
      @if (stats$.getStats() | async; as stats) {
        <home-stat-card label="Total de Peces" [value]="stats.total" />
        <home-stat-card label="Total Hembras" [value]="stats.hembras" />
        <home-stat-card label="Estanque Repr." [value]="stats.estanqueRepr" />
        <home-stat-card label="Estanque Prin." [value]="stats.estanquePrin" />
        <home-stat-card label="En etapa" [value]="stats.enEtapa" />
      }
    </div>
  `
})
export class StatsGridWidget implements OnInit {
  stats$ = inject(PezService);

  ngOnInit() {}
}
