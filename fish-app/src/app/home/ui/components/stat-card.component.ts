import { Component, Input } from '@angular/core';

@Component({
  selector: 'home-stat-card',
  standalone: true,
  template: `
    <div class="bg-blue-500 text-white rounded-lg p-5 flex flex-col items-center gap-2">
      <span class="text-base font-medium">{{ label }}</span>
      <span class="text-2xl font-bold">{{ value }}</span>
    </div>
  `
})
export class StatCardComponent {
  @Input() label = '';
  @Input() value = 0;
}
