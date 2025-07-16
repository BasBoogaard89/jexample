import { Routes } from '@angular/router';

export const routes: Routes = [
    { path: '', loadComponent: () => import('./pages/home/home').then(m => m.Home) },
    { path: '2', loadComponent: () => import('./pages/page2/page2').then(m => m.Page2) },
];
