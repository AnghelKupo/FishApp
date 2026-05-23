import { Routes } from '@angular/router';

export const appRoutes: Routes = [
  { path: '', loadChildren: () => import('./home/router').then(m => m.homeRoutes) }
];
