import { Component } from '@angular/core';
import { AvatarComponent } from '../components/avatar.component';
import { LinkComponent } from '../components/link.component';
import { ButtonComponent } from '../components/button.component';

@Component({
  selector: 'shared-navbar',
  standalone: true,
  imports: [AvatarComponent, LinkComponent, ButtonComponent],
  template: `
    <nav class="flex items-center justify-between px-6 py-4 bg-white border-b border-gray-200">
      <div class="flex items-center gap-6">
        <shared-avatar />
        <shared-link label="Inicio" [active]="true" />
        <shared-link label="Reportes" />
      </div>
      <shared-button label="Eliminar Pez" variant="danger" />
    </nav>
  `
})
export class NavbarWidget {}
