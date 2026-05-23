import { Component, Input } from '@angular/core';

@Component({
  selector: 'shared-avatar',
  standalone: true,
  template: `
    <div class="w-8 h-8 rounded-full bg-gray-900"></div>
  `
})
export class AvatarComponent {}
