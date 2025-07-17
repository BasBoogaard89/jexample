import { Component } from '@angular/core';
import { routes } from '../../app.routes';
import { RouterModule } from '@angular/router';
import { CommonModule } from '@angular/common';
import { MaterialModule } from '../../modules/material-module';

@Component({
    selector: 'app-menu',
    imports: [CommonModule, RouterModule, MaterialModule],
    templateUrl: './menu.html',
    styleUrl: './menu.scss'
})
export class Menu {
    navRoutes = routes
        .filter(r=> r.data)
        .map(r => ({
            path: r.path,
            label: r.data!['label']
        }));
}
