import { Component, inject } from '@angular/core';
import { NavbarWidget } from '../../../shared/ui/widgets/navbar.widget';
import { PezFormComponent } from '../components/pez-form.component';
import { StatsGridWidget } from '../widgets/stats-grid.widget';
import { PezTableWidget } from '../widgets/pez-table.widget';
import { PezService } from '../../services/pez.service';

@Component({
  selector: 'home-page',
  standalone: true,
  imports: [NavbarWidget, PezFormComponent, StatsGridWidget, PezTableWidget],
  template: `
    <div class="min-h-screen bg-gray-50">
      <shared-navbar />
      <main class="max-w-7xl mx-auto p-6">
        <home-pez-form (registrado)="onPezRegistrado()" />
        <home-stats-grid />
        <home-pez-table />
      </main>
    </div>
  `
})
export class HomePage {
  private pezService = inject(PezService);

  onPezRegistrado() {
    this.pezService.refresh();
  }
}
