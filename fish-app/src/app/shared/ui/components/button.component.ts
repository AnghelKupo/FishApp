import { Component, Input, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'shared-button',
  standalone: true,
  template: `
    <button
      [class]="baseClasses + ' ' + variantClasses"
      (click)="clicked.emit()"
    >
      @if (icon) {
        <span class="mr-2">{{ icon }}</span>
      }
      {{ label }}
    </button>
  `
})
export class ButtonComponent {
  @Input() label = '';
  @Input() variant: 'primary' | 'danger' = 'primary';
  @Input() icon = '';
  @Output() clicked = new EventEmitter<void>();

  baseClasses = 'px-4 py-2 rounded-md text-sm font-medium cursor-pointer transition-colors flex items-center';
  variantClasses = '';

  ngOnChanges() {
    this.variantClasses = this.variant === 'danger'
      ? 'bg-red-500 text-white hover:bg-red-600'
      : 'bg-blue-500 text-white hover:bg-blue-600';
  }
}
