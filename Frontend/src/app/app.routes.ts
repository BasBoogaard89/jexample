import { Routes } from '@angular/router';

export const routes: Routes = [
    { path: '', loadComponent: () => import('./pages/home/home').then(m => m.Home) },
    { path: 'company', loadComponent: () => import('./pages/company/company').then(m => m.Company) },
];
