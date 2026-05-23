import { Component, input } from '@angular/core';

@Component({
  selector: 'shared-link',
  standalone: true,
  template: `
    <a
      [href]="href()"
      [class]="active() ? 'text-blue-500 font-semibold' : 'text-gray-500'"
      class="text-sm cursor-pointer hover:text-blue-400 transition-colors"
    >
      {{ label() }}
    </a>
  `
})
export class LinkComponent {
  label = input<string>('');
  href = input<string>('');
  active = input<boolean>(false);
  clicked = new CustomEvent('click');
}
