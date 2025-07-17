import { Routes } from '@angular/router';

export const routes: Routes = [
    { path: '', loadComponent: () => import('./pages/company/company').then(m => m.Company) },
    { path: 'company', data: { label: 'Bedrijven' }, loadComponent: () => import('./pages/company/company').then(m => m.Company) },
    { path: 'vacancy', data: { label: 'Vacatures' }, loadComponent: () => import('./pages/vacancy/vacancy').then(m => m.Vacancy) },
];
